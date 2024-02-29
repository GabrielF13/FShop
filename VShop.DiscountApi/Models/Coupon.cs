using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VShop.DiscountApi.Models;

public class Coupon
{
    public int CouponId { get; set; }

    [Required]
    [StringLength(30)]
    public string? CouponCode { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Discount { get; set; }
}
