using AutoMapper;
using Nona1.DTOs;
using Nona1.Models;

namespace Nona1.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Artist, ArtistDTO>().ReverseMap();
            CreateMap<Artist, AddArtistRequestDTO>().ReverseMap();
            CreateMap<Collab, CollabDTO>().ReverseMap();
            CreateMap<Collab, AddCollabRequestDTO>().ReverseMap();
        }
        
    }
}
