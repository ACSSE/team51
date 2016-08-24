using System.Collections.Generic;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class StudentReportRepository : Repository<StudentReport>
    {
        public StudentReportRepository(DataSession dataSession) : base(dataSession)
        {
        }

        public StudentReport GetStudentReport(int reportId, int studentId)
        {
            return FindSingle(x =>
                              x.ID == reportId
                           && x.StudentId == studentId);
        }

        public List<StudentReport> GetStudentReports(int studentId)
        {
            return FindMany(x => x.StudentId == studentId);
        }
    }
}
