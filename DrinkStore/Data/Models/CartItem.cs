using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkStore.Data.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int amount { get; set; }
        public string ShoppingCartID { get; set; }
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
    }
}
