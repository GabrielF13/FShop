using System.Diagnostics.CodeAnalysis;
using FShop.ProductAPI.Models;

namespace FShop.ProductAPI.DTOs.Mappings
{
    public static class MappingExtensions
    {
        [return: NotNullIfNotNull("category")]
        public static CategoryDTO? ToDTO(this Category? category)
        {
            if (category is null) return null;

            return new CategoryDTO
            {
                CategoryID = category.CategoryID,
                Name = category.Name,
                Products = category.Products
            };
        }

        [return: NotNullIfNotNull("categoryDto")]
        public static Category? ToEntity(this CategoryDTO? categoryDto)
        {
            if (categoryDto is null) return null;

            return new Category
            {
                CategoryID = categoryDto.CategoryID,
                Name = categoryDto.Name,
                Products = categoryDto.Products
            };
        }

        [return: NotNullIfNotNull("product")]
        public static ProductDTO? ToDTO(this Product? product)
        {
            if (product is null) return null;

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                ImageURL = product.ImageURL,
                CategoryName = product.Category?.Name,
                CategoryId = product.CategoryId,
                Category = product.Category
            };
        }

        [return: NotNullIfNotNull("productDto")]
        public static Product? ToEntity(this ProductDTO? productDto)
        {
            if (productDto is null) return null;

            return new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Stock = productDto.Stock,
                ImageURL = productDto.ImageURL,
                CategoryId = productDto.CategoryId,
                Category = productDto.Category
            };
        }

        public static IEnumerable<CategoryDTO> ToDTO(this IEnumerable<Category>? categories) =>
            categories?.Select(c => c.ToDTO()).ToList() ?? new List<CategoryDTO>();

        public static IEnumerable<ProductDTO> ToDTO(this IEnumerable<Product>? products) =>
            products?.Select(p => p.ToDTO()).ToList() ?? new List<ProductDTO>();
    }
}
