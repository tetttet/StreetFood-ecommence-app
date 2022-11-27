using StreetFood.BusinessObjects;
using StreetFood.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Providers
{
    public interface IDishesProvider
    {
        void AddDish(DishBO dish);
        DishBO? GetById(int id);
    }
}
