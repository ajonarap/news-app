using NewsAPI.Models;
using NewsApp.Migrations;
using NewsApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace NewsApp.DAL
{
    public class EfDbContext : DbContext
    {

        public EfDbContext() : base("DefaultConnection")
        {
           // Database.SetInitializer<EfDbContext>(new MigrateDatabaseToLatestVersion<EfDbContext, Configuration>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<EfDbContext>());
        }

        public DbSet<DisplayArticle> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}