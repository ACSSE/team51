using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Models
{
    public class PesonalDetailsViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public PesonalDetailsViewModel(int id, string name, string bio)
        {
            ID = id;
            Name = name;
            Bio = bio;
        }

        public PesonalDetailsViewModel()
        {
        }
    }
}