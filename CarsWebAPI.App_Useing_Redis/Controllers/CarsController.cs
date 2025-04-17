using CarsWebAPI.App_Useing_Redis.Caching;
using CarsWebAPI.App_Useing_Redis.CarService;
using CarsWebAPI.App_Useing_Redis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsWebAPI.App_Useing_Redis.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarsController(ICarService carService,IRedisCacheService cache) : ControllerBase
{
    private readonly ICarService _carService = carService;
    private readonly IRedisCacheService _cache = cache;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cars = _cache?.GetData<IEnumerable<Car>>("Cars");

        if (cars is not null)
            return Ok(cars);

        cars = await _carService.GetAll();

        _cache?.SetData("Cars", cars);

        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _carService.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddNew([FromBody] Car car)
    {
        return Ok(await _carService.AddNew(car));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Car car)
    {
        return Ok(await _carService.Update(id,car));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await _carService.Delete(id));
    }
}
