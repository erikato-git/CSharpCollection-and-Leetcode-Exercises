using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_WebAPI.Services;

namespace MongoDB_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DriverService _driverService;

        public DriversController(DriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var existingDriver = _driverService.GetAsync(id);

            if(existingDriver != null)
            {
                return NotFound();
            }

            return Ok(existingDriver);
        }




    }
}
