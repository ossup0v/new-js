namespace TestVue.InternalApi.Models;

public class TestModel : IObjectWithId<string>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}