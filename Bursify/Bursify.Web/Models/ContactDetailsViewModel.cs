using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Models
{
    public class ContactDetailsViewModel
    {
        public int ID { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string GPhone { get; set; }
        public string GRelationship { get; set; }
        public string GEmail { get; set; }

        public ContactDetailsViewModel(int phone, string email, string gPhone, string gRelationship, string gEmail)
        {
            this.phone = phone;
            this.email = email;
            GPhone = gPhone;
            GRelationship = gRelationship;
            GEmail = gEmail;
        }

        public ContactDetailsViewModel()
        {
        }
    }
}