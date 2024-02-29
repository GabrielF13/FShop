using FShop.Web.Models;

namespace FShop.Web.Services.Contracts
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetDiscountCoupon(string couponCode, string token);
    }
}
