using Microsoft.AspNetCore.Mvc;

namespace PracticeWebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{

    private readonly ILogger<PingController> _logger;

    public PingController(ILogger<PingController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ping))]
    public IActionResult Ping(string name)
    {
        var pingMessage= new Ping { Message = $"Hello {name}" };
        return Ok(pingMessage);
    }
}
