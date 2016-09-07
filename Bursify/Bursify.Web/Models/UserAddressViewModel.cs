
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
        public string StreetAddress { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostOfficeBoxNumber { get; set; }
        public string PostalCode { get; set; }

        public UserAddressViewModel MapSingleAddress(UserAddress userAddress)
        {
            ID = userAddress.ID;
            BursifyUserId = userAddress.BursifyUserId;
            AddressType = userAddress.AddressType;
            PreferredAddress = userAddress.PreferredAddress;
            StreetAddress = userAddress.StreetAddress;
            Province = userAddress.Province;
            City = userAddress.City;
            PostOfficeBoxNumber = userAddress.PostOfficeBoxNumber;
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
                StreetAddress = this.StreetAddress,
                Province = this.Province,
                City = this.City,
                PostOfficeBoxNumber = this.PostOfficeBoxNumber,
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