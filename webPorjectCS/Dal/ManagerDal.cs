using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webPorjectCS.Models;
using System.Data.Entity;

namespace webPorjectCS.Dal
{
    public class ManagerDal:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Manager>().ToTable("manager"); //relation to the table
        }
        
        public DbSet<Manager> Managers { get; set; }
    }
}