using EnjoyingCookingAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnjoyingCookingAPI.Controllers
{
    [Route("")]
    [ApiController]
    [Authorize]
    public class CookingsController : ControllerBase
    {
        [HttpGet("/getcookings")]
        public async Task<IResult> GetCookings()
        {
            List<CookingRecipe> recipes; 
            using (CookingContext db = new CookingContext())
            {
                recipes = await db.Recipes.ToListAsync();                
            }
            return Results.Json(recipes);
        }

        [HttpGet("/getusercookings")]
        public async Task<IResult> GetUserCookings(User user)
        {
            List<CookingRecipe> recipes;
            using (CookingContext db = new CookingContext())
            {
                recipes = db.Users.Find(user)!.Recipes.ToList();
            }
            return Results.Json(recipes);
        }

        [HttpPost("/addcooking")]
        public async Task<IResult> AddCooking(string email, CookingRecipe recipe)
        {
            using (CookingContext db = new CookingContext())
            {
                db.Users.Where(u => u.Email == email).FirstOrDefault()!.Recipes.Add(recipe);
                db.SaveChanges();
            }
            return Results.Json(recipe);
        }
    }
}
