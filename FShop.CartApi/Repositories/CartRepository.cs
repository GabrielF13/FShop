using AutoMapper;
using FShop.CartApi.Context;
using FShop.CartApi.DTOs;
using FShop.CartApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FShop.CartApi.Repositories;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;
    private IMapper _mapper;

    public CartRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> CleanCartAsync(string userId)
    {
        var cartHeader = await _context.CartHeaders.FirstOrDefaultAsync(c => c.UserId == userId);

        if (cartHeader is not null)
        {
            _context.CartItens.RemoveRange(_context.CartItens.Where(c => c.CartHeaderId == cartHeader.Id));
            _context.CartHeaders.Remove(cartHeader);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<CartDTO> GetCartByUserIdAsync(string userId)
    {
        Cart cart = new()
        {
            CartHeader = await _context.CartHeaders
                               .FirstOrDefaultAsync(c => c.UserId == userId),
        };

        cart.CartItens = _context.CartItens
                        .Where(c => c.CartHeaderId == cart.CartHeader.Id)
                        .Include(c => c.Product);

        return _mapper.Map<CartDTO>(cart);
    }

    public async Task<bool> DeleteItemCartAsync(int cartItemId)
    {
        try
        {
            CartItem cartItem = await _context.CartItens
                               .FirstOrDefaultAsync(c => c.Id == cartItemId);

            int total = _context.CartItens.Where(c => c.CartHeaderId == cartItem.CartHeaderId).Count();

            _context.CartItens.Remove(cartItem);
            await _context.SaveChangesAsync();

            if (total == 1)
            {
                var cartHeader = await _context.CartHeaders.FirstOrDefaultAsync(
                                             c => c.Id == cartItem.CartHeaderId);

                _context.CartHeaders.Remove(cartHeader);
                await _context.SaveChangesAsync();
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<CartDTO> UpdateCartAsync(CartDTO cartDto)
    {
        Cart cart = _mapper.Map<Cart>(cartDto);

        await SaveProductInDataBase(cartDto, cart);

        var cartHeader = await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(
                               c => c.UserId == cart.CartHeader.UserId);

        if (cartHeader is null)
        {
            await CreateCartHeaderAndItems(cart);
        }
        else
        {
            await UpdateQuantityAndItems(cartDto, cart, cartHeader);
        }
        return _mapper.Map<CartDTO>(cart);
    }

    private async Task UpdateQuantityAndItems(CartDTO cartDto, Cart cart, CartHeader? cartHeader)
    {
        var cartItem = await _context.CartItens.AsNoTracking().FirstOrDefaultAsync(
                               p => p.ProductId == cartDto.CartItens.FirstOrDefault()
                               .ProductId && p.CartHeaderId == cartHeader.Id);

        if (cartItem is null)
        {
            //Cria o CartItens
            cart.CartItens.FirstOrDefault().CartHeaderId = cartHeader.Id;
            cart.CartItens.FirstOrDefault().Product = null;
            _context.CartItens.Add(cart.CartItens.FirstOrDefault());
            await _context.SaveChangesAsync();
        }
        else
        {
            cart.CartItens.FirstOrDefault().Product = null;
            cart.CartItens.FirstOrDefault().Quantity += cartItem.Quantity;
            cart.CartItens.FirstOrDefault().Id = cartItem.Id;
            cart.CartItens.FirstOrDefault().CartHeaderId = cartItem.CartHeaderId;
            _context.CartItens.Update(cart.CartItens.FirstOrDefault());
            await _context.SaveChangesAsync();
        }
    }

    private async Task CreateCartHeaderAndItems(Cart cart)
    {
        _context.CartHeaders.Add(cart.CartHeader);
        await _context.SaveChangesAsync();

        cart.CartItens.FirstOrDefault().CartHeaderId = cart.CartHeader.Id;
        cart.CartItens.FirstOrDefault().Product = null;

        _context.CartItens.Add(cart.CartItens.FirstOrDefault());

        await _context.SaveChangesAsync();
    }

    private async Task SaveProductInDataBase(CartDTO cartDto, Cart cart)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id ==
                            cartDto.CartItens.FirstOrDefault().ProductId);

        if (product is null)
        {
            _context.Products.Add(cart.CartItens.FirstOrDefault().Product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ApplyCouponAsync(string userId, string couponCode)
    {
        var cartHeaderApplyCoupon = await _context.CartHeaders
                               .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cartHeaderApplyCoupon is not null)
        {
            cartHeaderApplyCoupon.CouponCode = couponCode;

            _context.CartHeaders.Update(cartHeaderApplyCoupon);

            await _context.SaveChangesAsync();

            return true;
        }
        return false;
    }

    public async Task<bool> DeleteCouponAsync(string userId)
    {
        var cartHeaderDeleteCoupon = await _context.CartHeaders
                              .FirstOrDefaultAsync(c => c.UserId == userId);

        if (cartHeaderDeleteCoupon is not null)
        {
            cartHeaderDeleteCoupon.CouponCode = "";

            _context.CartHeaders.Update(cartHeaderDeleteCoupon);

            await _context.SaveChangesAsync();

            return true;
        }
        return false;
    }
}
