using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UnoSquare_ToysAndGames.Models;

namespace UnoSquare_ToysAndGames.Repositories
{
    public class ProductDataContext : DbContext
    {
        //dependency injection to get connection string
        public ProductDataContext(DbContextOptions options) : base(options)
        {

        }
        DbSet<Product> Products { get; set; }

        //seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
               .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Seeded Name 1",
                    AgeRestriction = 18,
                    Company = "Fake Company 1",
                    Description = "Fake product 1",
                    Price = 120
                },
                 new Product
                 {
                     Id= 2,
                     Name = "Seeded Name 2",
                     AgeRestriction = 14,
                     Company = "Fake Company 2",
                     Description = "Fake product 2",
                     Price = 50
                 }
                );
        }
    }
}
