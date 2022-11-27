using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StreetFood.DAL;
using StreetFood.Entities;
using StreetFood.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Repositories.Implementations
{
    public class IngredientsRepository : IIngredientsRepository
    {
        public void AddIngreadient(Ingredient ingreadientEntity)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                streetFoodDbContext.Add(ingreadientEntity);
                streetFoodDbContext.SaveChanges();
            }
        }

        public Ingredient GetById(int id)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                Ingredient? ingredient = streetFoodDbContext.Ingredients.FirstOrDefault(e => e.Id == id);
                if (ingredient==null)
                {
                    return null;
                }
                else
                {
                    return ingredient;
                }
            }
        }

        public List<Ingredient> GetIngredients()
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                return streetFoodDbContext.Ingredients.ToList();
            }
        }
    }
}
