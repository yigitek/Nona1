using Nona1.Models;

namespace Nona1.Repositories
{
    public interface ICollabRepository
    {
        public Task<List<Collab>> GetAllAsync();
        public Task<Collab> GetByIdAsync(Guid id);
        public Task<Collab> CreateAsync(Collab collab);
        public Task<Collab> UpdateAsync(Guid id, Collab collab);
    }
}
