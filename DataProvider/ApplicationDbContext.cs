using DataProvider.Migrations;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(); 
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<LegalPerson> LegalPeople { get; set; }

        public DbSet<PhysicalPerson> PhysicalPeople { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

        public DbSet<ProductMoviment> ProductMoviments { get; set; }
        
        public DbSet<Entry> Entries { get; set; }

        public DbSet<Outward> Outwards { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
