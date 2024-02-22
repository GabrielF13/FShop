namespace FShop.CartApi.Models
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; } = new CartHeader();
        public IEnumerable<CartItem> CartItens { get; set; } = Enumerable.Empty<CartItem>();
    }
}
