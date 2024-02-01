using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FShop.Web.Models
{
    public class CategoryViewModel
    {
        [JsonPropertyName("categoryID")]
        public int CategoryId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
