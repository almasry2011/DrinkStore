using DrinkStore.Data.Models;
using System.Collections.Generic;

namespace DrinkStore.Data.Repositories
{
    public interface IDrinksRepo
    {
        IEnumerable<Drink> ListDrinks { get; }
        IEnumerable<Drink> ListPreferredDrinks { get; }
        IEnumerable<Drink> GetByCategories(string cat);
        Drink GetById(int id);

    }

}