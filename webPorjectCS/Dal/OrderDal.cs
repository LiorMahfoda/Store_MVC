using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using webPorjectCS.Models;

namespace webPorjectCS.Dal
{
    public class OrderDal:DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().ToTable("orders");
        }

        public DbSet<Order> Orders { get; set; }
    }
}