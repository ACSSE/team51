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

            //get sponsorships with the student's study field
            var studyFieldList = sponsorshipList.Where(sponsorship => sponsorship.StudyFields.ToUpper().Contains(student.StudyField.ToUpper())).ToList();

            //from sponsorships with the student's study field
            //get sponsorships whereby the student qualifies with the average mark
            var averageMarkList = studyFieldList.Where(sponsorship => sponsorship.AverageMarkRequired > 0).ToList();
            
            //utility
            var studentSubjects = student.StudentSubjects.ToList();

            //utility
            var subjectList = studyFieldList.Where(sponsorship => !averageMarkList.Contains(sponsorship)).ToList();
            
            var filteredSubjectlist = new List<Sponsorship>();

            foreach (var sponsorship in subjectList)
            {
                var sponsorshipSubjects = sponsorship.Requirements.ToList();

                foreach (var sponsorshipSubject in sponsorshipSubjects)
                {
                    var subjectCounter = 0;

                    foreach (var studentSubject in studentSubjects)
                    {
                        if (sponsorshipSubject.SubjectId != studentSubject.SubjectId) continue;

                        var subjectQualifies = studentSubject.MarkAcquired >= sponsorshipSubject.RequiredMark;

                        if (subjectQualifies)
                        {
                            subjectCounter++;
                        }
                    }

                    if (subjectCounter == studentSubjects.Count)
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
