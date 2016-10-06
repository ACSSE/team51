using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.Entities.User
{
    public class Notification : IEntity
    {
        public int ID { get; set; }
        public int BursifyUserId { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public int ActionId { get; set; }
        public string Sender { get; set; }
        public bool ReadStatus { get; set; }

        public virtual BursifyUser User { get; set; }
    }
}
