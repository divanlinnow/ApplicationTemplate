using Domain.Entities.Core;
using ORM.EF.Contexts;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace ORM.EF.Migrations
{
    // Package Manager Console commands :
    // To enable migrations                                                 : enable-migrations
    // To create/add a new migration                                        : add-migration "Migration Name"
    // To create/update the database and run all the migrations             : update-database
    // To update the database to a specified migration                      : update-database -TargetMigration:"Migration Name"

    internal sealed class Configuration : DbMigrationsConfiguration<CoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        // This Seed method is run after EACH migration.
        protected override void Seed(CoreContext context)
        {
            // Countries
            var countries = new List<Country>
            {
                new Country { ISOCode = "AX", Abbreviation = "AX", Name = "Aland Islands" },
                new Country { ISOCode = "AL", Abbreviation = "AL", Name = "Albania" },
                new Country { ISOCode = "DZ", Abbreviation = "DZ", Name = "Algeria" }
            };

            // Provinces
            var provinces = new List<Province>
            {
                new Province { ISOCode = "TA", Abbreviation = "TA", Name = "Test Province A", Country = countries[0] },
                new Province { ISOCode = "TB", Abbreviation = "TB", Name = "Test Province B", Country = countries[1] },
                new Province { ISOCode = "TC", Abbreviation = "TC", Name = "Test Province C", Country = countries[2] }
            };

            var cities = new List<City>
            {
                new City { ISOCode = "TCA", Abbreviation = "TCA", Name = "Test City A", Province = provinces[0], Country = countries[0] },
                new City { ISOCode = "TCB", Abbreviation = "TCB", Name = "Test City B", Province = provinces[1], Country = countries[1] },
                new City { ISOCode = "TCC", Abbreviation = "TCC", Name = "Test City C", Province = provinces[2], Country = countries[2] }
            };



            // In order to avoid duplication of records, we need to tell Entity Framework how check if the record already exists, using the first parameter of the AddOrUpdate method.
            countries.ForEach(country => context.Countries.AddOrUpdate(c => new { c.ISOCode, c.Name }, country));
            provinces.ForEach(province => context.Provinces.AddOrUpdate(p => new { p.ISOCode, p.Name }, province));
            //cities.ForEach(city => context.Cities.AddOrUpdate(c => new { c.ISOCode, c.Name }, city));

            context.SaveChanges();
        }
    }
}