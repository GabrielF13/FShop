using FShop.ProductAPI.DTOs;
using FShop.ProductAPI.DTOs.Mappings;
using FShop.ProductAPI.Repositories;

namespace FShop.ProductAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRepository.GetAll();
            return categoriesEntity.ToDTO();
        }
        public async Task<IEnumerable<CategoryDTO>> GetCategoriesProducts()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesProducts();
            return categoriesEntity.ToDTO();
        }
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            return categoryEntity.ToDTO();
        }
        public async Task CreateCategory(CategoryDTO categoryDto)
        {
            var categoryEntity = categoryDto.ToEntity();
            await _categoryRepository.Create(categoryEntity);
            categoryDto.CategoryID = categoryEntity.CategoryID;
        }
        public async Task UpdateCategory(CategoryDTO categoryDto)
        {
            var categoryEntity = categoryDto.ToEntity();
            await _categoryRepository.Update(categoryEntity);
        }

        public async Task DeleteCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Delete(categoryEntity.CategoryID);
        }
    }
}
