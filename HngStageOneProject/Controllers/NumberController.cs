using HngStageOneProject.Models;
using HngStageOneProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace HngStageOneProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NumberController : ControllerBase
    {
        private readonly INumberService _numberService;

        public NumberController(INumberService numberService)
        {
            _numberService = numberService;
        }

        [HttpGet("classify-number")]
        public async Task<IActionResult> ClassifyNumber([FromQuery] string number)
        {
            if (!int.TryParse(number, out int num) || num < 0)
            {
                return BadRequest(new { number, error = true, message = "Invalid number. Must be a non-negative integer." });
            }

            var response = await _numberService.ClassifyNumber(num);
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
