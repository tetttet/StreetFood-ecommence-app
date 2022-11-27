using StreetFood.BusinessObjects;
using StreetFood.Entities;

namespace StreetFood.Repositories.Interfaces
{
    public interface IStockProductsRepository
    {
        void AddProduct(StockProduct stockProduct);
        List<StockProduct> GetStockProducts();
        
        /// <summary>
        /// Метод обновления количества доступных продуктов/ингредиентов
        /// </summary>
        /// <param name="ingredientId">ИД ингредиента, который мы хотим поменять</param>
        /// <param name="diff">это изенение, на сколько (отриц - уменьшает количество, полож. - увеличивает количество)</param>
        void UpdateStockProduct(int ingredientId,int diff);
        
        /// <summary>
        /// Получить какие продукты у нас есть на хранении по ingredientId
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        StockProductBO? GetByIngredientId(int ingredientId);
    }
}
