using System.Collections.Generic;
using System.Linq;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Web.Models
{
    public class StudentReportViewModel
    {
        public int ID { get; set; }
        public int StudentId { get; set; }
        public int Average { get; set; }
        public string ReportLevel { get; set; }
        public string ReportPeriod { get; set; }
        public string ReportInstitution { get; set; }
        public List<SubjectViewModel> Subjects { get; set; }

        public StudentReportViewModel MapSingleReport(StudentReport report)
        {
            ID = report.ID;
            StudentId = report.StudentId;
            Average = report.Average;
            ReportLevel = report.ReportLevel;
            ReportPeriod = report.ReportPeriod;
            ReportInstitution = report.ReportInstitution;
            Subjects = SubjectViewModel.ReverseMapSubjects((List<Subject>)report.Subjects);

            return this;
        }

        public StudentReport ReverseMap()
        {
            return new StudentReport()
            {
                ID = this.ID,
                StudentId = this.StudentId,
                Average = this.Average,
                ReportLevel = this.ReportLevel,
                ReportPeriod = this.ReportPeriod,
                ReportInstitution = this.ReportInstitution,
               // Subjects = this.Subjects
            };
        }

        public List<StudentReportViewModel> MapMultipleReports(List<StudentReport> reportViewModels)
        {
            return reportViewModels.Select(MapSingleReport).ToList();
        }
    }
}