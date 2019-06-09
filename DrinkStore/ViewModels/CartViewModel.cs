
using DrinkStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkStore.ViewModels
{
    public class CartViewModel
    {
        public IEnumerable<CartItem> cartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
