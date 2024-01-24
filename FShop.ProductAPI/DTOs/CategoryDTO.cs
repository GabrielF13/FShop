using FShop.ProductAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FShop.ProductAPI.DTOs
{
    public class CategoryDTO
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage ="The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
