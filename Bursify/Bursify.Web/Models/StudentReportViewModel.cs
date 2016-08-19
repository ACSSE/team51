using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public StudentReportViewModel MapSingleReport(StudentReport report)
        {
            ID = report.ID;
            StudentId = report.StudentId;
            Average = report.Average;
            ReportLevel = report.ReportLevel;
            ReportPeriod = report.ReportPeriod;

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
                ReportPeriod = this.ReportPeriod
            };
        }

        public List<StudentReportViewModel> MapMultipleReports(List<StudentReport> reportViewModels)
        {
            return reportViewModels.Select(MapSingleReport).ToList();
        }
    }
}