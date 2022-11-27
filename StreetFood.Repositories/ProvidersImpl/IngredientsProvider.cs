using StreetFood.BusinessObjects;
using StreetFood.Entities;
using StreetFood.Providers;
using StreetFood.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Repositories.ProvidersImpl
{
    public class IngredientsProvider : IIngredientsProvider
    {
        private IIngredientsRepository ingredientsRepository;

        public IngredientsProvider(IIngredientsRepository ingredientsRepository)
        {
            this.ingredientsRepository = ingredientsRepository;
        }

        public void AddIngreadient(IngredientBO ingredientBO)
        {
            Ingredient ingreadientEntites = new Ingredient()
            {
                Name = ingredientBO.Name,
                Code = ingredientBO.Code,
                DimensionType = ingredientBO.DimensionType
            };
            ingredientsRepository.AddIngreadient(ingreadientEntites);
        }

        public IngredientBO GetById(int id)
        {
            Ingredient ingredient = ingredientsRepository.GetById(id);
            IngredientBO ingredientBO = new IngredientBO() { Id=ingredient.Id, Name=ingredient.Name, Code=ingredient.Code, DimensionType=ingredient.DimensionType };
            if (ingredient == null)
            {
                return null;
            }
            else
            {
                return ingredientBO;
            }
        }

        public List<IngredientBO> GetIngredients()
        {
            var entities = ingredientsRepository.GetIngredients();
            
            List<IngredientBO> result = new List<IngredientBO>();
            result = entities.Select(e=> new IngredientBO()
            { 
                  Id=e.Id,
                  Name=e.Name,
                  Code=e.Code,
                  DimensionType=e.DimensionType
            }).ToList();//перекладвание поля entites в BO;
            // переложить объекты в result
            return result;
        }
    }
}
