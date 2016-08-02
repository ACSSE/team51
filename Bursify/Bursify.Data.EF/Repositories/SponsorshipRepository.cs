using System;
using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.SponsorUser;
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
            List<Sponsorship> filteredSponsorships = null;

            if (criteria.Contains("BURSARY") || criteria.Contains("BURSARIES"))
            {
                filteredSponsorships = FindMany(sponsorship =>
                                        sponsorship.SponsorshipType.ToUpper() == "BURSARY"
                                     || sponsorship.Name.ToUpper().Contains(criteria)
                                     || sponsorship.Description.ToUpper().Contains(criteria)
                                     || sponsorship.StudyFields.ToUpper().Contains(criteria)
                                     || sponsorship.ExpensesCovered.ToUpper().Contains(criteria)
                                     || sponsorship.PreferredInstitutions.ToUpper().Contains(criteria));
            }
            else if (criteria.Contains("SCHOLARSHIP") || criteria.Contains("SCHOLARSHIPS"))
            {
                filteredSponsorships = FindMany(sponsorship =>
                                        sponsorship.SponsorshipType.ToUpper() == "SCHOLARSHIP"
                                    ||  sponsorship.Name.ToUpper().Contains(criteria)
                                    ||  sponsorship.Description.ToUpper().Contains(criteria)
                                    ||  sponsorship.StudyFields.ToUpper().Contains(criteria)
                                    ||  sponsorship.ExpensesCovered.ToUpper().Contains(criteria)
                                    ||  sponsorship.PreferredInstitutions.ToUpper().Contains(criteria));
            }
            else
            {
                filteredSponsorships = FindMany(sponsorship =>
                                         sponsorship.Name.ToUpper().Contains(criteria)
                                     || sponsorship.Description.ToUpper().Contains(criteria)
                                     || sponsorship.StudyFields.ToUpper().Contains(criteria)
                                     || sponsorship.ExpensesCovered.ToUpper().Contains(criteria)
                                     || sponsorship.PreferredInstitutions.ToUpper().Contains(criteria));
            }

            return filteredSponsorships;
        }

        //moved to studentSponsor repo
        //public List<Student> GetStudents(int sponsorshipId)
        //{
        //    var students = (from s in DbContext.Set<StudentSponsorship>() where s.SponsorshipId == sponsorshipId select s.Student).ToList();
        //    return students;
        //}
    }
}