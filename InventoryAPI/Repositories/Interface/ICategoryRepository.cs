using TestesAPI.Models;

namespace Inventory.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync(); 
        Task<Category?> GetByIdAsync(int id); 
        Task<Category?> GetByNameAsync(string name);
        Task<Category> CreateAsync(Category category);
        Category Update(Category category); 
        Task<bool> DeleteAsync(int id);
    }
}
