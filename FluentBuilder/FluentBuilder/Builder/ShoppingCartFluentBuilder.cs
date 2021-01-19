using System;
using System.Collections.Generic;
using FluentBuilder.Model;

namespace FluentBuilder.Builder
{
    public class ShoppingCartFluentBuilder
    {
        private ShoppingCart _shoppingCart = new ShoppingCart();

        public ShoppingCartFluentBuilder WithId(Guid id)
        {
            _shoppingCart.Id = id;
            return this;
        }

        public ShoppingCartFluentBuilder WithItems(List<Product> items)
        {
            _shoppingCart.Items = items;
            return this;
        }

        public ShoppingCartFluentBuilder WithDiscount(double discount)
        {
            _shoppingCart.Discount = discount;
            return this;
        }

        public ShoppingCartFluentBuilder WithUser(User user)
        {
            _shoppingCart.User = user;
            return this;
        }

        public ShoppingCart Build()
        {
            return _shoppingCart;
        }
    }
}
