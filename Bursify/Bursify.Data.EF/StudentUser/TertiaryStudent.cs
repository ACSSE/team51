using Bursify.Data.EF;
using Bursify.Data.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bursify.Data.StudentUser
{
    public class TertiaryStudent
    {
        public int BursifyUserId { get; set; }
        public string SchoolName { get; set; }
        public string StudyField { get; set; }
        public int CurrentStudyYear { get; set; }
        public SchoolType SchoolType { get; set; }
    }
}
