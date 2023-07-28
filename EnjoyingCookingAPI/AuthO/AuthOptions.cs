using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EnjoyingCookingAPI.AuthO
{
    public class AuthOptions
    {
        public const string ISSUER = "EnjoyingCookingServer";
        public const string AUDIENCE = "EnjoyingCookingClient";
        const string KEY = "c00k1ngrec1pe_f0ra11";
        public static SymmetricSecurityKey GetSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
