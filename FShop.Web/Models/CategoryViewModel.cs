using System.ComponentModel.DataAnnotations;

namespace FShop.Web.Models
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string? Name { get; set; }
    }
}
