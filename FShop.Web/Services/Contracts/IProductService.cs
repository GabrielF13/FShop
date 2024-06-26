﻿using FShop.Web.Models;
using System.Globalization;

namespace FShop.Web.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAllProducts(string token);
        Task<ProductViewModel> FindProductById(int id, string token);
        Task<ProductViewModel> CreateProduct(ProductViewModel productVM, string token);
        Task<ProductViewModel> UpdateProduct(ProductViewModel productVM, string token);
        Task<bool> DeleteProduct(int id, string token);
    }
}
