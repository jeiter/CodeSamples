using System;
using System.Collections.Generic;

namespace FluentBuilder.Model
{
    public class ShoppingCart
    {
        public ShoppingCart() {}

        public ShoppingCart(Guid id, List<Product> items, double discount, User user)
        {
            Id = id;
            Items = items;
            Discount = discount;
            User = user;
        }

        public Guid Id { get; set; }

        public List<Product> Items { get; set; }

        public double Discount { get; set; }

        public User User { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Items: {Items.Count}, Discount: {Discount}, User: {User.Email}";
        }
    }
}
