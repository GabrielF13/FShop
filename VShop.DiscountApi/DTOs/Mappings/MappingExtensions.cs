using System.Diagnostics.CodeAnalysis;
using VShop.DiscountApi.Models;

namespace VShop.DiscountApi.DTOs.Mappings
{
    public static class MappingExtensions
    {
        [return: NotNullIfNotNull("coupon")]
        public static CouponDTO? ToDTO(this Coupon? coupon)
        {
            if (coupon is null) return null;

            return new CouponDTO
            {
                CouponId = coupon.CouponId,
                CouponCode = coupon.CouponCode,
                Discount = coupon.Discount
            };
        }

        [return: NotNullIfNotNull("couponDto")]
        public static Coupon? ToEntity(this CouponDTO? couponDto)
        {
            if (couponDto is null) return null;

            return new Coupon
            {
                CouponId = couponDto.CouponId,
                CouponCode = couponDto.CouponCode,
                Discount = couponDto.Discount
            };
        }
    }
}
