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
public class UserController : ControllerBase
{
    private readonly travellerContext _DBContext;
    private readonly JwtSetting jwtSetting;

    public UserController(travellerContext _DBContext, IOptions<JwtSetting> options)
    {

        this._DBContext = _DBContext;
        this.jwtSetting = options.Value;
    }

    [HttpPost("Authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] UserCread userCread)
    {
        var user = await this._DBContext.Users.FirstOrDefaultAsync(item => item.Email == userCread.Username && item.Password == userCread.Password);

        if (user == null)
            return Unauthorized();

        var tokenhandler = new JwtSecurityTokenHandler();

        var tokenkey = Encoding.UTF8.GetBytes(this.jwtSetting.securitykey);
        var tokendesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
            new Claim[] { new Claim(ClaimTypes.Name, user.Email), new Claim(ClaimTypes.Role, user.Role) }
          ),
            Expires = DateTime.Now.AddSeconds(20),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenhandler.CreateToken(tokendesc);
        var finaltoken = tokenhandler.WriteToken(token);

        return Ok(finaltoken);
    }


}
