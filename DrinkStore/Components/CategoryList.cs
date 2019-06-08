using DrinkStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkStore.Components
{
    public class CategoryList:ViewComponent
    {
        private readonly IDrinksRepo drinksRepo;

        public CategoryList(IDrinksRepo drinksRepo)
        {
            this.drinksRepo = drinksRepo;
        }

        public IViewComponentResult Invoke()
        {
            var catModel = drinksRepo.ListCategories;
             return View(catModel);
        }

    }
}
