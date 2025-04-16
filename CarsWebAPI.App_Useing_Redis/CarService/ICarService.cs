using CarsWebAPI.App_Useing_Redis.Models;
using System.ComponentModel;

namespace CarsWebAPI.App_Useing_Redis.CarService;

public interface ICarService
{
    Task<IEnumerable<Car>> GetAll();
    Task<int> AddNew(Car car);
    Task<Car?> GetById(int id);
    Task<int> Update(int id, Car car);
    Task<int> Delete(int id);
}
