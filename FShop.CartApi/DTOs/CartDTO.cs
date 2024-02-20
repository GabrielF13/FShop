using FShop.CartApi.Models;

namespace FShop.CartApi.DTOs
{
    public class CartDTO
    {
        public CartHeader CartHeader { get; set; } = new CartHeader();

        public IEnumerable<CartItem> CartItens { get; set; } = Enumerable.Empty<CartItem>();
    }
}
