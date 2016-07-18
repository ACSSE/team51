
using AutoMapper;
using Bursify.Entities.CampaignEntities;
using Bursify.Entities.UserEntities;
using Bursify.Web.Models;
using System.Linq;

namespace Bursify.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<BursifyUser, BursifyUserViewModel>();
            Mapper.CreateMap<Campaign, CampaignViewModel>();
        }
    }
}