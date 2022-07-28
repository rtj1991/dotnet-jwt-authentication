using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using Microsoft.AspNetCore.Authorization;
using ProductAPI.Container.Entity;

namespace ProductAPI.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductContainer _DBContext;

    public ProductController(IProductContainer _DBContext)
    {

        this._DBContext = _DBContext;
    }

     [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var trip =await this._DBContext.GetAll();
        return Ok(trip);
    }


    // [HttpGet("GetById/{id}")]
    // public IActionResult GetById(int id)
    // {
    //     var my_trips = this._DBContext.MyTrips.FirstOrDefault(o => o.Id == id);
    //     return Ok(my_trips);
    // }


    // [HttpDelete("remove/{id}")]
    // public IActionResult remove(int id)
    // {
    //     var my_trips = this._DBContext.MyTrips.FirstOrDefault(o => o.Id == id);

    //     if (my_trips != null)
    //     {
    //         this._DBContext.Remove(my_trips);
    //         this._DBContext.SaveChanges();
    //         return Ok(true);
    //     }
    //     return Ok(my_trips);
    // }

    // [HttpPost("create")]
    // public IActionResult create([FromBody] MyTrip myTrip)
    // {

    //     var my_trips = this._DBContext.MyTrips.FirstOrDefault(o => o.Id == myTrip.Id);
    //     if (my_trips != null)
    //     {
    //         my_trips.Location = myTrip.Location;
    //         my_trips.Description = myTrip.Description;
    //         my_trips.StartDate = myTrip.StartDate;
    //         my_trips.EndDate = myTrip.EndDate;
    //         this._DBContext.SaveChanges();
    //     }
    //     else
    //     {
    //         this._DBContext.MyTrips.Add(myTrip);
    //         this._DBContext.SaveChanges();

    //     }
    //     return Ok(true);
    // }

}
