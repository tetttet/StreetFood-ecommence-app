using StreetFood.DAL;
using StreetFood.Entities;
using StreetFood.Repositories.Interfaces;

namespace StreetFood.Repositories.Implementations
{
    public class DishesRepository : IDishesRepository
    {
        public void AddDish(Dish dishEntity)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                streetFoodDbContext.Dishes.Add(dishEntity);
                streetFoodDbContext.SaveChanges();
            }
        }

        public Dish? GetById(int id)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                return streetFoodDbContext.Dishes.FirstOrDefault(x=>x.Id == id);
            }
        }
    }
}
