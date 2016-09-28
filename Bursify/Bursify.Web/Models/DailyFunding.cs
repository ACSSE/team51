using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Models
{
    public class DailyFunding
    {
        public int? Day { get; set; }
        public double Amount { get; set; }

        public DailyFunding(int? day, double amount)
        {
            Day = day;
            Amount = amount;
        }

        public static List<DailyFunding> MapDailyFundings(Dictionary<int?, double> dictionary)
        {
            return dictionary.Select(fund => new DailyFunding(fund.Key, fund.Value)).ToList();
        }
    }
}