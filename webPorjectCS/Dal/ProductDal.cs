using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using webPorjectCS.Models;

namespace webPorjectCS.Dal
{
    public class ProductDal : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().ToTable("products");
        }

        public DbSet<Product> Products { get; set; }
    }
}