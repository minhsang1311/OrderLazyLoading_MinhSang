using System;
using System.Linq;
using EFCoreSQLiteDemo.Models;

namespace EFCoreSQLiteDemo.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new[]
                {
                    new User { Name = "Alice", Email = "alice@example.com" },
                    new User { Name = "Bob", Email = "bob@example.com" },
                    new User { Name = "Charlie", Email = "charlie@example.com" }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var products = Enumerable.Range(1, 30).Select(i =>
                    new Product { Name = $"Product {i}", Price = i * 10 });

                context.Products.AddRange(products);
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {
                var random = new Random();
                var users = context.Users.ToList();
                var products = context.Products.ToList();

                foreach (var user in users)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        var order = new Order
                        {
                            User = user,
                            OrderDate = DateTime.Now.AddDays(-random.Next(1, 30))
                        };

                        var orderDetails = Enumerable.Range(1, random.Next(2, 5)).Select(_ => new OrderDetail
                        {
                            Product = products[random.Next(products.Count)],
                            Quantity = random.Next(1, 5),
                            UnitPrice = random.Next(50, 200)
                        }).ToList();

                        order.OrderDetails = orderDetails;
                        context.Orders.Add(order);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
