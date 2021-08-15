using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LotteryApi.Controllers
{
    [Route("api/[controller]")]
    public class LotteryController : Controller
    {
        public LotteryController()
        {

        }

        [HttpGet("Load")]
        [SwaggerOperation(Summary = "Load lottery data based on lottery name", Description = "This is a description examples")]
        public IActionResult Load(string lotteryName)
        {
            //TODO:
            return Ok("Ok");
        }
    }
}
