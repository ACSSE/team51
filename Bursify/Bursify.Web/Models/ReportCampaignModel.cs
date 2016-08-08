using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Models
{
    public class ReportCampaignModel
    {
        public int userId { get; set; }
        public int camapignId { get; set; }
        public string reason { get; set; }
    }
}