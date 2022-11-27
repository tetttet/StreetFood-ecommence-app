using StreetFood.BusinessObjects;

namespace StreetFood.BusinessLogic.Interfaces
{
    public interface IOrdersService
    {
        /// <summary>
        /// Метод добавления заказа (по бизнесу с проверками и меньшением продуктов)
        /// </summary>
        ResultContent AddOrder(OrderBO orderBO);
        
        /// <summary>
        /// Проверка, можем ли мы приготовить заказ
        /// </summary>
        bool CheckOrder(OrderBO orderBO);
        List<OrderBO> GetOrders();
        List<OrderBO> GetOrders(DateTime from, DateTime to);
    }
}
