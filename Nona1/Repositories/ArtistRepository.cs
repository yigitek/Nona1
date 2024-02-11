using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nona1.Data;
using Nona1.Models;

namespace Nona1.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly NonaDbContext dbContext;
        public ArtistRepository(NonaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Artist>> GetAllAsync()
        {
            var artists = await dbContext.Artists.ToListAsync();
            return artists;
        }

        public async Task<Artist> GetByIdAsync(Guid id)
        {
            var artist = await dbContext.Artists.FindAsync(id);
            return artist;
        }

        public async Task<Artist> CreateAsync(Artist artist)
        {
            await dbContext.Artists.AddAsync(artist);
            await dbContext.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> UpdateAsync(Guid id, Artist artist)
        {
            var existingArtist = await dbContext.Artists.FirstOrDefaultAsync(x => x.Id == id);
            if (existingArtist == null)
            {
                return null;
            }

            existingArtist.Name = artist.Name;
            existingArtist.Description = artist.Description;
            existingArtist.ImageUrl = artist.ImageUrl;
            //existingArtist.Items = artist.Items;
            //existingArtist.Collabs = artist.Collabs;

            await dbContext.SaveChangesAsync();
            return existingArtist;
        }
    }
}
