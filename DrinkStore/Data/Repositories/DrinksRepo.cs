using DrinkStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkStore.Data.Repositories
{
    public class DrinksRepo : IDrinksRepo
    {
        private readonly DrinksDbContext db;

        public DrinksRepo(DrinksDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Drink> ListDrinks => db.drinks.ToList();
        public IEnumerable<Drink> ListPreferredDrinks => db.drinks.Where(p => p.IsPreferredDrink);
        public IEnumerable<Category> ListCategories => db.categories.ToList();

        public IEnumerable<Drink> GetDrinksByCategories(string cat)
        {
            if (!string.IsNullOrEmpty(cat) || !string.IsNullOrWhiteSpace(cat))
            {
                var m = db.drinks.Where(s => s.Category.CategoryName.ToLower() == cat.ToLower()).Include(c => c.Category);
                return m;
            }
            else
            {
                return db.drinks.ToList();
            }
        }
        public Drink GetById(int id)
        {
            var drink = db.drinks.Include(c => c.Category).SingleOrDefault(s => s.DrinkId == id);
            if (drink != null)
            {
                return drink;
            }
            else
            {
                return null;
            }
        }

        public void AddPreferredDrinks(int id)
        {
            var drink = db.drinks.SingleOrDefault(d => d.DrinkId == id);
            drink.IsPreferredDrink = true;
            db.SaveChanges();

        }

        public Drink DrinkDetail(int id)
        {
            var drink = db.drinks.SingleOrDefault(d => d.DrinkId == id);
            return drink;
        }



    }
}
