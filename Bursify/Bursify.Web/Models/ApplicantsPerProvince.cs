using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Models
{
    public class ApplicantsPerProvince
    {
        public string Province { get; set; }
        public int ApplicantCount { get; set; }

        public ApplicantsPerProvince(string province, int applicantCount)
        {
            Province = province;
            ApplicantCount = applicantCount;
        }

        public static List<ApplicantsPerProvince> MapApplicantsPerProvince(Dictionary<string, int> dictionary)
        {
            return dictionary.Select(fund => new ApplicantsPerProvince(fund.Key, fund.Value)).ToList();
        }
    }
}