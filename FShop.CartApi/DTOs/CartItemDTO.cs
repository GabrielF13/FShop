using FShop.CartApi.Models;

namespace FShop.CartApi.DTOs
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public ProductDTO product { get; set; } = new ProductDTO();
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int CardHeaderId { get; set; }
        public CartHeader CartHeader { get; set; } = new CartHeader();
    }
}
