using System.Collections.Generic;
using Bursify.Entities;
using Bursify.Entities.CampaignEntities;
using Bursify.Entities.SponsorEntities;
using Bursify.Entities.UserEntities;

namespace Bursify.Services.Abstract
{
    public interface IStudentRepository //<T> where T : class, IEntityBase
    {
        #region Campaigns

        Account GetAccount(int id);
        void AddCampaign(Campaign campaign);
        void UpdateCampaign(Campaign campaign);
        Campaign GetSIngleCampaign(int id);
        List<Campaign> GetAllCampaigns();
        void ShareCampaign(int id);
        void EndorseCampaign(int id);
        List<Campaign> FindCampaigns(/*add criteria: dynamic or overload*/);

        #endregion

        #region Sponsor and Sponsorship

        // Sponsor section
        List<Sponsor> GetAllSponsors();
        List<Sponsor> GetTopTenSponsors( /*criteria??*/);
        Sponsor GetSponsor(int id);

        // Sponsorship section
        List<Sponsorship> GetAllSponsorships();
        Sponsorship GetSponsorship(int id);
        List<Sponsorship> FindSponsorships(/*add criteria: dynamic or overload*/);
        void RateSponsorship(/*criteria*/);
        void ShareSponsorship();

        #endregion

        #region Institution

        Institution GetInstitution(int id);
        void UpdateInstitution(Institution institution);
        void AddInstitution(Institution institution);

        #endregion
    }
}
