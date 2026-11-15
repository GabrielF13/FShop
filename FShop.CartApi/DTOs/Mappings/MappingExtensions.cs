using System.Diagnostics.CodeAnalysis;
using FShop.CartApi.Models;

namespace FShop.CartApi.DTOs.Mappings
{
    public static class MappingExtensions
    {
        [return: NotNullIfNotNull("cart")]
        public static CartDTO? ToDTO(this Cart? cart)
        {
            if (cart is null) return null;

            return new CartDTO
            {
                CartHeader = cart.CartHeader.ToDTO(),
                CartItems = cart.CartItems?.Select(i => i.ToDTO()).ToList() ?? new List<CartItemDTO>()
            };
        }

        [return: NotNullIfNotNull("cartDto")]
        public static Cart? ToEntity(this CartDTO? cartDto)
        {
            if (cartDto is null) return null;

            return new Cart
            {
                CartHeader = cartDto.CartHeader.ToEntity(),
                CartItems = cartDto.CartItems?.Select(i => i.ToEntity()).ToList() ?? new List<CartItem>()
            };
        }

        [return: NotNullIfNotNull("cartHeader")]
        public static CartHeaderDTO? ToDTO(this CartHeader? cartHeader)
        {
            if (cartHeader is null) return null;

            return new CartHeaderDTO
            {
                Id = cartHeader.Id,
                UserId = cartHeader.UserId,
                CouponCode = cartHeader.CouponCode
            };
        }

        [return: NotNullIfNotNull("cartHeaderDto")]
        public static CartHeader? ToEntity(this CartHeaderDTO? cartHeaderDto)
        {
            if (cartHeaderDto is null) return null;

            return new CartHeader
            {
                Id = cartHeaderDto.Id,
                UserId = cartHeaderDto.UserId,
                CouponCode = cartHeaderDto.CouponCode
            };
        }

        [return: NotNullIfNotNull("cartItem")]
        public static CartItemDTO? ToDTO(this CartItem? cartItem)
        {
            if (cartItem is null) return null;

            return new CartItemDTO
            {
                Id = cartItem.Id,
                Quantity = cartItem.Quantity,
                ProductId = cartItem.ProductId,
                CartHeaderId = cartItem.CartHeaderId,
                Product = cartItem.Product.ToDTO()
            };
        }

        [return: NotNullIfNotNull("cartItemDto")]
        public static CartItem? ToEntity(this CartItemDTO? cartItemDto)
        {
            if (cartItemDto is null) return null;

            return new CartItem
            {
                Id = cartItemDto.Id,
                Quantity = cartItemDto.Quantity,
                ProductId = cartItemDto.ProductId,
                CartHeaderId = cartItemDto.CartHeaderId,
                Product = cartItemDto.Product.ToEntity()
            };
        }

        [return: NotNullIfNotNull("product")]
        public static ProductDTO? ToDTO(this Product? product)
        {
            if (product is null) return null;

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Namee,
                Price = product.Price,
                Description = product.Description,
                Stock = product.Stock,
                ImageURL = product.ImageURL,
                CategoryName = product.CategoryName
            };
        }

        [return: NotNullIfNotNull("productDto")]
        public static Product? ToEntity(this ProductDTO? productDto)
        {
            if (productDto is null) return null;

            return new Product
            {
                Id = productDto.Id,
                Namee = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                Stock = productDto.Stock,
                ImageURL = productDto.ImageURL,
                CategoryName = productDto.CategoryName
            };
        }
    }
}
