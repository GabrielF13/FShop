using FShop.Web.Models;
using FShop.Web.Services.Contracts;
using System.Text.Json;

namespace FShop.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string apiEndpoint = "/api/product/";
        private readonly JsonSerializerOptions _options;
        private ProductViewModel _productVM;
        private IEnumerable<ProductViewModel> _productsVM;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public Task<IEnumerable<ProductViewModel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
        public Task<ProductViewModel> FindProductById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<ProductViewModel> CreateProduct(ProductViewModel productVM)
        {
            throw new NotImplementedException();
        }
        public Task<ProductViewModel> UpdateProduct(ProductViewModel productVM)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }        
    }
}
