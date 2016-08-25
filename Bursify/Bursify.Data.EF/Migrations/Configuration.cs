using System;
using System.Collections.Generic;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Data.EF.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Uow.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Uow.DataContext context)
        {
            context.Set<BursifyUser>().AddOrUpdate(CreateStudents().ToArray());
            context.Set<Student>().AddOrUpdate(AddStudents().ToArray());
        }

        private List<BursifyUser> CreateStudents()
        {
            var bursifyUsers = new List<BursifyUser>();

            for (var i = 0; i < 100; i++)
            {
                var user = new BursifyUser
                {
                    Email = MockData.Internet.Email(),
                    PasswordHash = "XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    PasswordSalt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    AccountStatus = "Active",
                    UserType = "Student",
                    RegistrationDate = DateTime.Today,
                    Biography = "Bio",
                    CellphoneNumber = "0840924299",
                    TelephoneNumber = "0123456789",
                    ProfilePicturePath = "somewhereSafe"
                };

                bursifyUsers.Add(user);
            }

            return bursifyUsers;
        }

        private List<Student> AddStudents()
        {
            var students = new List<Student>();
            int id = 1;
            string companyName = MockData.Company.BS();
            Console.WriteLine(companyName);
            foreach (var user in CreateStudents())
            {
                var student = new Student();

                student.ID = id++;
                student.InstitutionID = 1;
                student.IDNumber = "9521332463352";
                student.Firstname = MockData.Person.FirstName();
                student.Surname = MockData.Person.Surname();
                student.Headline = MockData.Lorem.Sentence();
                student.AverageMark = MockData.RandomNumber.Next(20, 100);
                student.StudentNumber = "201472025";
                student.Age = MockData.RandomNumber.Next(16, 30);
                student.HasDisability = MockData.Utils.Boolean();
                student.DisabilityDescription = "None";
                student.Race = GetRace(MockData.RandomNumber.Next(0, 4));
                student.Gender = (MockData.RandomNumber.Next(0, 100) >= 50) ? "Male" : "Female";
                student.CurrentOccupation = (MockData.RandomNumber.Next(0, 100) >= 50) ? "High-School Student" : "Tertiary Student";
                student.StudyField = "Information Technology";
                student.HighestAcademicAchievement = "Primary School";
                student.YearOfAcademicAchievement = 2008;
                student.DateOfBirth = MockData.Utils.RandomDate(new DateTime(2000, 01, 01), new DateTime(2016, 10, 10));
                student.NumberOfViews = 25;
                student.Essay = MockData.Lorem.Paragraphs(5).ToString();


                students.Add(student);
            }

            return students;
        }

        private string GetRace(int x)
        {
            string[] raceStrings = {"African", "White", "Asian", "Indian", "Coloured"};

            return raceStrings[x];
        }
    }
}
