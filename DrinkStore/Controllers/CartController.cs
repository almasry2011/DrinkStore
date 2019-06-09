using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkStore.Data;
using DrinkStore.Data.Repositories;
using DrinkStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrinkStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IDrinksRepo drinksRepo;
        private readonly IShoppinCartRepo shoppinCartRepo;
        private readonly IHttpContextAccessor httpContext;
        string SessionId;


        public CartController(IDrinksRepo drinksRepo, IShoppinCartRepo shoppinCartRepo, IHttpContextAccessor Context)
        {
            this.drinksRepo = drinksRepo;
            this.shoppinCartRepo = shoppinCartRepo;
            this.httpContext = Context;
            SessionId = Context.HttpContext.Session.Id;
        }
        public IActionResult AddToCart(int id, int amount = 1)
        {
            if (HttpContext.Session.GetString("cart") == null)
            {
                HttpContext.Session.SetString("cart", "cartId");
            }
            var drink = drinksRepo.GetById(id);
            shoppinCartRepo.AddToCart(drink, amount);
            return RedirectToAction("index");
        }

        public IActionResult RemoveCart(int id)
        {
            var drink = drinksRepo.GetById(id);
            shoppinCartRepo.RemoveFromCart(drink);
            return RedirectToAction("index");
        }

        public IActionResult Index()
        {
            ViewBag.SessionId = SessionId;
            CartViewModel cartModel = new CartViewModel
            {
                cartItems = shoppinCartRepo.ViewShoppingCart(),
                CartTotal = shoppinCartRepo.GetCartTotal()
            };
            return View(cartModel);
        }
    }
}