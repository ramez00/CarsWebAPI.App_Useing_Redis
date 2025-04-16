using CarsWebAPI.App_Useing_Redis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CarsWebAPI.App_Useing_Redis.CarService;

public class CarService(ApplicationDbContext dbContext) : ICarService
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    public async Task<int> AddNew(Car car)
    {
        await _dbContext.Cars.AddAsync(car);
        await _dbContext.SaveChangesAsync();

        return car.Id;
    }

    public async Task<int> Delete(int id)
    {
        var car = await _dbContext.Cars.FindAsync(id);
        if(car is null)
            return 0;

        _dbContext.Cars.Remove(car);
        await _dbContext.SaveChangesAsync();
        return 1;
    }

    public async Task<IEnumerable<Car>> GetAll()
    {
        return await _dbContext.Cars.ToListAsync();
    }

    public Task<Car?> GetById(int id)
    {
        var car = _dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
        
        if (car is null)
            return Task.FromResult<Car?>(null);

        return car;
    }

    public async Task<int> Update(int id, Car car)
    {
        var existingCar = await _dbContext.Cars.FirstOrDefaultAsync(c => c.Id == id);
        
        if (existingCar is null)
            return 0;

        existingCar.Model = car.Model;
        existingCar.Color = car.Color;
        existingCar.Year = car.Year;

        _dbContext.Cars.Update(existingCar);
        await _dbContext.SaveChangesAsync();

        return 1;
    }
}
