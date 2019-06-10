using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DrinkStore.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IDrinksRepo drinksRepo;

        public DrinkController(IDrinksRepo drinksRepo)
        {
            this.drinksRepo = drinksRepo;
        }
        [Route("{controller}/list")]
        [Route("/")]
        public IActionResult List(string cat)
        {
            if (!string.IsNullOrEmpty(cat))
            {
                var filter = drinksRepo.GetDrinksByCategories(cat);
               return View(filter);
            }
            else
            {
                var listModel = drinksRepo.ListDrinks;
                return View(listModel);
            }
        }

        [Route("{controller}/Preferred")]
        public IActionResult PreferredDrinksList()
        {
                var PreferredDrinks = drinksRepo.ListPreferredDrinks;
                return View("list",PreferredDrinks);
        }

        public IActionResult AddPreferredDrinksList(int id)
        {
           drinksRepo.AddPreferredDrinks(id);
            return RedirectToAction("list");
        }

        public IActionResult DrinkDetails(int id)
        {
           var drink= drinksRepo.DrinkDetail(id);
            return View(drink);
        }


    }
}