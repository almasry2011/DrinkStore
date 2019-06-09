using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkStore.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string  Name { get; set; }
        public string Address  { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public ICollection<DrinkOrder> drinkOrders { get; set; }
    }
}
