using System.Collections.Generic;
using DrinkStore.Data.Models;

namespace DrinkStore.Data.Repositories
{
    public interface IShoppinCartRepo
    {
        void AddToCart(Drink drink, int amount);
        void ClearCart();
        void RemoveFromCart(Drink drink);
        IEnumerable<CartItem> ViewShoppingCart();
        decimal GetCartTotal();
    }
}