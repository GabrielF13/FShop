using AutoMapper;
using FShop.ProductAPI.DTOs;
using FShop.ProductAPI.Models;
using FShop.ProductAPI.Repositories;

namespace FShop.ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }
        public async Task<ProductDTO> GetProductById(int id)
        {
            var productsEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductDTO>(productsEntity);
        }
        public async Task CreateProduct(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Create(productEntity);
            productDto.Id = productEntity.Id;
        }
        public async Task UpdateProduct(ProductDTO productDto)
        {
           var categoryEntity = _mapper.Map<Product>(productDto);
            await _productRepository.Update(categoryEntity);
        }
        public async Task DeleteProduct(int id)
        {
            var productEntity = _productRepository.GetById(id).Result;
            await _productRepository.DeleteById(productEntity.Id);
        }
    }
}
