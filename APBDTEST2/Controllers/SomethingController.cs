using APBDTEST2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APBDTEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomethingController : ControllerBase
    {
        private readonly ISomethingService _somethingService;

        public SomethingController(ISomethingService somethingService)
        {
            _somethingService = somethingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
