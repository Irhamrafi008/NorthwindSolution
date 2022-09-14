using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Northwind.Domain.Entities;
using System;



namespace Northwind.Persistence
{
    public class ShoppeDBContext : DbContext
    {
        private static IConfigurationRoot _Iconfigutation;

        public ShoppeDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
