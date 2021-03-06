﻿using System;
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



        //public static void Main(string[] args)
        //{
        //    Console.WriteLine("Creating db");
        //    BuellerContext db = new BuellerContext();
        //    Book book = new Book()           {
        //        BookTitle = "Math 101",
        //        ClassId = 2, 
        //        Price = 24.99m
        //   };
        //    db.Books.Add(book);
        //    db.SaveChanges();
    
        //    }


        public BuellerContext() : base("BuellerDb")
        {

        }

        public DbSet<StudentAccount> StudentAccounts { get; set; }
        public DbSet<EmployeeAccount> EmployeeAccounts { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Book> Books { get; set; }

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
