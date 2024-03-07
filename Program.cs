using FryingPanParser;
using System.Net.WebSockets;

Console.WriteLine("Welcome to frying pan parser from Rozetka");
var data = new DataBase();
var parcer = new RozetkaParcer();
data.InitializeTables();
data.PushManufacturers(parcer.ManufacturerParcer());
data.PushFryingPans(parcer.FryingPanParcer());