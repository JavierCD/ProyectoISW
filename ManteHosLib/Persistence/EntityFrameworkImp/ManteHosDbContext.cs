using System;
using System.Data.Entity;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using ManteHos.Entities;
using System.Diagnostics.Contracts;

namespace ManteHos.Persistence
{
    public class ManteHosDbContext : DbContextISW
    {
        public ManteHosDbContext() : base("Name=ManteHosDbConnection") //this is the connection string name
        {
            /*
            See DbContext.Configuration documentation
            */
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        static ManteHosDbContext()
        {
            Database.SetInitializer<ManteHosDbContext>(new DropCreateDatabaseIfModelChanges<ManteHosDbContext>());
        }

        // DbSets for persistent classes in your case study
        // TO BE DONE by STUDENTS...
        public IDbSet<Incident> Incidents { get; set; }
        public IDbSet<WorkOrder> WorkOrders { get; set; }
        public IDbSet<Area> Areas { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Head>Heads { get; set; }
        public IDbSet<Master> Masters { get; set; }
        public IDbSet<Operator> Operators { get; set; }
        public IDbSet<UsedPart> UsedParts { get; set; }
        public IDbSet<Part> Parts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
/*                        modelBuilder.Entity<Part>()
                                    .HasMany(p => p.UsedParts)
                                    .WithRequired(uP => uP.Part)
                                    .WillCascadeOnDelete(true);

                        modelBuilder.Entity<UsedPart>()
                            .HasRequired(p => p.Part)
                            .WithMany(uP => uP.UsedParts)
                            .WillCascadeOnDelete(false);
*/

        }

        // Generic method to clear all the data (except some relations if needed)
        public override void RemoveAllData()
        {
            clearSomeRelationships();

            base.RemoveAllData(); 
        }

        // Sometimes it is needed to clear some relationships explicitly 
        private void clearSomeRelationships()
        {
//            SaveChanges();
        }

    }
}

