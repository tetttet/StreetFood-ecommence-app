using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using StreetFood.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessLogic.Implementations
{
    public class IngredientsService : IIngredientsService
    {
        private IIngredientsProvider ingredientsProvider;

        public IngredientsService(IIngredientsProvider ingredientsProvider)
        {
            this.ingredientsProvider = ingredientsProvider;
        }

        public List<IngredientBO> GetIngredients()
        {
            return ingredientsProvider.GetIngredients();
        }

        public void AddIngredient(IngredientBO ingredientBO)
        {
            ingredientsProvider.AddIngreadient(ingredientBO);
        }

        public IngredientBO GetById(int id)
        {
           return ingredientsProvider.GetById(id);
        }
    }
}
