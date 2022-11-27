using StreetFood.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Providers
{
    public interface IIngredientsProvider//перевод entites в Bisobject
    {
        void AddIngreadient(IngredientBO ingredientBO);
        IngredientBO GetById(int id);
        List<IngredientBO> GetIngredients();
    }
}
