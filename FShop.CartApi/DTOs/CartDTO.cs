using FShop.CartApi.Models;

namespace FShop.CartApi.DTOs
{
    public class CartDTO
    {
        public CartHeaderDTO CartHeader { get; set; } = new CartHeaderDTO();
        public IEnumerable<CartItemDTO> CartItens { get; set; } = Enumerable.Empty<CartItemDTO>();
    }
}
