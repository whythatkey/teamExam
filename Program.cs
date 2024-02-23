using FryingPanParser;

Console.WriteLine("Welcome to frying pan parser from Rozetka");
var data = new DataBase();
data.InitializeTables();
var m1 = new Manufacturer("Los");
var fp1 = new FryingPan(1, "Krutaya", 15000);
data.AddManufacturer(m1);
data.AddFryingPan(fp1);