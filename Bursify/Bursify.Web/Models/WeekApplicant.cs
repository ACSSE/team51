using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Models
{
    public class WeekApplicant
    {
        public int? Week { get; set; }
        public int ApplicantCount { get; set; }

        public WeekApplicant(int? week, int applicantCount)
        {
            Week = week;
            ApplicantCount = applicantCount;
        }

        public static List<WeekApplicant> MapApplicants(Dictionary<int?, int> dictionary)
        {
            return dictionary.Select(app => new WeekApplicant(app.Key, app.Value)).ToList();
        }
    }
}