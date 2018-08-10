using SQLite.CodeFirst;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Common.Models;
using DatabaseManager.Migrations;
using DatabaseManager.Interfaces;

namespace DatabaseManager
{

    public class WeatherDataContext : DbContext, IDataContext
    {
        // Your context has been configured to use a 'WeatherData' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Usługa.WeatherData' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WeatherData' 
        // connection string in the application configuration file.
        public WeatherDataContext()
            : 
            base("WeatherDataContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new Configuration(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // Models for DTO (converting js to database tables)
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Clouds> Clouds { get; set; }
        //public virtual DbSet<Coord> Coord { get; set; }
        //public virtual DbSet<Forecast5Days> Forecast5Days { get; set; }
        //public virtual DbSet<List> List { get; set; }
        public virtual DbSet<WeatherMain> WeatherMain { get; set; }
        public virtual DbSet<Forecast> Forecast { get; set; }
        //public virtual DbSet<Sys> Sys { get; set; }
        //public virtual DbSet<WeatherMainId> WeatherMainId { get; set; }
        public virtual DbSet<Wind> Wind { get; set; }
        public virtual DbSet<PredictionDate> PredictionDate { get; set; }
        // Models for operating on weather, detailed information collection.
        //public virtual DbSet<SelectedPlaces> SelectedPlaces { get; set; }
    }
}