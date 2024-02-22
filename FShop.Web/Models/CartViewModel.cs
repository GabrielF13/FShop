namespace FShop.Web.Models
{
    public class CartViewModel
    {
        public CartHeaderViewModel CartHeader { get; set; } = new CartHeaderViewModel();
        public IEnumerable<CartItemViewModel>? CartItens { get; set; }
    }
}
