using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Common.Models;
using SQLite.CodeFirst;

namespace DatabaseManager.Migrations
{
    public class Configuration : SqliteCreateDatabaseIfNotExists<WeatherDataContext>
    {
        public Configuration(DbModelBuilder modelBuilder) : base (modelBuilder)
        {
        }

        protected override void Seed(WeatherDataContext context)
        {
            context.City.AddOrUpdate(
                new City { Name = "Toruń", Observed = true, ServiceId = 3083271 },
                new City { Name = "Bydgoszcz", Observed = true, ServiceId = 3102014 },
                new City { Name = "Warszawa", Observed = true, ServiceId = 6695624 },
                new City { Name = "Kraków", Observed = true, ServiceId = 3094802 },
                new City { Name = "Gdańsk", Observed = true, ServiceId = 3099434 },
                new City { Name = "Wrocław", Observed = true, ServiceId = 3081368 },
                new City { Name = "Londyn", Observed = true, ServiceId = 3081368 },
                new City { Name = "Berlin", Observed = true, ServiceId = 3081368 },
                new City { Name = "Paryż", Observed = true, ServiceId = 3081368 }
                );
        }
    }
}
