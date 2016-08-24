using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bursify.Data.EF.Entities.Bridge;
using Bursify.Data.EF.Entities.StudentUser;
using Bursify.Data.EF.Entities.User;
using Bursify.Data.EF.Uow;
using NUnit.Framework;

namespace Bursify.Tests
{
    [TestFixture]
    public class StudentTest
    {
        [Test]
        public void DataInsert()
        {
            var dataSession = new DataSession();
            var uowFactory = new UnitOfWorkFactory(dataSession);
            var uow = uowFactory.CreateUnitOfWork();

            var testUser = new BursifyUser()
            {
                //ID = 51,
                Email = "brandon@gmail.com",
                PasswordHash = "password123",
                PasswordSalt = "passwordSalt",
                AccountStatus = "Active",
                UserType = "Student",
                RegistrationDate = DateTime.Today,
                Biography = "Bio stuff",
                CellphoneNumber = "0840924299",
                TelephoneNumber = "0123456789",
                ProfilePicturePath = "somewhereSafe"
            };

            var school = new Institution()
            {
                //ID = 25,
                Name = "University of Johannesburg",
                Type = "Tertiary",
                Website = "www.uj.ac.za",
                
            };



            var Students = //new List<Student>()
                //{
                new Student()
                {
                    ID = testUser.ID,
                    InstitutionID = school.ID,
                    AgreeTandC = true,
                    AverageMark = 75,
                    Age = 20,
                    Firstname = "Brandon",
                    Gender = "Male",

                };
            //};

            school.Students.Add(Students); //= Students;

            var StudentReports = //new List<StudentReport>()
            //{
                new StudentReport()
                {
                    StudentId = Students.ID,
                    Average = 75,
                    ReportInstitution = "UJ",
                    ReportLevel = "Tertiary",
                    ReportPeriod = "Semester 1",
                    
                //}
            };

            var Subjects = new List<Subject>()
            {
                new Subject()
                {
                    //ID = 12,
                    RequirementId = StudentReports.ID,
                    Name = "CSC 1A10",
                    MarkAcquired = 12
                },

                new Subject()
                {
                    //ID = 12,
                    RequirementId = StudentReports.ID,
                    Name = "CSC 2A10",
                    MarkAcquired = 21
                }
            };

            StudentReports.Subjects = Subjects;
            Students.StudentReports.Add(StudentReports);
            school.Students.Add(Students);
            //testUser.Student = Students;

            uow.Context.Set<BursifyUser>().Add(testUser);
            uow.Context.Set<Institution>().Add(school);
//            uow.Context.Set<Student>().Add(Students);
//            uow.Context.Set<StudentReport>().Add(StudentReports);
//            uow.Context.Set<Subject>().Add(Subjects[1]);

            uow.Context.SaveChanges(); 
            uow.Commit();
        }
    }
}