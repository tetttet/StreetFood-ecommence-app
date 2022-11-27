using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using StreetFood.Entities;
using StreetFood.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessLogic.Implementations
{
    public class DishesService : IDishesService
    {
        private IDishesProvider dishesProvider;

        public DishesService(IDishesProvider dishesProvider)
        {
            this.dishesProvider = dishesProvider;
        }

        public void AddDish(DishBO dish)
        {
            dishesProvider.AddDish(dish);
        }

        public DishBO? GetById(int id)
        {
            return dishesProvider.GetById(id);
        }
    }
}
