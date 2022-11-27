using StreetFood.BusinessObjects;


namespace StreetFood.BusinessLogic.Interfaces
{
    public interface IReportsService
    {
        /// <summary>
        /// Возвращает заказы для отчёта
        /// </summary>
        /// <returns></returns>
        public List<OrderReportItemBO> GetOrders();

        /// <summary>
        /// Получить список часто используемых ингредиентов
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        public List<StockProductItemBO> GetPopularStockProducts(int take);

        public List<SalesByDayOfWeekBO> GeSalesByDayOfWeek();
        public List<OrderReportItemBO> GetOrders(DateTime from);
        public List<OrderReportItemBO> GetOrders(DateTime from, DateTime to);
    }
}
