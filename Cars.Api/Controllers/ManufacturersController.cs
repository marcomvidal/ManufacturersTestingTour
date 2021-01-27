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
        private readonly ILogger<ManufacturersController> _logger;
        private readonly IManufacturersService _service;

        public ManufacturersController(ILogger<ManufacturersController> logger, IManufacturersService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var manufacturer = await _service.GetById(id);

            if (manufacturer == null)
                return NotFound();

            return Ok(manufacturer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Manufacturer manufacturer)
        {
            await _service.Save(manufacturer);
            
            return CreatedAtAction(nameof(Post), manufacturer);
        }
    }
}