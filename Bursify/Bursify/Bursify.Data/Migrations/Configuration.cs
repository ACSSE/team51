namespace Bursify.Data.Migrations
{
    using Entities;
    using Entities.UserEntities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Bursify.Data.BursifyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        protected override void Seed(Bursify.Data.BursifyContext context)
        {
            context.BursifyUserSet.AddOrUpdate(u => u.Email, new BursifyUser[] {
                new BursifyUser()
                {
                    Email ="student@bursify.com",
                    Name ="Bstudent",
                    PasswordHash ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    PasswordSalt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    AccountStatus = "Active",
                    UserType = "Student",
                    RegistrationDate = DateTime.Now
                }
            });
           
        }


    }
}
