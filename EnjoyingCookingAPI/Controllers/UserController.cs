using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EnjoyingCookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using EnjoyingCookingAPI.AuthO;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Collections;
using System.Text;

namespace EnjoyingCookingAPI.Controllers
{        
    [Route("")]
    [ApiController]

    public class UserController : ControllerBase
    {        
        [HttpPost("/signin")]
        public async Task<IResult> GetUserSignIn()
        {
            var json = String.Empty;
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                json = await reader.ReadToEndAsync();
            }
            

            UserData data = JsonSerializer.Deserialize<UserData>(json)!;
            

            User? user = new User(data.email, data.password);

            using (CookingContext db = new CookingContext())
            {
                user = db.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();

                if (user != null)
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };
                    var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                        signingCredentials: new SigningCredentials(AuthOptions.GetSecurityKey(), SecurityAlgorithms.HmacSha256));
                    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                    user.Token = encodedJwt;
                    return Results.Json(user.Token);
                }
                else return Results.NotFound();
                
            }
        }        

        [HttpPost("/signup")]
        public async Task<IResult> GetUserSignUp()
        {
            var json = String.Empty;
            using (StreamReader reader = new StreamReader(Request.Body))
            {
                json = await reader.ReadToEndAsync();
            }


            UserData data = JsonSerializer.Deserialize<UserData>(json)!;

            User? user = new User(data.userName!, data.email, data.password);

            using (CookingContext db = new CookingContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return Results.Ok();
            }
        }


        record class UserData(string? userName, string email, string password);
    }
}
