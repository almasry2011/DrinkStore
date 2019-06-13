using DrinkStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace DrinkStore.Data.Repositories
{
    public class OrderRepo : IOrderRepo
    {
        private readonly DrinksDbContext db;
        private readonly IShoppinCartRepo shoppinCartRepo;
        private readonly IHttpContextAccessor context;
        public OrderRepo(DrinksDbContext db,IShoppinCartRepo shoppinCartRepo,IHttpContextAccessor Context)
        {
            this.db = db;
            this.shoppinCartRepo = shoppinCartRepo;
            context = Context;
        }
        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            db.orders.Add(order);
            foreach (var item in shoppinCartRepo.ViewShoppingCart())
            {
                DrinkOrder drinkOrder = new DrinkOrder
                {
                    DrinkId = item.Drink.DrinkId,
                   OrderId = order.OrderId,
                    Amount=item.amount,
                    Price=item.Drink.Price * item.amount
                };
                db.drinkOrders.Add(drinkOrder);
            }
           
            if (db.SaveChanges()<0)
            {
                foreach (var item in shoppinCartRepo.ViewShoppingCart())
                {
                    item.Drink.Stock += item.amount;
                }
                db.SaveChanges();
            } 
        }
        public Order ViewOrder(string SessionId)
        {
            if (context.HttpContext.Session.Id== SessionId)
            {
                var order = db.orders.Last();
                return order;
            }
            else { return null; }
        }

 



}
}
