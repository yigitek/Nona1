using Nona1.Models;

namespace Nona1.Repositories
{
    public interface IItemRepository
    {
        public Task<List<Item>> GetAllAsync();
        public Task<Item> GetByIdAsync(Guid id);
        public Task<Item> CreateAsync(Item item);
        public Task<Item> UpdateAsync(Guid id, Item item);
    }
}
