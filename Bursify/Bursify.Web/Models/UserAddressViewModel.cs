
using System.Collections.Generic;
using Bursify.Data.EF.Entities.User;
namespace Bursify.Web.Models
{
    public class UserAddressViewModel
    {
        public int ID { get; set; }
        public int BursifyUserId { get; set; }
        public string AddressType { get; set; }
        public string PreferredAddress { get; set; }
        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public long PostOfficeBoxNumber { get; set; }
        public string PostOfficeName { get; set; }
        public string PostalCode { get; set; }

        public UserAddressViewModel MapSingleAddress(UserAddress userAddress)
        {
            ID = userAddress.ID;
            BursifyUserId = userAddress.BursifyUserId;
            AddressType = userAddress.AddressType;
            PreferredAddress = userAddress.PreferredAddress;
            HouseNumber = userAddress.HouseNumber;
            StreetName = userAddress.StreetName;
            Province = userAddress.Province;
            City = userAddress.City;
            PostOfficeBoxNumber = userAddress.PostOfficeBoxNumber;
            PostOfficeName = userAddress.PostOfficeName;
            PostalCode = userAddress.PostalCode;

            return this;
        }

        public UserAddress ReverseMap()
        {
            return new UserAddress()
            {
                ID = this.ID,
                BursifyUserId = this.BursifyUserId,
                AddressType = this.AddressType,
                PreferredAddress = this.PreferredAddress,
                HouseNumber = this.HouseNumber,
                StreetName = this.StreetName,
                Province = this.Province,
                City = this.City,
                PostOfficeBoxNumber = this.PostOfficeBoxNumber,
                PostOfficeName = this.PostOfficeName,
                PostalCode = this.PostalCode
            };
        }

        public static List<UserAddressViewModel> MapMultipleStudents(List<UserAddress> address)
        {
            List<UserAddressViewModel> addressVM = new List<UserAddressViewModel>();
            foreach (var s in address)
            {
                UserAddressViewModel aVm = (new UserAddressViewModel()).MapSingleAddress(s);
                addressVM.Add(aVm);
            }

            return addressVM;
        }
    }
}