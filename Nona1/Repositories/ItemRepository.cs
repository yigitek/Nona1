using Microsoft.EntityFrameworkCore;
using Nona1.Data;
using Nona1.Models;

namespace Nona1.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly NonaDbContext dbContext;
        public ItemRepository(NonaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Item>> GetAllAsync()
        {
            var items = await dbContext.Items.ToListAsync();
            return items;
        }

        public async Task<Item> GetByIdAsync(Guid id)
        {
            var items = await dbContext.Items.FindAsync(id);
            return items;
        }

        public async Task<Item> CreateAsync(Item item)
        {
            await dbContext.Items.AddAsync(item);
            await dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateAsync(Guid id, Item item)
        {
            var existingItem = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (existingItem == null)
            {
                return null;
            }

            existingItem.Name = item.Name;
            existingItem.Description = item.Description;
            existingItem.ImageUrl = item.ImageUrl;
            existingItem.Category = item.Category;
            existingItem.Price = item.Price;
            //existingItem.Collabs = item.Collab;

            await dbContext.SaveChangesAsync();
            return existingItem;
        }
    }
}
