using DrinkStore.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkStore.Data.Repositories
{
    public class ShoppinCartRepo
    {
        private readonly DrinksDbContext db;
        private readonly IHttpContextAccessor context;
        private string Shopping_cart_id;
        public ShoppinCartRepo(DrinksDbContext db, IHttpContextAccessor context)
        {
            this.db = db;
            this.context = context;
            Shopping_cart_id = context.HttpContext.Session.Id;
        }

        public void AddToCart(Drink drink, int amount)
        {
            var cartItem = db.CartItems.SingleOrDefault(s => s.ShoppingCartID == Shopping_cart_id
                                                                                           && s.Drink.DrinkId == drink.DrinkId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    amount = amount,
                    Drink = drink,
                    ShoppingCartID = context.HttpContext.Session.Id
                };
                db.CartItems.Add(cartItem);
            }
            else
            {
                var a = amount > 1 ? cartItem.amount = amount : cartItem.amount++;
            }
            db.SaveChanges();
        }
        public IEnumerable<CartItem> ViewShoppingCart()
        {
            var cartSession = db.CartItems.Where(s => s.ShoppingCartID == Shopping_cart_id);
            return cartSession;
        }
        public void RemoveFromCart(Drink drink)
        {
            var cartItem = db.CartItems.SingleOrDefault(s => s.ShoppingCartID == Shopping_cart_id
                                                                                           && s.Drink.DrinkId == drink.DrinkId);
            if (cartItem != null)
            {
                if (cartItem.amount > 1)
                { cartItem.amount--; }
                else
                { db.CartItems.Remove(cartItem); }
            }
            db.SaveChanges();
        }
        public void ClearCart()
        {
            var cartItem = db.CartItems.Where(s => s.ShoppingCartID == Shopping_cart_id);
            if (cartItem != null)
            {
                db.CartItems.RemoveRange(cartItem);
            }
            db.SaveChanges();
        }
    }
}
