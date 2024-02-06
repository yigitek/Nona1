using Nona1.Models;

namespace Nona1.Repositories
{
    public interface IArtistRepository
    {
        public Task<List<Artist>> GetAllAsync();
        public Task<Artist> GetByIdAsync(Guid id);
        public Task<Artist> CreateAsync(Artist artist);
        //public Task<Artist> UpdateAsync(Guid id, Artist artist); 
        //burdan bunu yazdin gercegini de yaz devam
    }
}
