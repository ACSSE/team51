using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.StudentUser;
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
            List<Sponsorship> filteredSponsorships;

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
                                    || sponsorship.Name.ToUpper().Contains(criteria)
                                    || sponsorship.Description.ToUpper().Contains(criteria)
                                    || sponsorship.StudyFields.ToUpper().Contains(criteria)
                                    || sponsorship.ExpensesCovered.ToUpper().Contains(criteria)
                                    || sponsorship.PreferredInstitutions.ToUpper().Contains(criteria));
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

        public List<Sponsorship> LoadSponsorshipSuggestions(Student student)
        {
            //get sponsorships matching the student's education level
            var sponsorshipList = FindMany(sponsorship =>
               (sponsorship.EducationLevel == student.EducationLevel));

            var studyFieldList = sponsorshipList.Where(sponsorship => sponsorship.StudyFields.ToUpper().Contains(student.StudyField.ToUpper())).ToList();

            var averageMarkList = studyFieldList.Where(sponsorship => sponsorship.AverageMarkRequired > 0).ToList();
            
            //utility
            var studentSubjects = student.StudentSubjects.ToList();
            var subjectQualifies = false;

            //hope there is a better way
            //utility
            var subjectList = studyFieldList.Where(sponsorship => !averageMarkList.Contains(sponsorship)).ToList();
            
            var filteredSubjectlist = new List<Sponsorship>();

            foreach (var sponsorship in subjectList)
            {
                var sponsorshipSubjects = sponsorship.Requirements.ToList();

                foreach (var sponsorshipSubject in sponsorshipSubjects)
                {
                    foreach (var studentSubject in studentSubjects)
                    {
                        if (sponsorshipSubject.SubjectId != studentSubject.SubjectId) continue;

                        subjectQualifies = studentSubject.MarkAcquired >= sponsorshipSubject.RequiredMark;
                    }

                    if (subjectQualifies)
                    {
                        filteredSubjectlist.Add(sponsorship);   
                    }
                }
            }

            var finalList = (averageMarkList.ToList().Concat(filteredSubjectlist.ToList())).ToList();


            return finalList;
        }
    }
}
