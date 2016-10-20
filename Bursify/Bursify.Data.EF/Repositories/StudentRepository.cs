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
                        .ThenBy(x => x.ReportPeriod.Equals("Semester 2")
                            ? 1
                            : x.ReportPeriod.Equals("Semester 1")
                                ? 2
                                : x.ReportPeriod.Equals("Term 4")
                                    ? 3
                                    : x.ReportPeriod.Equals("Term 3")
                                        ? 4
                                        : x.ReportPeriod.Equals("Term 2")
                                            ? 5
                                            : x.ReportPeriod.Equals("Term 1") ? 6 : 7)
                        .FirstOrDefault();

                    if ((report == null || sponsorship.AverageMarkRequired > report.Average ||
                         !ContainsStudyField(sponsorship, student) ||
                         !sponsorship.EducationLevel.Equals(student.CurrentOccupation))) continue;

                    if (!students.Contains(student))
                    {
                        students.Add(student);
                    }
                }
            }

            return students;
        }

        private bool ContainsStudyField(Sponsorship sponsorship, Student student)
        {
            string[] studentFields = student.StudyField.Split(',');

            foreach (var field in studentFields)
            {
                if (sponsorship.StudyFields.Equals("Any", StringComparison.OrdinalIgnoreCase) ||
                    sponsorship.StudyFields.Contains(field))
                {
                    return true;
                }
            }

            return false;
        }
    }
}