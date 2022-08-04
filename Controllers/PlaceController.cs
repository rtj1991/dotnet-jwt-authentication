using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using ProductAPI.Container.Entity;

namespace ProductAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PlaceController : ControllerBase
{
    private readonly travellerContext _DBContext;
    private readonly IPlaceContainer placeContainer;


    public PlaceController(travellerContext _DBContext, IPlaceContainer _placeContainer)
    {

        this._DBContext = _DBContext;
        this.placeContainer = _placeContainer;
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var places = await this.placeContainer.GetAll();

        return Ok(places);
    }


    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var place = await this.placeContainer.GetById(id);
        return Ok(place);
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        var place = await this.placeContainer.Remove(id);
        return Ok(true);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(Places places)
    {
        await this.placeContainer.Save(places);
        return Ok(true);
    }

    [HttpPost("Edit/{id}")]
    public async Task<IActionResult> Edit(int id, Places places)
    {

        var my_trip = await this.placeContainer.Edit(id, places);
        return Ok(true);
    }

}
