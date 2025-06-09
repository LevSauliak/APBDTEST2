using APBDTEST2.Data.Models;
using APBDTEST2.DTOs;
using APBDTEST2.Excetpions;
using APBDTEST2.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APBDTEST2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController: ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet("{id}/purchases")]
        public async Task<IActionResult> GetPurchases(int id)
        {
            try
            {
                var purchases = await _customerService.GetCustomerPurchases(id);
                return Ok(purchases);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerWithPurchases([FromBody] CustomerWithPurchasesDto dto)
        {
            try
            {
                await _customerService.AddCustomerWithPurchases(dto);
                return CreatedAtAction("AddCustomerWithPurchases", dto);
            }
            catch (ConflictException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
            
        }
        
        
    }
}
