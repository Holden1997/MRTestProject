using Microsoft.EntityFrameworkCore;
using MRTestProject.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRTestProject.Infastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options ): base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigureProduct());
            modelBuilder.ApplyConfiguration(new ConfigureCategory());

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = Guid.NewGuid(), Name = "Smartphone" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = Guid.NewGuid(), Name = "Smartwatch" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
