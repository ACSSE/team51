namespace Bursify.Web.Models
{
    public class Applicant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string School { get; set; }
        public string PicturePath { get; set; }
        public int Age { get; set; }
        public string Province { get; set; }
        public string Level { get; set; }
        public int Average { get; set; }
        public string Gender { get; set; }

        public Applicant(int id, string name, string surname, string school, string picturePath, int age, string province, string level, int average, string gender)
        {
            ID = id;
            Name = name;
            Surname = surname;
            School = school;
            PicturePath = picturePath;
            Age = age;
            Province = province;
            Level = level;
            Average = average;
            Gender = gender;
        }
    }
}