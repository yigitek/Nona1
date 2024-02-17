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
    public class ItemsController : ControllerBase
    {
        private readonly NonaDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;

        public ItemsController(NonaDbContext dbContext, IMapper mapper,
    IItemRepository itemRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await itemRepository.GetAllAsync();

            return Ok(mapper.Map<List<ItemDTO>>(items));
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var item = await itemRepository.GetByIdAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ItemDTO>(item));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddItemRequestDTO
            addItemRequestDTO)
        {
            var item = mapper.Map<Item>(addItemRequestDTO);

            await itemRepository.CreateAsync(item);

            var itemDTO = mapper.Map<ItemDTO>(item);

            return CreatedAtAction(nameof(GetById), new { id = itemDTO.Id }, itemDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,
            [FromBody] AddItemRequestDTO updatItemRequestDTO)
        {
            var itemToUpdate = mapper.Map<Item>(updatItemRequestDTO);

            var item = await itemRepository.UpdateAsync(id, itemToUpdate);
            if (item == null)
            {
                return NotFound();
            }

            var itemDTO = mapper.Map<ItemDTO>(item);

            return Ok(itemDTO);
        }
    }
}
