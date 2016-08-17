using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Models
{
    public class AdminUserReport
    {
        public int NumberOfRegisteredUsers { get; set; }
        public int NumberOfInactiveUsers { get; set; }
        public int RegisteredStudents { get; set; }
        public int RegisteredSponsors { get; set; }

        public AdminUserReport()
        {
        }

        public AdminUserReport(int numberOfRegisteredUsers, int numberOfInactiveUsers, int registeredStudents, int registeredSponsors)
        {
            NumberOfRegisteredUsers = numberOfRegisteredUsers;
            NumberOfInactiveUsers = numberOfInactiveUsers;
            RegisteredStudents = registeredStudents;
            RegisteredSponsors = registeredSponsors;
        }


    }
}