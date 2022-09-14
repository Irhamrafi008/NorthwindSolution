using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Domain.Entities;

namespace Northwind.Persistence
{
    public class ShopeePopulateData
    {
        public static void PopulateData(IApplicationBuilder app)
        {
            ShoppeDBContext context=app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ShoppeDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category { CategoryName = "Laptop", Description = "Komputer, Laptop, PC" },
                    new Category { CategoryName = "Handphone", Description = "Hp" },
                    new Category { CategoryName = "T-Shirt", Description = "T-Shirt Man" }
                    );
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(

                    new Product
                    {
                        Name = "Monitor LG",
                        Description = "LG 16Inch",
                        CategoryID = 1,
                        Price = 500_000
                    },
                    new Product
                    {
                        Name = "Logitect Mouse 330",
                        Description = "Wireless Silent Click",
                        CategoryID = 1,
                        Price = 159_000
                    },
                    new Product
                    {
                        Name = "Keyboard K580",
                        Description = "Slim multidevice for window",
                        CategoryID = 1,
                        Price = 596_000
                    },
                    new Product
                    {
                        Name = "Xiomi Redmi Note 10Pro",
                        Description = "Xiomi Amoled 6.67Inch",
                        CategoryID = 2,
                        Price = 599_000
                    },
                    new Product
                    {
                        Name = "PowerBank Magsafe",
                        Description = "Anker PowerCore 5k",
                        CategoryID = 2,
                        Price = 335_000
                    },
                    new Product
                    {
                        Name = "Chino Pendek",
                        Description = "Chino pendek pria dewasa",
                        CategoryID = 3,
                        Price = 34_000
                    },
                    new Product
                    {
                        Name = "Kemaja Alisan",
                        Description = "Semua ukuran ada",
                        CategoryID = 3,
                        Price = 76_000
                    },
                     new Product
                     {
                         Name = "Kemaja Dony Man",
                         Description = "Kemeja pria lengan pendek",
                         CategoryID = 3,
                         Price = 58_000
                     }
                    );
            }


            context.SaveChanges();
        }
    }
}
