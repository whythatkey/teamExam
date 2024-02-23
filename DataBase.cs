using Microsoft.Data.Sqlite;
using System.Data;

namespace FryingPanParser;

public class DataBase
{
    private readonly string _dataBaseName = "Database.db";
    private readonly SqliteConnection _connection;
    private readonly SqliteCommand _command;
    public DataBase()
    {
        _connection = new SqliteConnection($"Data source = {_dataBaseName}");
        _command = _connection.CreateCommand();
        _connection.Open();
    }
    public void CreateManufacturerTable()
    {
        _command.CommandText =
            @"
                CREATE TABLE IF NOT EXISTS Manufacturers
                (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL
                )
            ";
        _command.ExecuteNonQuery();
    }
    public void CreateFryingPansTable()
    {
        _command.CommandText =
            @"
             CREATE TABLE IF NOT EXISTS FryingPans
             (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                manufacturer_id INTEGER,
                name TEXT NOT NULL,
                price INTEGER NOT NULL,
                FOREIGN KEY (manufacturer_id) REFERENCES Manufacturers(id)
             )
        ";
        _command.ExecuteNonQuery();
    }
    public void InitializeTables()
    {
        CreateManufacturerTable();
        CreateFryingPansTable();
    }

    public void AddManufacturer(Manufacturer manufacturer)
    {
        _command.CommandText =
            $@"
                INSERT INTO Manufacturers(name) VALUES ('{manufacturer.Name}');
            ";
        _command.ExecuteNonQuery();
    }
    public void AddFryingPan(FryingPan pan)
    {
        _command.CommandText =
        $@"
                INSERT INTO FryingPans(manufacturer_id, name, price) VALUES ({pan.ManufacturerId}, '{pan.Name}', {pan.Price});
            ";
        _command.ExecuteNonQuery();
    }
    public void PushManufacturers(IEnumerable<Manufacturer> manufacturers)
    {
        foreach (Manufacturer manufacturer in manufacturers)
        {
            AddManufacturer(manufacturer);
        }
        Console.WriteLine("Manufacturer's push complete!");
    }
    public void PushFryingPans(IEnumerable<FryingPan> fryingPans)
    {
        foreach(FryingPan fryingPan in fryingPans)
        {
            AddFryingPan(fryingPan);
        }
        Console.WriteLine("Frying pan's push complete!");
    }
}
