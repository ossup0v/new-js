using Microsoft.AspNetCore.Mvc;

namespace TestVue.Controllers;

[ApiController()]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
        logger.LogInformation("YYYY");
    }
    
    [HttpGet("get")]
    public string Get()
    {
        return "test";
    }
    
    [HttpPost("post-string")]
    public string ReceiveString([FromBody] string str)
    {
        _logger.LogInformation($"Received: {str}");
        return "response";
    }
}