using Inventory.Context;
using Inventory.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using TestesAPI.Models;

namespace Inventory.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        // Adiciona uma nova categoria
        public async Task<Category> CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            return category;
        }

        // Retorna todas as categorias
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // Busca uma categoria pelo ID
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Busca uma categoria pelo nome 
        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(x => x.Name == name);
        }

        // Marca a categoria como atualizada no contexto
        public Category Update(Category category)
        {
            _context.Categories.Update(category);
            return category;
        }

        // Remove uma categoria pelo ID se existir
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            return true;
        }

    }
}
