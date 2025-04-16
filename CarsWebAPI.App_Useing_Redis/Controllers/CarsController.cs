using CarsWebAPI.App_Useing_Redis.CarService;
using CarsWebAPI.App_Useing_Redis.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsWebAPI.App_Useing_Redis.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CarsController(ICarService carService) : ControllerBase
{
    private readonly ICarService _carService = carService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _carService.GetAll());
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
