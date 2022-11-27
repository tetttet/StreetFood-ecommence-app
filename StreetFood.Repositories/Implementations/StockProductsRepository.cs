using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StreetFood.DAL;
using StreetFood.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFood.BusinessObjects;
using StreetFood.Repositories.Interfaces;

namespace StreetFood.Repositories.Implementations
{
    public class StockProductsRepository : IStockProductsRepository
    {
        public void AddProduct(StockProduct stockProduct)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                streetFoodDbContext.Add(stockProduct);
                streetFoodDbContext.SaveChanges();
            }
        }

        public List<StockProduct> GetStockProducts()
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                return streetFoodDbContext.StockProducts.ToList();
            }
        }

        /// <summary>
        /// Метод обновления количества доступных продуктов/ингредиентов
        /// </summary>
        /// <param name="ingredientId">ИД ингредиента, который мы хотим поменять</param>
        /// <param name="diff">это изенение, на сколько (отриц - уменьшает количество, полож. - увеличивает количество)</param>
        public void UpdateStockProduct(int ingredientId, int diff)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                StockProduct? stockProduct = streetFoodDbContext.StockProducts.FirstOrDefault(x => x.IngredientId == ingredientId);
                if (stockProduct != null)
                {
                    stockProduct.Count = stockProduct.Count + diff;
                    streetFoodDbContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Такого продукта нету");
                }
            }
        }

        /// <summary>
        /// Получить какие продукты у нас есть на хранении по ingredientId
        /// </summary>
        /// <param name="ingredientId"></param>
        /// <returns></returns>
        public StockProductBO? GetByIngredientId(int ingredientId)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                // найдём продукт в БД
                StockProduct? stockProductEntity = streetFoodDbContext.StockProducts.FirstOrDefault(x=>x.IngredientId == ingredientId);
                if (stockProductEntity == null)
                {
                    return null;
                }

                // entity -> BO
                StockProductBO stockProductBO = new StockProductBO()
                {
                    Id = stockProductEntity.Id,
                    IngredientId = stockProductEntity.IngredientId,
                    Count = stockProductEntity.Count,
                    LastRevisionDate = stockProductEntity.LastRevisionDate,
                };
                
                return stockProductBO;
            }
        }
    }
}
