using Microsoft.VisualBasic;

namespace EnjoyingCookingAPI.Models
{
    public class User
    {
        public User(string email, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
        }

        public User(string userName, string email, string password) 
            : this(email, password)
        {
            UserName = userName;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? FullName { get; set; }
        public short? Age { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool EmailConfirmed { get; set; }
        public ICollection<CookingRecipe> Recipes { get; set; }
        public Guid? PocketId { get; set; }
        public Pocket? Pocket { get; set; }
        public string? Token { get; set; }
    }
}
