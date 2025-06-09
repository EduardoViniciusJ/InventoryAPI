using Inventory.Context;

namespace Inventory.Repositories.Interface
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; } 
        IProductRepository ProductRepository { get; }
        Task CommitAsync();
        void Dispose();
    }
}
