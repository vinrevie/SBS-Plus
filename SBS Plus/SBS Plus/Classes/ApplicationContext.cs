using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBS_Plus.Classes;
namespace SBS_Plus.Classes
{
    internal class ApplicationContext : DbContext
    {
        static public ApplicationContext Instance
        {
            get
            {
                if (_instance == null) _instance = new ApplicationContext();
                return _instance;
            }
        }
        public ApplicationContext() : base(@"Data Source= DESKTOP-4BH3IAU\MSSQLSERVER7; Initial Catalog = SBSPlus5; Integrated Security = True") { }
        public DbSet<Classes.Organization> Organization { get; set; }
        public DbSet<Classes.Contract> Contract { get; set; }
        public DbSet<Classes.Work> Work { get; set; }

        static private ApplicationContext _instance;
        public void Rollback()
        {
            var changedEntries = Instance.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }

    }
}


