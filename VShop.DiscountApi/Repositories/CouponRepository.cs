using Microsoft.EntityFrameworkCore;
using VShop.DiscountApi.Context;
using VShop.DiscountApi.DTOs;
using VShop.DiscountApi.DTOs.Mappings;

namespace VShop.DiscountApi.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly AppDbContext _context;

        public CouponRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CouponDTO> GetCouponByCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);

            return coupon.ToDTO()!;
        }
    }
}
