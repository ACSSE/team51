using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Uow;

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
            var sponsorships = _dataSession.UnitOfWork.Context.Set<Sponsorship>()
                .Include(x => x.Requirements)
                .ToList();

            return sponsorships;
        }

        public List<Sponsorship> GetAllSponsorships(string type)
        {
            var sponsorships = _dataSession.UnitOfWork.Context.Set<Sponsorship>()
                .Where(sponsorship => sponsorship.SponsorshipType.ToUpper().Equals(type.ToUpper()))
                .Include(x => x.Requirements)
                .ToList();

            return sponsorships;
        }

        public List<Sponsorship> GetAllSponsorships(int sponsorId)
        {
            var sponsorships = _dataSession.UnitOfWork.Context.Set<Sponsorship>()
                .Where(x => x.SponsorId == sponsorId)
                .Include(x => x.Requirements)
                .ToList();

            return sponsorships;
        }

        public Sponsorship GetSponsorship(int id, int sponsorId)
        {
            var sponsorship = _dataSession.UnitOfWork.Context.Set<Sponsorship>()
                .Where(x => x.ID == id && x.SponsorId == sponsorId)
                .Include(x => x.Requirements)
                .FirstOrDefault();

            return sponsorship;
            return sponsorship;
        }

        public Sponsorship GetSponsorship(int id)
        {
            var sponsorship = _dataSession.UnitOfWork.Context.Set<Sponsorship>()
                .Where(x => x.ID == id)
                .Include(x => x.Requirements)
                .FirstOrDefault();

            return sponsorship;
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

            var all = LoadAll();

            var sponsorships = new List<Sponsorship>();

            var fields = current.StudyFields.Split(',');

            foreach (var field in fields)
            {
                foreach (var s in all)
                {
                    if (s.StudyFields.Contains(field) && s.ID != current.ID)
                    {
                        sponsorships.Add(s);
                        break;
                    }

                    //if (sponsorships.Count == 3)
                    //{
                    //    break;
                    //}
                }
                if (sponsorships.Count == 3)
                {
                    break;
                }
            }

            var data = GetSponsorshipsWithRequirements(sponsorships);

            return data;
        }

        private List<Sponsorship> GetSponsorshipsWithRequirements(List<Sponsorship> sponsorships)
        {
            var data = new List<Sponsorship>();

            foreach (var sponsorship in sponsorships)
            {
                data = _dataSession.UnitOfWork.Context.Set<Sponsorship>()
                    .Where(x => x.ID == sponsorship.ID)
                    .Include(x => x.Requirements)
                    .ToList();
            }

            return data;
        }
    }
}