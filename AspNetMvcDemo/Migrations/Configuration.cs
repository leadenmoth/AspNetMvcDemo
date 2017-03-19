namespace AspNetMvcDemo.Migrations
{
    using AspNetMvcDemo.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspNetMvcDemo.Models.ProductDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AspNetMvcDemo.Models.ProductDbContext";
        }

        protected override void Seed(AspNetMvcDemo.Models.ProductDbContext context)
        {
            List<Product> products = new List<Product>
            {
                new Product()
                {
                    Category = "Vegetables",
                    Name = "Potatoes",
                    Price = 1.99M,
                    Description = "Price per kg",
                    Modified = DateTime.Now
                },
                new Product()
                {
                    Category = "Vegetables",
                    Name = "Cucumbers",
                    Price = 2.99M,
                    Description = "Price per kg",
                    Modified = DateTime.Now
                },
                new Product()
                {
                    Category = "Vegetables",
                    Name = "Carrots",
                    Price = 1.99M,
                    Description = "Price per kg",
                    Modified = DateTime.Now
                },
                new Product()
                {
                    Category = "Fruit",
                    Name = "Apples",
                    Price = 2.50M,
                    Description = "Price per kg",
                    Modified = DateTime.Now
                },
                new Product()
                {
                    Category = "Fruit",
                    Name = "Bananas",
                    Price = 1.99M,
                    Description = "Price per kg",
                    Modified = DateTime.Now
                }
            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
