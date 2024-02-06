using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nona1.Models;

namespace Nona1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var artists = new List<Artist>
            {
                new Artist
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Testesterone",
                    Description="Test guy",
                    ImageUrl="null",
                },
                new Artist
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Testa",
                    Description="Test guy",
                    ImageUrl="null",
                },
                new Artist
                {
                    Id = Guid.NewGuid(),
                    Name = "Testo Testarr",
                    Description="Test guy",
                    ImageUrl="null",
                }
            };
            return Ok(artists);
        }
    }
}
