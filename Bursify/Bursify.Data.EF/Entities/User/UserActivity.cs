using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.Entities.User
{
    public class UserActivity : IEntity
    {
        public int ID { get; set; }
        public int BursifyUserId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual BursifyUser BursifyUser { get; set; }
    }
}
