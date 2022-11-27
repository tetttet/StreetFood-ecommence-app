using StreetFood.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessLogic.Interfaces
{
    public interface IIngredientsService
    {
        List<IngredientBO> GetIngredients();
        void AddIngredient(IngredientBO ingredientBO);
       IngredientBO GetById(int id);
    }
}
