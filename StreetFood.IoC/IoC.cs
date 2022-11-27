using Microsoft.EntityFrameworkCore.Diagnostics;
using StreetFood.BusinessLogic;
using StreetFood.BusinessLogic.Implementations;
using StreetFood.BusinessLogic.Interfaces;
using StreetFood.Entities;
using StreetFood.Repositories.Implementations;
using StreetFood.Repositories.ProvidersImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.IoC
{
    public class IoC
    {
        public static IIngredientsService GetIngredientsService() 
        {
            return new IngredientsService(new IngredientsProvider(new IngredientsRepository()));
        }

        public static IStockProductsService GetStockProductService()
        {
            return new StockProductsService(new StockProductsProvider(new StockProductsRepository()));
        }

        public static IDishesService GetDishService()
        {
            return new DishesService(new DishesProvider(new DishesRepository()));
        }

        public static IContentsService GetContentService()
        {
            return new ContentsService(new ContentsProvider(new ContentsRepository()));
        }

        public static IReportsService GetReportsService()
        {
            return new ReportsService(GetOrderService() , GetDishService());
        }
        public static IOrdersService GetOrderService()
        {
            return new OrdersService(
                new StockProductsService(
                    new StockProductsProvider(
                        new StockProductsRepository())),
                 new ContentsService((new ContentsProvider(new ContentsRepository()))),
                 new OrdersProvider(new OrdersRepository()),
                new DishesService(new DishesProvider(new DishesRepository())));
        }
    }
}
