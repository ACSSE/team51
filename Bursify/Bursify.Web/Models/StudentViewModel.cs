using System;
using Bursify.Data.EF.Entities.StudentUser;

namespace Bursify.Web.Models
{
    public class StudentViewModel
    {
        public int BursifyUserId { get; set; }
        public string Surname { get; set; }
        public string EducationLevel { get; set; }
        public int AverageMark { get; set; }
        public string StudentNumber { get; set; }
        public int Age { get; set; }
        public bool HasDisability { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string CurrentOccupation { get; set; }
        public string HighestAcademicAchievement { get; set; }
        public long YearOfAcademicAchievement { get; set; }
        public DateTime DateOfBirth { get; set; }


        public StudentViewModel(Student student)
        {
            BursifyUserId = student.ID;
            Surname = student.Surname;
            EducationLevel = student.EducationLevel;
            AverageMark = student.AverageMark;
            StudentNumber = student.StudentNumber;
            Age = student.Age;
            HasDisability = student.HasDisability;
            Race = student.Race;
            Gender = student.Gender;
            CurrentOccupation = student.CurrentOccupation;
            HighestAcademicAchievement = student.HighestAcademicAchievement;
            YearOfAcademicAchievement = student.YearOfAcademicAchievement;
            DateOfBirth = student.DateOfBirth;
        }
    }
}