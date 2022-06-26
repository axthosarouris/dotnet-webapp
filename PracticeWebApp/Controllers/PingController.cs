namespace PracticeWebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {

        private readonly ILogger<PingController> logger;

        public PingController(ILogger<PingController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ping))]
        public IActionResult Ping(string name)
        {
            var pingMessage = new Ping { Message = $"Hello {name}" };
            return this.Ok(pingMessage);
        }
    }
}
