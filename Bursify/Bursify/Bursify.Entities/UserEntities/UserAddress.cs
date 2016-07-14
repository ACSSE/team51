namespace Bursify.Entities.UserEntities
{

    public class UserAddress : IEntityBase
    {
        public int AddressId { get; set; }
        public int BursifyUserId { get; set; }
        public string AddressType { get; set; }
        public bool PreferredAddress { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public long PostOfficeBoxNumber { get; set; }
        public string PostOfficeName { get; set; }
        public string PostalCode { get; set; }

        public int ID
        {
            get { return AddressId; }
        }

        public virtual BursifyUser BursifyUser { get; set; }
    }
}
