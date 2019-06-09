using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkStore.Data.Models
{
    public class DrinkOrder
    {
        public int DrinkOrderId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public int OrderId { get; set; }
        public Order order { get; set; }

        public int DrinkId { get; set; }
        public Drink drink { get; set; }


    }
}
