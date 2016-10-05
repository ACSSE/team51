using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bursify.Data.EF.Entities.StudentUser;

namespace Bursify.Web.Models
{
    public class PersonalDetailsViewModel
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Headline { get; set; }
        public string Biograpghy { get; set; }

        public PersonalDetails ReverseMap()
        {
            return new PersonalDetails()
            {
                Firstname = this.Firstname,
                Surname = this.Surname,
                Headline = this.Headline,
                Biograpghy = this.Biograpghy
            };
        }
    }
}