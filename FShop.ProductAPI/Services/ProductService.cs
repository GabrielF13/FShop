using FShop.ProductAPI.DTOs;
using FShop.ProductAPI.DTOs.Mappings;
using FShop.ProductAPI.Repositories;

namespace FShop.ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetAll();
            return productsEntity.ToDTO();
        }
        public async Task<ProductDTO> GetProductById(int id)
        {
            var productsEntity = await _productRepository.GetById(id);
            return productsEntity.ToDTO();
        }
        public async Task CreateProduct(ProductDTO productDto)
        {
            var productEntity = productDto.ToEntity();
            await _productRepository.Create(productEntity);
            productDto.Id = productEntity.Id;
        }
        public async Task UpdateProduct(ProductDTO productDto)
        {
            var productEntity = productDto.ToEntity();
            await _productRepository.Update(productEntity);
        }
        public async Task DeleteProduct(int id)
        {
            var productEntity = _productRepository.GetById(id).Result;
            await _productRepository.DeleteById(productEntity.Id);
        }
    }
}
