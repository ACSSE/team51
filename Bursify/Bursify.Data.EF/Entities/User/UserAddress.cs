namespace Bursify.Data.EF.Entities.User
{
    public class UserAddress : IEntity
    {
        public int ID { get; set; }
        public int BursifyUserId { get; set; }
        public string AddressType { get; set; }
        public bool PreferredAddress { get; set; }
        public string StreetAddress { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostOfficeBoxNumber { get; set; }
        public string PostalCode { get; set; }

        public virtual BursifyUser BursifyUser { get; set; }
    }
}
