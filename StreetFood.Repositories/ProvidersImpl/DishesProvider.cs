using StreetFood.BusinessObjects;
using StreetFood.Entities;
using StreetFood.Providers;
using StreetFood.Repositories.Interfaces;

namespace StreetFood.Repositories.ProvidersImpl
{
    public class DishesProvider : IDishesProvider
    {
        private IDishesRepository dishesRepository;

        public DishesProvider(IDishesRepository dishesRepository)
        {
            this.dishesRepository = dishesRepository;
        }

        public void AddDish(DishBO dish)
        {
            Dish dishEntites = new Dish()
            {
                Name = dish.Name,
                Price = dish.Price
            };
            dishesRepository.AddDish(dishEntites);
        }

        public DishBO? GetById(int id)
        {
            Dish? dish = dishesRepository.GetById(id);
            
            if (dish == null)
            {
                return null;
            }

            return new DishBO() { Id = dish.Id, Name = dish.Name, Price = dish.Price };
        }
    }
}
