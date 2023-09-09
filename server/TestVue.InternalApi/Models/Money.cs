namespace TestVue.InternalApi.Models;

public record struct Money
{
    public string Currency { get; set; }
    public long Amount { get; set; }
}