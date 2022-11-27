using StreetFood.BusinessObjects;
using StreetFood.Entities;
using StreetFood.Providers;
using StreetFood.Repositories.Interfaces;

namespace StreetFood.Repositories.ProvidersImpl
{
    public class OrdersProvider : IOrdersProvider
    {
        private IOrdersRepository ordersRepository;

        public OrdersProvider(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        /// <summary>
        /// добавляем заказ в БД
        /// </summary>
        public void AddOrder(OrderBO orderBO)
        {
            Order order = new Order() { DishId = orderBO.DishId, OpenDate = orderBO.OpenDate, Sum = orderBO.Sum  };
            ordersRepository.AddOrder(order);
        }

        /// <summary>
        /// Возвращаем все заказы
        /// </summary>
        public List<OrderBO> GetOrders()
        {
            List<Order> orders = ordersRepository.GetOrders();
            return orders
                .Select(x => new OrderBO() { Id = x.Id, DishId = x.DishId, OpenDate = x.OpenDate, Sum = x.Sum })
                .ToList();
        }
    }
}
