using Inventory.Context;
using Inventory.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using TestesAPI.Models;

namespace Inventory.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        // Adiciona um novo produto
        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            return product;
        }

        // Retorna todos os produtos
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // Busca um produto pelo ID 
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Busca um produto pelo nome 
        public async Task<Product?> GetByNameAsync(string name)
        {
            return await _context.Products
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Name == name);
        }

        // Atualiza o produto 
        public Product Update(Product product)
        {
            _context.Products.Update(product);
            return product;
        }

        // Remove um produto pelo ID se existir
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            return true;
        }
    }
}
