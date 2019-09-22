namespace PetsureWebApiExamRodel.Data.Migrations
{
    using PetsureWebApiExamRodel.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PetsureWebApiExamRodel.Data.Services.WebapiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PetsureWebApiExamRodel.Data.Services.WebapiDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var customer = new Customer()
            {
                FullName = "Rodel bolima",
                DateOfBirth = "05/15/1974",
                Age = 45
            };
            customer.Address = new List<Address>
            {
                new Address
                {
                    Address1 ="126 Pajo Street",
                    Address2 ="Project 2",
                    City="Quezon City",
                    State="Philippine"

                },
                new Address
                {
                    Address1="Block 9b lot 53",
                    Address2 ="Poblacion",
                    City ="Muntinlupa",
                    State ="Alabang "
                }
            };
            context.Customers.Add(customer);
            base.Seed(context);
            
        }
    }
}
