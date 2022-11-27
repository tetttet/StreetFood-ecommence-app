using StreetFood.Entities;

namespace StreetFood.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        /// <summary>
        /// добавляем заказ в БД
        /// </summary>
        void AddOrder(Order order);
        
        /// <summary>
        /// Возвращаем все заказы
        /// </summary>
        List<Order> GetOrders();

        /// <summary>
        /// Возвращаем заказы с указзаной даты и до указанной даты
        /// </summary>
        List<Order> GetOrders(DateTime from, DateTime to);
    }
}
