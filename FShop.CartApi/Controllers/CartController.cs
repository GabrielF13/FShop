using FShop.CartApi.DTOs;
using FShop.CartApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FShop.CartApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    [HttpPost("applycoupon")]
    public async Task<ActionResult<CartDTO>> ApplyCoupon(CartDTO cartDto)
    {
        var result = await _cartRepository.ApplyCouponAsync(cartDto.CartHeader.UserId,
                                                        cartDto.CartHeader.CouponCode);

        if (!result)
        {
            return NotFound($"CartHeader not found for userId = {cartDto.CartHeader.UserId}");
        }
        return Ok(result);
    }

    [HttpDelete("deletecoupon/{userId}")]
    public async Task<ActionResult<CartDTO>> DeleteCoupon(string userId)
    {
        var result = await _cartRepository.DeleteCouponAsync(userId);

        if (!result)
        {
            return NotFound($"Discount Coupon not found for userId = {userId}");
        }

        return Ok(result);
    }

    [HttpGet("getcart/{userid}")]
    public async Task<ActionResult<CartDTO>> GetByUserId(string userId)
    {
        var cartDto = await _cartRepository.GetCartByUserIdAsync(userId);

        if (cartDto is null)
            return NotFound();

        return Ok(cartDto);
    }

    [HttpPost("addcart")]
    public async Task<ActionResult<CartDTO>> AddCart(CartDTO cartDto)
    {
        var cart = await _cartRepository.UpdateCartAsync(cartDto);

        if (cart is null)
            return NotFound();

        return Ok(cart);
    }

    [HttpPut("updatecart")]
    public async Task<ActionResult<CartDTO>> UpdateCart(CartDTO cartDto)
    {
        var cart = await _cartRepository.UpdateCartAsync(cartDto);

        if (cart is null)
            return NotFound();

        return Ok(cart);
    }

    [HttpDelete("deletecart/{id}")]
    public async Task<ActionResult<bool>> DeleteCart(int id)
    {
        var status = await _cartRepository.DeleteItemCartAsync(id);

        if (!status) return BadRequest();

        return Ok(status);
    }
}
