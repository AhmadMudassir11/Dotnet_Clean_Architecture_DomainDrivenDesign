using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers
{
    [Route("[controller]")]

    public class DinnersController : ApiController
    {

        [HttpGet]
        public IActionResult ListDinners()
        {
            return Ok("Sekai wa itamai o shirudarou, SHINRA TENSEI");
        }
    }
}
