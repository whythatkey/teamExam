namespace FryingPanParser;

public class FryingPan
{
    public int Id { get; set; }
    public int ManufacturerId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public FryingPan() { }
    public FryingPan (int id, int manufacturerId, string name, int price)
    {
        Id = id;
        ManufacturerId = manufacturerId;
        Name = name;
        Price = price;
    }
}
