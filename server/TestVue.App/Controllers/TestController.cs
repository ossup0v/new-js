using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TestVue.InternalApi.Models;
using TestVue.InternalApi.Repositories;

namespace TestVue.Controllers;

[ApiController()]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly ISpendingRepository _spendingRepository;

    public TestController(ILogger<TestController> logger, ISpendingRepository spendingRepository)
    {
        _logger = logger;
        _spendingRepository = spendingRepository;
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
    
    
    [HttpPost("new-spending")]
    public Task ReceiveNewSpending([FromBody] SpendingModel newSpending)
    {
        newSpending.Id = Guid.NewGuid().ToString();
        newSpending.CreationTime = DateTime.UtcNow;
        newSpending.UserId = "1";
        _logger.LogInformation(JsonSerializer.Serialize(newSpending));
        return _spendingRepository.Set(newSpending);
    }

    private static readonly List<string> Categories = new List<string>()
    {
        "Grocery",
        "Taxes",
        "Rent"
    };
    [HttpPost("generate-new-spending")]
    public Task GenerateNewSpending()
    {
        var r = Random.Shared;
        var newSpending = new SpendingModel
        {
            Id = Guid.NewGuid().ToString(),
            UserId = "1",
            CreationTime = DateTime.UtcNow.AddDays(r.Next(-5, 0)),
            Category = Categories[r.Next(Categories.Count)],
            SpendAmount = new Money() { Amount = r.Next(50, 10000), Currency = "RUB" },
        };
        _logger.LogInformation(JsonSerializer.Serialize(newSpending));
        return _spendingRepository.Set(newSpending);
    }

    [HttpGet("get-spendings")]
    public async Task<SpendingModel[]> GetSpendings()
    {
        var arr = (await _spendingRepository.GetAll());
        Array.Sort(arr,
            (x, y) => x.CreationTime.Value.CompareTo(y.CreationTime.Value));
        return arr;
    }
}