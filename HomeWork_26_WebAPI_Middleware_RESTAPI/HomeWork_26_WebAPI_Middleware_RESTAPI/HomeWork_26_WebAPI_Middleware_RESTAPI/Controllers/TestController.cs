using Microsoft.AspNetCore.Mvc;

namespace HomeWork_26_WebAPI_Middleware_RESTAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Web API!");
        }
    }
}