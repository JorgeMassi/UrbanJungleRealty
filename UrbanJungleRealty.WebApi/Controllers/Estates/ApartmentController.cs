using Microsoft.AspNetCore.Mvc;
using UrbanJungleRealty.Application.Dtos.Estates.Apartments;
using UrbanJungleRealty.Application.Interfaces.Estates.Apartments;


namespace UrbanJungleRealty.WebApi.Controllers.Estates
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _service;

        private readonly ILogger _logger;


        public ApartmentController(IApartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApartmentRequestDto apartment)
        {
            return Ok(await _service.Create(apartment));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ApartmentRequestDto apartment)
        {
            return Ok(await _service.Update(apartment));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(ApartmentDeleteRequestDto apartment)
        {
            return Ok(await _service.Delete(apartment));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _service.Delete(id));
        }
    }
}
