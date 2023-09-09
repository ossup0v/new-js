namespace TestVue.InternalApi.Models;

public class SpendingModel : IObjectWithId<string>
{
    public string? Id { get; set; }
    public string? UserId { get; set; }
    public Money? SpendAmount { get; set; }
    public string? Category { get; set; }
    public string? SubCategory { get; set; }
    public string[]? Tags { get; set; }
    public DateTime? CreationTime { get; set; }
    /// <summary>
    /// Перевод, оплата картой, наличный рассчет
    /// </summary>
    public string? SpendingType { get; set; }
    public string? Comment { get; set; }
}