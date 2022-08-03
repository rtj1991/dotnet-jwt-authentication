using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProductAPI.Container.Entity;
using ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class TripController : ControllerBase
{
    private readonly ITripContainer _DBContext;
    private readonly travellerContext traveller;

    public TripController(ITripContainer _DBContext, travellerContext _traveller)
    {

        this._DBContext = _DBContext;
        this.traveller = _traveller;
    }

    // [Authorize(Roles = "USERS,USERS,PREMIUM")]
    // [Authorize(Roles = "USERS")]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var trip = await this._DBContext.GetAll();
        return Ok(trip);
    }

    [HttpGet("Test/{id}")]
    public ActionResult<MyTrip> Test(int id)
    {
        // var trip = traveller.MyTrips.Include(b => b.Place).ToList();
        var my_trips =  traveller.MyTrips.Include(m=>m.Place).Where(m=>m.Id==id);
        return Ok(my_trips);
    }


    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var trip = await this._DBContext.GetById(id);
        return Ok(trip);
    }

    // [Authorize(Roles = "ADMIN,PREMIUM")]
    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var my_trip = await this._DBContext.Remove(id);
        return Ok(true);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(MyTrip mytrip)
    {
        await this._DBContext.Save(mytrip);
        return Ok(true);
    }

    [HttpPost("Edit/{id}")]
    public async Task<IActionResult> Edit(int id, MyTrip mytrip)
    {
        var my_trip = await this._DBContext.Edit(id, mytrip);
        return Ok(true);
    }

}
