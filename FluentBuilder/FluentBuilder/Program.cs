using System;
using System.Collections.Generic;
using FluentBuilder.Builder;
using FluentBuilder.Model;

namespace FluentBuilder
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var products = new List<Product>
            {
                new Product
                {
                    ArticleNumber = "12345",
                    Price = 25.00,
                    Vat = 7,
                    Quantity = 2
                }
            };

            var user = new User
            {
                Name = "John",
                Email = "john@example.com"
            };


            // Wholesale Object Creation

            // Using Constructor
            var shoppingCart1 = new ShoppingCart(Guid.NewGuid(), products, 2.0, user);

            Console.WriteLine(shoppingCart1);

            // Using Object Initializer
            var shoppingCart2 = new ShoppingCart
            {
                Id = Guid.NewGuid(),
                Items = products,
                Discount = 2.0,
                User = user
            };

            Console.WriteLine(shoppingCart2);


            // Piecewise Object Creation
            var shoppingCart3 = new ShoppingCart();
            shoppingCart3.Id = Guid.NewGuid();
            shoppingCart3.Items = products;
            shoppingCart3.Discount = 2.0;
            shoppingCart3.User = user;

            Console.WriteLine(shoppingCart3);


            // Builder

            // Using Builder
            var shoppingCartBuilder = new ShoppingCartBuilder();
            shoppingCartBuilder.AddId(Guid.NewGuid());
            shoppingCartBuilder.AddItems(products);
            shoppingCartBuilder.AddDiscount(2.0);
            shoppingCartBuilder.AddUser(user);
            var shoppingCart4 = shoppingCartBuilder.GetShoppingCart();

            Console.WriteLine(shoppingCart4);


            // Using Fluent Builder
            var shoppingCart5 = new ShoppingCartFluentBuilder()
                                        .WithId(Guid.NewGuid())
                                        .WithItems(products)
                                        .WithDiscount(2.0)
                                        .WithUser(user)
                                        .Build();

            Console.WriteLine(shoppingCart5);
        }
    }
}
