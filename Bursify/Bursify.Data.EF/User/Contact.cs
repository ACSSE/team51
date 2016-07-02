using Bursify.Data.EF;
using System.Collections.Generic;

namespace Bursify.Data.User
{
    public class Contact : IEntity
    {
        public int ContactId { get; set; }
        public string CellphoneNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public int BursifyUserId { get; set; }
        public virtual BursifyUser BursifyUser { get; set; }
        public int Id
        {
            get
            {
                return ContactId;
            }
        }
    }
}
