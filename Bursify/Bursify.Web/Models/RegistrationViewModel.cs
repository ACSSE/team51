using Bursify.Data.EF.User;

namespace Bursify.Web.Models
{
    public class RegistrationViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserEmail { get; set; }
        public string UserType { get; set; }

/*        public RegistrationViewModel(BursifyUser user)
        {
            Username = user.Name;
            Password = user.PasswordHash;
            UserEmail = user.Email;
            UserType = user.UserType;
        }*/

    }
}