using System;
using System.Collections.Generic;
using FluentBuilder.Model;

namespace FluentBuilder.Builder
{
    public class ShoppingCartBuilder
    {
        public ShoppingCart ShoppingCart = new ShoppingCart();

        public void AddId(Guid id)
        {
            ShoppingCart.Id = id;
        }

        public void AddItems(List<Product> items)
        {
            ShoppingCart.Items = items;
        }

        public void AddDiscount(double discount)
        {
            ShoppingCart.Discount = discount;
        }

        public void AddUser(User user)
        {
            ShoppingCart.User = user;
        }
    }
}
