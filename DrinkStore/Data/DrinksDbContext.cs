using DrinkStore.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkStore.Data
{
    public class DrinksDbContext:IdentityDbContext
    {
        public DrinksDbContext(DbContextOptions<DrinksDbContext> options):base(options)
        {
        }
        public DbSet<Drink> drinks { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<DrinkOrder> drinkOrders { get; set; }

    }
}
