using StreetFood.Entities;

namespace StreetFood.Repositories.Interfaces
{
    public interface IContentsRepository
    {
        public List<Content> GetContents();

        public List<Content> GetContentsByDishId(int dishId);
    }
}
