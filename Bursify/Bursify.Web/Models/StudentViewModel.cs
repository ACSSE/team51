
﻿
using Bursify.Data.EF.Entities.StudentUser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bursify.Web.Models
{
    public class StudentViewModel
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string EducationLevel { get; set; }
        public int AverageMark { get; set; }
        public string StudentNumber { get; set; }
        public int Age { get; set; }
        public bool HasDisability { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string CurrentOccupation { get; set; }
        public string StudyField { get; set; }
        public string HighestAcademicAchievement { get; set; }
        public long YearOfAcademicAchievement { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NumberOfViews { get; set; }

        public Student MapSingleStudent(Student student)
        {
            return new Student()
            {
                ID = student.ID,
                Surname = student.Surname,
                EducationLevel = student.EducationLevel,
                AverageMark = student.AverageMark,
                StudentNumber = student.StudentNumber,
                Age = student.Age,
                HasDisability = student.HasDisability,
                Race = student.Race,
                Gender = student.Gender,
                CurrentOccupation = student.CurrentOccupation,
                StudyField = student.StudyField,
                HighestAcademicAchievement = student.HighestAcademicAchievement,
                YearOfAcademicAchievement = student.YearOfAcademicAchievement,
                DateOfBirth = student.DateOfBirth,
                NumberOfViews = student.NumberOfViews
            };
        }

        public List<Student> MapMultipleStudents(List<Student> students)
        {
            return (from student in students select MapSingleStudent(student)).ToList();
        }
    }
}