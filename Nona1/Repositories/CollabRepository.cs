using Microsoft.EntityFrameworkCore;
using Nona1.Data;
using Nona1.Models;

namespace Nona1.Repositories
{
    public class CollabRepository : ICollabRepository
    {
        private readonly NonaDbContext dbContext;
        public CollabRepository(NonaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Collab>> GetAllAsync()
        {
            var collabs = await dbContext.Collabs.ToListAsync();
            return collabs;
        }

        public async Task<Collab> GetByIdAsync(Guid id)
        {
            var collabs = await dbContext.Collabs.FindAsync(id);
            return collabs;
        }

        public async Task<Collab> CreateAsync(Collab collab)
        {
            await dbContext.Collabs.AddAsync(collab);
            await dbContext.SaveChangesAsync();
            return collab;
        }

        public async Task<Collab> UpdateAsync(Guid id, Collab collab)
        {
            var existingCollab = await dbContext.Collabs.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCollab == null)
            {
                return null;
            }

            existingCollab.Name = collab.Name;
            existingCollab.Description = collab.Description;
            existingCollab.ImageUrl = collab.ImageUrl;
            //existingCollab.Items = collab.Items;
            //existingCollab.Artists = collab.Artists;

            await dbContext.SaveChangesAsync();
            return existingCollab;
        }
    }
}
