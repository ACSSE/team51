using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bursify.Data.User;

namespace Bursify.Web.Models
{
    public class SubjectViewModel
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public SubjectViewModel(Subject subject)
        {
            SubjectId = subject.SubjectId;
            Name = subject.Name;
        }
    }
}