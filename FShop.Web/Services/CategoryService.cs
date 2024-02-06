using FShop.Web.Models;
using FShop.Web.Services.Contracts;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FShop.Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory _clientFactory; 
        private readonly JsonSerializerOptions _options;
        private readonly string apiEndpoint = "/api/Categories/";

        public CategoryService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories(string token)
        {
            var client = _clientFactory.CreateClient("ProductApi");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            IEnumerable<CategoryViewModel> categories;

            var response = await client.GetAsync(apiEndpoint);

            if(response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                categories = await JsonSerializer.DeserializeAsync<IEnumerable<CategoryViewModel>>(apiResponse);
            }
            else
            {
                categories = null;
            }
            return categories;
        }
    }
}
