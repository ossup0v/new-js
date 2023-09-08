using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TestVue.InternalApi.Models;
using TestVue.InternalApi.Repositories;

namespace TestVue.Controllers;

[ApiController()]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly ITestRepository _testRepository;

    public TestController(ILogger<TestController> logger, ITestRepository testRepository)
    {
        _logger = logger;
        _testRepository = testRepository;
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

    [HttpPost("post-test-object")]
    public Task PostTestModel([FromBody] TestModel testModel)
    {
        _logger.LogInformation(JsonSerializer.Serialize(testModel));
        return _testRepository.Set(testModel);
    }
    
    [HttpGet("get-all-test-object")]
    public Task<TestModel[]> GetTestModel()
    {
        return _testRepository.GetAll();
    }
}