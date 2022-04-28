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

    [HttpGet(Name = "GetPing")]
    public Ping Get()
    {
        return new Ping { Message = "Hello" };

    }
}
