using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using StreetFood.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessLogic.Implementations
{
    public class StockProductsService : IStockProductsService
    {
        private IStockProductsProvider stockProductsProvider;

        public StockProductsService(IStockProductsProvider stockProductsProvider)
        {
            this.stockProductsProvider = stockProductsProvider;
        }

        public void AddProduct(StockProductBO stockProductBO)
        {
            stockProductsProvider.AddProduct(stockProductBO);
        }

        public List<StockProductBO> GetStockProducts()
        {
            return stockProductsProvider.GetStockProducts();
        }

        /// <summary>
        /// Получить какие продукты у нас есть на хранении по ingredientId
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        public StockProductBO? GetByIngredientId(int ingredientId)
        {
            return stockProductsProvider.GetByIngredientId(ingredientId);
        }

        /// <summary>
        /// Метод обновления количества доступных продуктов/ингредиентов
        /// </summary>
        /// <param name="ingredientId">ИД ингредиента, который мы хотим поменять</param>
        /// <param name="diff">это изенение, на сколько (отриц - уменьшает количество, полож. - увеличивает количество)</param>
        public void UpdateStockProduct(int ingredientId, int diff)
        {
            this.stockProductsProvider.UpdateStockProduct(ingredientId, diff);
        }
    }
}
