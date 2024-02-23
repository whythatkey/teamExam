namespace FryingPanParser;

public class Manufacturer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Manufacturer() { }
    public Manufacturer(string name)
    {
        Name = name;
    }
}
