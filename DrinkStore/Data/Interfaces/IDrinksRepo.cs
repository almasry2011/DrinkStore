using DrinkStore.Data.Models;
using System.Collections.Generic;

namespace DrinkStore.Data.Repositories
{
    public interface IDrinksRepo
    {
        IEnumerable<Drink> ListDrinks { get; }
        IEnumerable<Category> ListCategories { get; }

        IEnumerable<Drink> ListPreferredDrinks { get; }
        IEnumerable<Drink> GetDrinksByCategories(string cat);
        Drink GetById(int id);

    }

}