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


    public PlaceController(travellerContext _DBContext,IPlaceContainer _placeContainer)
    {

        this._DBContext = _DBContext;
        this.placeContainer=_placeContainer;
    }
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var places=this.placeContainer.GetAll();
        
        return Ok(places);
    }

    [HttpGet("GetById/{id}")]
    public IActionResult GetById(int id)
    {
        var place=this.placeContainer.GetById(id);
    }

}
