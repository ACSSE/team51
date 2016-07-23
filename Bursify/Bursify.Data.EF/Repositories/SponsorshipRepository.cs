using System;
using System.Collections.Generic;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class SponsorshipRepository : Repository<Sponsorship>
    {
        public SponsorshipRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public List<Sponsorship> GetAllSponsorships()
        {
            return LoadAll();
        }

        public List<Sponsorship> GetAllSponsorships(string type)
        {
            throw new NotImplementedException();
        }

        public List<Sponsorship> GetAllSponsorships(int sponsorId)
        {
            return FindMany(sponsorship => sponsorship.SponsorId == sponsorId);
        }

        public Sponsorship GetSponsorship(int id, int sponsorId)
        {
            return FindSingle(sponsorship => sponsorship.SponsorshipId == id && sponsorship.SponsorId == sponsorId);
        }

        public Sponsorship GetSponsorship(int id)
        {
            return FindSingle(sponsorship => sponsorship.SponsorshipId == id);
        }

        public List<Sponsorship> FindSponsorships(string criteria)
        {
            //IEnumerable<Sponsorship> filteredSponsorships = null;

             var filteredSponsorships = FindMany(sponsorship =>
                    sponsorship.Name.ToUpper().Contains(criteria)
                 || sponsorship.Description.ToUpper().Contains(criteria)
                 || sponsorship.StudyFields.ToUpper().Contains(criteria)
                 || sponsorship.ExpensesCovered.ToUpper().Contains(criteria)
                 || sponsorship.PreferredInstitutions.ToUpper().Contains(criteria));
           
            return filteredSponsorships;
        }
        
    }
}