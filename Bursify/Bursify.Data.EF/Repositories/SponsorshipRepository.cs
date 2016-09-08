using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.Entities.StudentUser;

namespace Bursify.Data.EF.Repositories
{
    public class SponsorshipRepository : Repository<Sponsorship>
    {
        private readonly DataSession _dataSession;

        public SponsorshipRepository(DataSession dataSession) : base(dataSession)
        {
            _dataSession = dataSession;
        }

        public List<Sponsorship> GetAllSponsorships()
        {
            return LoadAll();
        }

        public List<Sponsorship> GetAllSponsorships(string type)
        {
            return FindMany(sponsorship => sponsorship.SponsorshipType.ToUpper().Equals(type.ToUpper()));
        }

        public List<Sponsorship> GetAllSponsorships(int sponsorId)
        {
            return FindMany(sponsorship => sponsorship.SponsorId == sponsorId);
        }

        public Sponsorship GetSponsorship(int id, int sponsorId)
        {
            return FindSingle(sponsorship => sponsorship.ID == id && sponsorship.SponsorId == sponsorId);
        }

        public Sponsorship GetSponsorship(int id)
        {
            return FindSingle(sponsorship => sponsorship.ID == id);
        }

        public List<Sponsorship> FindSponsorships(string criteria)
        {
            List<Sponsorship> filteredSponsorships;

            if (criteria.Contains("BURSARY") || criteria.Contains("BURSARIES"))
            {
                filteredSponsorships = FindMany(sponsorship =>
                                        sponsorship.SponsorshipType.ToUpper() == "BURSARY"
                                     || sponsorship.Name.ToUpper().Contains(criteria)
                                     || sponsorship.Description.ToUpper().Contains(criteria)
                                     || sponsorship.StudyFields.ToUpper().Contains(criteria)
                                     || sponsorship.ExpensesCovered.ToUpper().Contains(criteria)
                                     || sponsorship.InstitutionPreference.ToUpper().Contains(criteria));
            }
            else if (criteria.Contains("SCHOLARSHIP") || criteria.Contains("SCHOLARSHIPS"))
            {
                filteredSponsorships = FindMany(sponsorship =>
                                        sponsorship.SponsorshipType.ToUpper() == "SCHOLARSHIP"
                                    || sponsorship.Name.ToUpper().Contains(criteria)
                                    || sponsorship.Description.ToUpper().Contains(criteria)
                                    || sponsorship.StudyFields.ToUpper().Contains(criteria)
                                    || sponsorship.ExpensesCovered.ToUpper().Contains(criteria)
                                    || sponsorship.InstitutionPreference.ToUpper().Contains(criteria));
            }
            else
            {
                filteredSponsorships = FindMany(sponsorship =>
                                         sponsorship.Name.ToUpper().Contains(criteria)
                                     || sponsorship.Description.ToUpper().Contains(criteria)
                                     || sponsorship.StudyFields.ToUpper().Contains(criteria)
                                     || sponsorship.ExpensesCovered.ToUpper().Contains(criteria)
                                     || sponsorship.InstitutionPreference.ToUpper().Contains(criteria));
            }

            return filteredSponsorships;
        }

        public List<Sponsorship> GetSimilarSponsorships(int sponsorshipId)
        {
            var current = LoadById(sponsorshipId);

            var sponsorships =
                FindMany(sponsorship => sponsorship.StudyFields.Contains(current.StudyFields)).Take(3).ToList();

            return sponsorships;
        }

    }
}
