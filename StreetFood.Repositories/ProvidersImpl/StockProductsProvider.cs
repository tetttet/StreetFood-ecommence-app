using StreetFood.BusinessObjects;
using StreetFood.Entities;
using StreetFood.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFood.Repositories.Interfaces;

namespace StreetFood.Repositories.ProvidersImpl
{
    public class StockProductsProvider : IStockProductsProvider
    {
        private IStockProductsRepository stockProductsRepository;
        public StockProductsProvider(IStockProductsRepository stockProductsRepository)
        {
            this.stockProductsRepository = stockProductsRepository;
        }

        public void AddProduct(StockProductBO stockProductBO)
        {
            StockProduct stockProduct = new StockProduct();
            stockProduct.IngredientId = stockProductBO.IngredientId;
            stockProduct.Count = stockProductBO.Count;
            stockProduct.LastRevisionDate = stockProductBO.LastRevisionDate;
            stockProductsRepository.AddProduct(stockProduct);
        }

        public List<StockProductBO>? GetStockProducts()
        {
            List<StockProduct> stockProducts = stockProductsRepository.GetStockProducts();

            if (stockProducts == null)
            {
                return null;
            }
            else
            {
                List<StockProductBO> stockProductBOs = new List<StockProductBO>();
                foreach (var stockProduct in stockProducts)
                {
                    StockProductBO stockProductBO = new StockProductBO();
                    stockProductBO.Id = stockProduct.Id;
                    stockProductBO.Count = stockProduct.Count;
                    stockProductBO.IngredientId = stockProduct.IngredientId;
                    stockProductBO.LastRevisionDate = stockProduct.LastRevisionDate;
                    stockProductBOs.Add(stockProductBO);
                }

                return stockProductBOs;
            }
        }

        /// <summary>
        /// Метод обновления количества доступных продуктов/ингредиентов
        /// </summary>
        /// <param name="ingredientId">ИД ингредиента, который мы хотим поменять</param>
        /// <param name="diff">это изенение, на сколько (отриц - уменьшает количество, полож. - увеличивает количество)</param>
        public void UpdateStockProduct(int ingredientId, int diff)
        {
            this.stockProductsRepository.UpdateStockProduct(ingredientId, diff);
        }

        /// <summary>
        /// Gолучить какие продукты у нас есть на хранении по ingredientId
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        public StockProductBO? GetByIngredientId(int ingredientId)
        {
            // обратимся к репозиторию, чтобы получить какие продукты у нас есть на хранении по ingredientId
            return this.stockProductsRepository.GetByIngredientId(ingredientId);
        }
    }
}
