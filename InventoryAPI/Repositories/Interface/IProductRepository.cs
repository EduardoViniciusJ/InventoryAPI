﻿using TestesAPI.Models;

namespace Inventory.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetByNameAsync(string name);
        Task<Product> CreateAsync(Product product);
        Product Update(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
