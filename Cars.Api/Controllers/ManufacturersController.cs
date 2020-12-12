using System.Threading.Tasks;
using Cars.Api.Services;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cars.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManufacturersController : ControllerBase
    {
        readonly ILogger<ManufacturersController> logger;
        readonly IManufacturersService service;

        public ManufacturersController(ILogger<ManufacturersController> logger, IManufacturersService service)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => Ok(await this.service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var manufacturer = await this.service.GetById(id);

            if (manufacturer == null)
                return NotFound();

            return Ok(manufacturer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Manufacturer manufacturer)
        {
            await this.service.Save(manufacturer);
            
            return CreatedAtAction(nameof(Post), manufacturer);
        }
    }
}