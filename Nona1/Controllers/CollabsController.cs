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
    public class CollabsController : ControllerBase
    {
        private readonly NonaDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ICollabRepository collabRepository;

        public CollabsController(NonaDbContext dbContext, IMapper mapper,
            ICollabRepository collabRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.collabRepository = collabRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var collabs = await collabRepository.GetAllAsync();

            return Ok(mapper.Map<List<CollabDTO>>(collabs));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var collab = await collabRepository.GetByIdAsync(id);

            if (collab == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<CollabDTO>(collab));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCollabRequestDTO addCollabDto)
        {
            var collab = mapper.Map<Collab>(addCollabDto);

            await collabRepository.CreateAsync(collab);

            var collabDTO = mapper.Map<CollabDTO>(collab);

            return CreatedAtAction(nameof(GetById), new { id = collabDTO.Id }, collabDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
        [FromBody] CollabDTO updateCollabDTO)
        {
            var collabToUpdate = mapper.Map<Collab>(updateCollabDTO);

            var collab = await collabRepository.UpdateAsync(id, collabToUpdate);
            if (collab == null)
            {
                return NotFound();
            }

            var collabDTO = mapper.Map<CollabDTO>(collab);

            return Ok(collabDTO);
        }
    }
}
