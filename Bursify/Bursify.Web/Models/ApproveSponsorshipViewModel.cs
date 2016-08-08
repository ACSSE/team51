using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Models
{
    public class ApproveSponsorshipViewModel
    {
        public int studentId { get; set; }
        public int campaignId { get; set; }
        public string confirmation { get; set; }
    }
}