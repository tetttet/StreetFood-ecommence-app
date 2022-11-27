using StreetFood.Entities;

namespace StreetFood.Repositories.Interfaces
{
    public interface IDishesRepository
    {
        void AddDish(Dish dishEntity);
        Dish? GetById(int id);
    }
}
