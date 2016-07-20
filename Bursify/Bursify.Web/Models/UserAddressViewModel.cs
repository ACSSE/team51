using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bursify.Data.EF.User;

namespace Bursify.Web.Models
{
    public class UserAddressViewModel
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

        public UserAddressViewModel(UserAddress userAddress)
        {
            AddressId = userAddress.AddressId;
            BursifyUserId = userAddress.BursifyUserId;
            AddressType = userAddress.AddressType;
            PreferredAddress = userAddress.PreferredAddress;
            HouseNumber = userAddress.HouseNumber;
            StreetName = userAddress.StreetName;
            Suburb = userAddress.Suburb;
            City = userAddress.City;
            PostOfficeBoxNumber = userAddress.PostOfficeBoxNumber;
            PostOfficeName = userAddress.PostOfficeName;
            PostalCode = userAddress.PostalCode;
        }
    }
}