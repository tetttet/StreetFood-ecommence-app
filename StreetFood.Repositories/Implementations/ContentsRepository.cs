using Microsoft.EntityFrameworkCore;
using StreetFood.DAL;
using StreetFood.Entities;
using StreetFood.Repositories.Interfaces;

namespace StreetFood.Repositories.Implementations
{
    public class ContentsRepository : IContentsRepository
    {
        public List<Content> GetContents()
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                return streetFoodDbContext.Contents.ToList();
            }
        }

        public List<Content> GetContentsByDishId(int dishId)
        {
            using (StreetFoodDbContext streetFoodDbContext = new StreetFoodDbContext())
            {
                return streetFoodDbContext.Contents.Where(c => c.DishId==dishId).ToList();
            }
        }
    }
}
