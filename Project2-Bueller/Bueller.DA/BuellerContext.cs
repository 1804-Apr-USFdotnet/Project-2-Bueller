using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Bueller.DA.Models;

namespace Bueller.DA
{
    public class BuellerContext : DbContext, IDbContext
    {
        public BuellerContext() : base("BuellerDb")
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Class> classSet { get; set; }
        public DbSet<Classes> classesSet { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public override int SaveChanges()
        {
            var AddedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Added).ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("Created").CurrentValue = DateTime.Now;
                //set modified date as well. to sort by a common column
                E.Property("Modified").CurrentValue = DateTime.Now;
            });

            var ModifiedEntities = ChangeTracker.Entries().Where(E => E.State == EntityState.Modified).ToList();

            ModifiedEntities.ForEach(E =>
            {
                E.Property("Modified").CurrentValue = DateTime.Now;
            });
            return base.SaveChanges();
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
