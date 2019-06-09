using DrinkStore.Data.Models;

namespace DrinkStore.Data.Repositories
{
    public interface IOrderRepo
    {
        void CreateOrder(Order order);
        Order ViewOrder(string SessionId);
    }
}