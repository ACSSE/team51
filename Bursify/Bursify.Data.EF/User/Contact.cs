using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bursify.Data.EF;

namespace Bursify.Data.User
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string CellphoneNumber { get; set; }
        public string TelephoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
    }
}
