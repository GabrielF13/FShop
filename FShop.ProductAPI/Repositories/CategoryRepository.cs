﻿using FShop.ProductAPI.Context;
using FShop.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FShop.ProductAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesProducts()
        {
            return await _context.Categories.Include(c=>c.Products).ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _context.Categories.Where(c => c.CategoryID == id).FirstOrDefaultAsync();

            if (category == null)
                return null;

            return category;
        }

        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Delete(int id)
        {
            var product = await GetById(id);

            if (product == null)
                return null;

            _context.Categories.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        } 
    }
}