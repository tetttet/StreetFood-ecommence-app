using StreetFood.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessLogic.Interfaces
{
    public interface IStockProductsService
    {
        void AddProduct(StockProductBO stockProductBO);
        List<StockProductBO> GetStockProducts();

        StockProductBO? GetByIngredientId(int ingredientId);
        void UpdateStockProduct(int ingredientId, int diff);
    }
}
