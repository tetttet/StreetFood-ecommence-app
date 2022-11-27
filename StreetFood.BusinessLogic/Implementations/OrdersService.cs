using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using StreetFood.Providers;

namespace StreetFood.BusinessLogic.Implementations
{
    public class OrdersService : IOrdersService
    {
        // сервис по работе с запасами ингредиентов
        private IStockProductsService stockProductsService;
        
        // сервис по работе с составом блюда
        private IContentsService contentsService;
        
        // сервис по работе с блюдами
        private IDishesService dishesService;
        
        // провайдер для работы с простыми операциями CRUD над заказом
        private IOrdersProvider ordersProvider;
        

        public OrdersService(IStockProductsService stockProductsService,
            IContentsService contentsService,
            IOrdersProvider ordersProvider,
            IDishesService dishesService)
        {
            this.stockProductsService = stockProductsService;
            this.contentsService = contentsService;
            this.ordersProvider = ordersProvider;
            this.dishesService = dishesService;
        }

        /// <summary>
        /// Метод добавления заказа (по бизнесу с проверками и меньшением продуктов)
        /// </summary>
        public ResultContent AddOrder(OrderBO orderBO)
        {
            // пытаемся найти то блюдо, которое заказали
            DishBO? dish = dishesService.GetById(orderBO.DishId);

            // если такого блюда нет, возвращаем ответ и информацию, почему отказали
            if (dish == null)
            {
                return new ResultContent() { Successfully = false, Message = $"Dish with dishId = {orderBO.DishId} not found" };
            }
            
            // проверяем, что можем приготовить
            if (!CheckOrder(orderBO)) 
            {
                // если нет, возвращаем ответ и информацию, почему отказали
                return new ResultContent() { Successfully = false, Message = "We can't cook order" };
            }

            // получаем состав блюда
            List<ContentBO>? contetns = contentsService.GetContentsByDishId(orderBO.DishId);
            
            // в цикле бежим по сотаву блюда
            foreach (ContentBO contentBO in contetns)
            {
                // изменяем количество доступных продуктов в холдильнике/полке
                // используем -contentBO.Count, чтобы уменьшить наши запасы на то количество
                // которое нужно для приготовления блюда
                stockProductsService.UpdateStockProduct(contentBO.IngredientId, -contentBO.Count);
            }

            // заполним скмму чека из цены блюда
            orderBO.Sum = dish.Price;
            // подставим время создания/открытия заказа в UTC
            orderBO.OpenDate = DateTime.UtcNow;
            
            // выполним добавление заказа, через провайдер (потом в БД)
            ordersProvider.AddOrder(orderBO);

            // возвращаем инфу, что заказ принят и сообщение для пользователя
            return new ResultContent() { Successfully = true, Message = "Wait 5 minutes" };
        }

        /// <summary>
        /// Проверка, можем ли мы приготовить заказ
        /// </summary>
        public bool CheckOrder(OrderBO orderBO)
        {
            // получаем состав (список элементов состава) из чего состоит блюдо из заказа
            List<ContentBO> contentBOList = contentsService.GetContentsByDishId(orderBO.DishId);

            // в цикле бежим по каждому элементу состава
            foreach (var contentBo in contentBOList)
            {
                
                // ищем этот ингредиент у нас на кухне, в холодильнике/на полке
                StockProductBO? stockProductBo = stockProductsService.GetByIngredientId(contentBo.IngredientId);

                // если такого продукта нет совсем, то приготовить не можем
                if (stockProductBo == null)
                {
                    return false;
                }

                // если такого продукта не достаточно, то приготовить не можем
                if (stockProductBo.Count < contentBo.Count)
                {
                    return false;
                }
            }

            // если всего достаточно, то можем приготовить
            return true;
        }

        public List<OrderBO> GetOrders()
        {
            return ordersProvider.GetOrders();
        }

        public List<OrderBO> GetOrders(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }
    }
}
