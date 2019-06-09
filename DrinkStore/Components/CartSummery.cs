using DrinkStore.Data.Repositories;
using DrinkStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkStore.Components
{
    public class CartSummery:ViewComponent
    {
        private readonly IShoppinCartRepo shoppinCartRepo;

        public CartSummery(IShoppinCartRepo shoppinCartRepo)
        {
            this.shoppinCartRepo = shoppinCartRepo;
        }

        public IViewComponentResult Invoke()
        {
            CartViewModel CartModel = new CartViewModel
            {
                CartTotal = shoppinCartRepo.GetCartTotal()
            };
            return View(CartModel);
        }

    }
}
