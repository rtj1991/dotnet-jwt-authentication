using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProductAPI.Container.Entity;

namespace ProductAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class TripController : ControllerBase
{
    private readonly ITripContainer _DBContext;

    public TripController(ITripContainer _DBContext)
    {

        this._DBContext = _DBContext;
    }

    // [Authorize(Roles = "USERS,USERS,PREMIUM")]
    [Authorize(Roles = "USERS")]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var trip = await this._DBContext.GetAll();
        return Ok(trip);
    }


    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var trip = await this._DBContext.GetById(id);
        return Ok(trip);
    }

    [Authorize(Roles = "ADMIN,PREMIUM")]
    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var my_trip = await this._DBContext.Remove(id);
        return Ok(true);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] TripEntity tripEntity)
    {
        await this._DBContext.Save(tripEntity);
        return Ok(true);
    }

}
