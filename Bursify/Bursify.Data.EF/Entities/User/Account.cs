using System;
using Bursify.Data.EF.Entities.Campaigns;

namespace Bursify.Data.EF.Entities.User
{
    public class Account : IEntity 
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
        public string CardNumber { get; set; }
        public long ExpirationYear { get; set; }
        public int ExpirationMonth { get; set; }
        public int CvvNumber { get; set; }

        public virtual BursifyUser BursifyUser { get; set; }
    }
}