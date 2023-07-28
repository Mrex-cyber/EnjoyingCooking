using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace EnjoyingCookingAPI.Models
{
    public class CookingRecipe
    {
        public CookingRecipe(string title, string difficulty, int nearestCost, int price) { 
            Id = Guid.NewGuid();
            Title = title;
            Description = "No description";
            Difficulty = difficulty;
            NearestCost = nearestCost;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Difficulty { get; set; }
        public int NearestCost { get; set; }
        public int Price { get; set; }
    }
}
