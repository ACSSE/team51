using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Bursify.Data.EF.Entities.SponsorUser;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class StudentRepository : Repository<Student>
    {
        private readonly DataSession _dataSession;

        public StudentRepository(DataSession dataSession) : base(dataSession)
        {
            _dataSession = dataSession;
        }

        public List<Student> GetStudentSuggestions(int sponsorId)
        {
            var sponsorships = _dataSession.UnitOfWork.Context.Set<Sponsorship>()
                .Where(sponsorship => sponsorship.SponsorId == sponsorId)
                .Include(sponsorship => sponsorship.Requirements)
                .ToList();

            var allStudents = LoadAll();
            var students = new List<Student>();

            foreach (var sponsorship in sponsorships)
            {
                foreach (var student in allStudents)
                {
                    var report = _dataSession.UnitOfWork.Context.Set<StudentReport>()
                        .Where(x => x.StudentId == student.ID)
                        .OrderByDescending(x => x.ReportYear)
                        .ThenByDescending(x => x.ReportPeriod)
                        .FirstOrDefault();

                    if (report == null || sponsorship.AverageMarkRequired > report.Average ||
                        !sponsorship.StudyFields.Contains(student.StudyField) ||
                        !sponsorship.EducationLevel.Equals(student.EducationLevel)) continue;

                    if (!students.Contains(student))
                    {
                        students.Add(student);
                    }
                }
            }

            return students;
        }
    }
}