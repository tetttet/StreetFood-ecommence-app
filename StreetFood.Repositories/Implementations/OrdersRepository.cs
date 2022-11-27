using StreetFood.DAL;
using StreetFood.Entities;
using StreetFood.Repositories.Interfaces;

namespace StreetFood.Repositories.Implementations
{
    public class OrdersRepository : IOrdersRepository
    {
        /// <summary>
        /// добавляем заказ в БД
        /// </summary>
        public void AddOrder(Order order)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                streetFoodDbContext.Orders.Add(order);
                streetFoodDbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Возвращаем все заказы
        /// </summary>
        public List<Order> GetOrders()
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                return streetFoodDbContext.Orders.ToList();
            }
        }

        /// <summary>
        /// Возвращаем заказы с указзаной даты и до указанной даты
        /// </summary>
        public List<Order> GetOrders(DateTime from , DateTime to)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                return streetFoodDbContext.Orders.Where(x=>x.OpenDate >= from && x.OpenDate < to).ToList();
            }
        }
    }
}
