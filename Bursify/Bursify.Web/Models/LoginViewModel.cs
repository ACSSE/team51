using Bursify.Data.EF.User;

namespace Bursify.Web.Models
{
    public class LoginViewModel
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        /*public LoginViewModel(BursifyUser user)
        {
            UserEmail = user.Email;
            Password = user.PasswordHash;
            UserType = user.UserType;
        }*/
    }
}