namespace CarsWebAPI.App_Useing_Redis.Models;

public class Car
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
}
