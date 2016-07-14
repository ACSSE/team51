using Bursify.Entities;
using Bursify.Entities.UserEntities;
using Bursify.Services.Utilitities;
using System.Collections.Generic;

namespace Bursify.Services.Abstract
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string email, string password);
        BursifyUser CreateUser(string username, string email, string password, string type);
        BursifyUser GetUser(int userId);
       
    }
}
