namespace FryingPanParser;

public class FryingPan
{
    public int Id { get; set; }
    public int ManufacturerId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public FryingPan() { }
    public FryingPan ( int manufacturerId, string name, int price)
    {
        ManufacturerId = manufacturerId;
        Name = name;
        Price = price;
    }
}
