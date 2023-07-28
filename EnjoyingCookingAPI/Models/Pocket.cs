namespace EnjoyingCookingAPI.Models
{
    public class Pocket
    {
        public Pocket(Guid userId, string userEmail) { 
            UserId = userId;
            Id = Guid.NewGuid();
            UserEmail = userEmail;
            Cash = 0.0M;
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string UserEmail { get; set; }
        public decimal Cash { get; private set; }

    }
}
