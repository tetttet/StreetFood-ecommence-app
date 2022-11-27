using StreetFood.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Providers
{
    public interface IStockProductsProvider
    {
        void AddProduct(StockProductBO stockProductBO);
        List<StockProductBO>? GetStockProducts();
        
        /// <summary>
        /// Метод обновления количества доступных продуктов/ингредиентов
        /// </summary>
        /// <param name="ingredientId">ИД ингредиента, который мы хотим поменять</param>
        /// <param name="diff">это изенение, на сколько (отриц - уменьшает количество, полож. - увеличивает количество)</param>
        void UpdateStockProduct(int ingredientId, int diff);
        StockProductBO? GetByIngredientId(int ingredientId);
    }
}
