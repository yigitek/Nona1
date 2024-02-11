using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nona1.Data;
using Nona1.DTOs;
using Nona1.Models;
using Nona1.Repositories;

namespace Nona1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly NonaDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IArtistRepository artistRepository;

        public ArtistsController(NonaDbContext dbContext, IMapper mapper,
            IArtistRepository artistRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.artistRepository = artistRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var artists = artistRepository.GetAllAsync();

            return Ok(mapper.Map<List<ArtistDTO>>(artists));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var artist = artistRepository.GetByIdAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ArtistDTO>(artist)); 
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddArtistRequestDTO addArtistRequestDTO)
        {
            var artist = mapper.Map<Artist>(addArtistRequestDTO);

            artistRepository.CreateAsync(artist);

            var artistDto = mapper.Map<ArtistDTO>(artist);

            return CreatedAtAction(nameof(GetById), new {id = artistDto.Id}, artistDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
            [FromBody] AddArtistRequestDTO updateArtistRequestDTO)
        {
            var artistToUpdate = mapper.Map<Artist>(updateArtistRequestDTO);

            var artist = await artistRepository.UpdateAsync(id, artistToUpdate);
            if (artist == null)
            {
                return NotFound();
            }

            var artistDTO = mapper.Map<ArtistDTO>(artist);

            return Ok(artistDTO);
        }
    }
}
