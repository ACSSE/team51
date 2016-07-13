﻿using System.Collections.Generic;
using Bursify.Data.EF.CampaignUser;
using Bursify.Data.EF.SponsorUser;
using Bursify.Data.EF.StudentUser;
using Bursify.Data.EF.Uow;
using Bursify.Data.EF.User;
using Bursify.Data.StudentUser;
using Bursify.Data.User;
using NUnit.Framework;
using System;

namespace Bursify.Tests
{
    [TestFixture]
    public class BursifyUserDataFixture
    {
        [Test]
        public void CanAccessDb()
        {
            var dataSession = new DataSession();
            var uowFactory = new UnitOfWorkFactory(dataSession);
            var uow = uowFactory.CreateUnitOfWork();
            
            var user = new BursifyUser() { };

            user.Name = "SponsorTest";
            user.Email = "brandon@gmail.com";
            user.PasswordHash = "password123";
            user.PasswordSalt = "passwordSalt";
            user.AccountStatus = true;
            user.UserType = "Sponsor";
            user.RegistrationDate = new DateTime(2016, 6, 10);
            user.Biography = "Bio stuff";
            user.CellphoneNumber = "0840924299";
            user.TelephoneNumber = "0123456789";
            user.ProfilePicturePath = "somewhereSafe";

            var address = new UserAddress
            {
                BursifyUserId = user.BursifyUserId,
                AddressType = "Postal",
                PreferredAddress = true,
                HouseNumber = "",
                StreetName = "",
                Suburb = "",
                City = "Johannesburg",
                PostOfficeBoxNumber = 1730,
                PostOfficeName = "That one close to my house",
                PostalCode = "1685"
            };

            if (user.UserType.Equals("Student"))
            {
                var student = new Student
                {
                    Surname = "Sibanda",
                    EducationLevel = "Tertiary",
                    AverageMark = 70,
                    StudentNumber = "201472025",
                    Age = 20,
                    HasDisability = false,
                    Race = "Black",
                    Gender = "Male",
                    CurrentOccupation = "Studying",
                    HighestAcademicAchievement = "High School",
                    YearOfAcademicAchievement = 2013,
                    DateOfBirth = new DateTime(1996, 6, 10),
                    Campaigns = new List<Campaign>()
                    {
                        new Campaign()
                        {
                            CampaignName = "Help Us",
                            Tagline = "Please",
                            Location = "Gauteng",
                            Description = "Lost",
                            AmountRequired = 100000,
                            CampaignType = "School",
                            VideoPath = "",
                            PicturePath = "",
                            StartDate = new DateTime(2016, 7, 9),
                            EndDate = new DateTime(2016, 11, 9),
                            AmountContributed = 50,
                            FundUsage = "",
                            ReasonsToSupport = "Last Hope",
                            Account = new Account()
                            {
                                AccountName = "Brandon",
                                AccountNumber = "9876543210",
                                BankName = "World Bank",
                                BranchCode = "",
                                BranchName = "World"
                            }
                        },
                        new Campaign()
                        {
                            CampaignName = "Second",
                            Tagline = "Please",
                            Location = "Gauteng",
                            Description = "Lost",
                            AmountRequired = 100000,
                            CampaignType = "School",
                            VideoPath = "",
                            PicturePath = "",
                            StartDate = new DateTime(2016, 7, 9),
                            EndDate = new DateTime(2016, 11, 9),
                            AmountContributed = 50,
                            FundUsage = "",
                            ReasonsToSupport = "Last Hope"
                        }
                    }
                };

                user.Student = student;
            }
            else if (user.UserType.Equals("Sponsor"))
            {
                var sponsor = new Sponsor()
                {
                    NumberOfStudentsSponsored = 10,
                    NumberOfSponsorships = 2,
                    NumberOfApplicants = 20,
                    BursifyRank = 3,
                    BursifyScore = 101,
                    Sponsorhips = new List<Sponsorship>()
                    {
                        new Sponsorship()
                        {
                            Name = "ManyFunds",
                            Description = "We will fund anyone",
                            ClosingDate = new DateTime(2016, 9, 30),
                            EssayRequired = false,
                            SponsorshipValue = 75000,
                            StudyFields = "IT, Medicine, Engineering",
                            Province = "All",
                            AverageMarkRequired = 70,
                            EducationLevel = "Tertiary",
                            PreferredInstitutions = "All",
                            ExpensesCovered = "All",
                            TermsAndConditions = "Many words"
                        },
                        new Sponsorship()
                        {
                            Name = "SecondFunds",
                            Description = "We will fund anyone",
                            ClosingDate = new DateTime(2016, 9, 30),
                            EssayRequired = true,
                            SponsorshipValue = 75000,
                            StudyFields = "IT, Medicine, Engineering",
                            Province = "All",
                            AverageMarkRequired = 70,
                            EducationLevel = "Tertiary",
                            PreferredInstitutions = "All",
                            ExpensesCovered = "All",
                            TermsAndConditions = "Must read"
                        }
                    }

                };

                user.Sponsor = sponsor;
            }

            uow.Context.Set<BursifyUser>().Add(user);
            uow.Context.Set<UserAddress>().Add(address);

            uow.Context.SaveChanges();
            uow.Commit();
        }
    }
}