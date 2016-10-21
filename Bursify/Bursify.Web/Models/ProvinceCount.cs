using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Models
{
    public class ProvinceCount
    {
        public string Province { get; set; }
        public int Count { get; set; }

        public ProvinceCount(string province, int count)
        {
            Province = province;
            Count = count;
        }

        public static List<ProvinceCount> MapProvinceCount(Dictionary<string, int> dictionary)
        {
            return dictionary.Select(fund => new ProvinceCount(fund.Key, fund.Value)).ToList();
        }
    }
}