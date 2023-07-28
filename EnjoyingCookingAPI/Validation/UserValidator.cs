using System.Text.RegularExpressions;

namespace EnjoyingCookingAPI.Validation
{
    public class UserValidator
    {
        public bool CheckEmailLength(string email)
        {
            if (email.Length > 30) return false;
            return true;
        }
        public bool CheckEmailPattern(string email)
        {
            string pattern = "[a-z](@gmail.com)";
            Regex regex = new Regex(pattern);

            return regex.Match(email).Success;
        }

        public bool CheckPasswordPattern(string password)
        {
            string pattern = "^[a-zA-Z0-9.]+$";
            Regex regex = new Regex(pattern);

            return regex.Match(password).Success;
        }
        public bool CheckPasswordLength(string password)
        {
            if (password.Length < 8) return false;
            return true;
        }
    }
}
