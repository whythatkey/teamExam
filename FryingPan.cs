namespace FryingPanParser;

public class FryingPan
{
    public int Id { get; set; }
    public int ManufacturerId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }

    public FryingPan() { }
    public FryingPan ( string name, int price)
    {
       
        Name = name;
        Price = price;
        ManufacturerId = 1;
    }
}
