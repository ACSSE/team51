using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;

namespace Bursify.Data.EF.Repositories
{
    public class StudentReportRepository : Repository<StudentReport>
    {
        private readonly DataSession _dataSession;

        public StudentReportRepository(DataSession dataSession) : base(dataSession)
        {
            _dataSession = dataSession;
        }

        public StudentReport GetStudentReport(int reportId, int studentId)
        {
            return FindSingle(x =>
                x.ID == reportId
                && x.StudentId == studentId);
        }

        public StudentReport GetReportWithSubjects(int reportId, int studentId)
        {
            var reportCard = _dataSession.UnitOfWork.Context.Set<StudentReport>()
                .Where(x => x.ID == reportId && x.StudentId == studentId)
                .Include("Subjects")
                .FirstOrDefault();

            return reportCard;
        }

        public List<StudentReport> GetStudentReports(int studentId)
        {
            return FindMany(x => x.StudentId == studentId);
        }

        public List<StudentReport> GetFiveMostRecentReports(int studentId)
        {
            var reports = _dataSession.UnitOfWork.Context.Set<StudentReport>()
                .Where(x => x.StudentId == studentId)
                .OrderByDescending(x => x.ReportYear)
                .ThenByDescending(x => x.ReportPeriod)
                .Take(5)
                .ToList();

            return reports;
        }

        public StudentReport GetMostRecentReport(int studentId)
        {
            var report = _dataSession.UnitOfWork.Context.Set<StudentReport>()
                .Where(x => x.StudentId == studentId)
                .OrderByDescending(x => x.ReportYear)
                .ThenByDescending(x => x.ReportPeriod)
                .FirstOrDefault();

            return report;
        }
    }
}