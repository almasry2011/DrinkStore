using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkStore.Data.Models;
using DrinkStore.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrinkStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepo orderRepo;
        private readonly IHttpContextAccessor context;
        public OrderController(IOrderRepo orderRepo, IHttpContextAccessor Context)
        {
            this.orderRepo = orderRepo;
            context = Context;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
           orderRepo.CreateOrder(order);
            return RedirectToAction("OrderComplete");
        }
        public IActionResult OrderComplete()
        {
           var o= orderRepo.ViewOrder(context.HttpContext.Session.Id);
            if (o!=null)
            {
                return View(o);
            }
            else
            {
                return Content("Error ");
            }
        }
    }
}