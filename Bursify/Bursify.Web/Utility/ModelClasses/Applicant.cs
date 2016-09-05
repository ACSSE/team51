using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bursify.Web.Utility.ModelClasses
{
    public class Applicant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PicturePath { get; set; }
        public int Age { get; set; }
        public string Province { get; set; }
        public string Level { get; set; }
        public int Average { get; set; }
        public string Gender { get; set; }

        public Applicant()
        {
            
        }

        public Applicant(int id, string name, string surname, string picturePath, int age, string province, string level, int average, string gender)
        {
            ID = id;
            Name = name;
            Surname = surname;
            PicturePath = picturePath;
            Age = age;
            Province = province;
            Level = level;
            Average = average;
            Gender = gender;
        }
    }
}