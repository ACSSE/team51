using System.Collections.Generic;

namespace Bursify.Data.EF.Entities.StudentUser
{
    public class StudentReport : IEntity
    {
        public StudentReport()
        {
            Subjects = new List<Subject>();
        }

        public int ID { get; set; }
        public int StudentId { get; set; }
        public int Average { get; set; }
        public string ReportYear { get; set; }
        public string ReportLevel { get; set; } 
        public string ReportPeriod { get; set; }
        public string ReportInstitution { get; set; }
        public string ReportFilePath { get; set; }
        
        public virtual Student Student { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
