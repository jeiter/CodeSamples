using System;
using System.Collections.Generic;
using FluentBuilder.Model;

namespace FluentBuilder.Builder
{
    public class ShoppingCartBuilder
    {
        private ShoppingCart _shoppingCart = new ShoppingCart();

        public void AddId(Guid id)
        {
            _shoppingCart.Id = id;
        }

        public void AddItems(List<Product> items)
        {
            _shoppingCart.Items = items;
        }

        public void AddDiscount(double discount)
        {
            _shoppingCart.Discount = discount;
        }

        public void AddUser(User user)
        {
            _shoppingCart.User = user;
        }

        public ShoppingCart GetShoppingCart()
        {
            return _shoppingCart;
        }
    }
}
