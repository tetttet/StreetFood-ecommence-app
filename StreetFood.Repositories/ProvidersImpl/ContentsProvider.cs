using StreetFood.BusinessObjects;
using StreetFood.Entities;
using StreetFood.Providers;
using StreetFood.Repositories.Interfaces;

namespace StreetFood.Repositories.ProvidersImpl
{
    public class ContentsProvider : IContentsProvider
    {
        private readonly IContentsRepository contentsRepository;

        public ContentsProvider(IContentsRepository contentsRepository)
        {
            this.contentsRepository = contentsRepository;
        }

        public List<ContentBO> GetContents()
        {
            List<Content> contents = contentsRepository.GetContents();

            List<ContentBO> result = new List<ContentBO>();
            foreach (var content in contents)
            {
                ContentBO contentBO = new ContentBO()
                {
                    Id = content.Id,
                    DishId = content.DishId,
                    IngredientId = content.IngredientId,
                    Count = content.Count
                };

                result.Add(contentBO);
            }

            return result;
        }

        public List<ContentBO> GetContentsByDishId(int dishId)
        {
            // обратимся к репозиторию, чтобы получить состав по dishId
            List<Content> contents = contentsRepository.GetContentsByDishId(dishId);

            // подготовим результирующую переменную
            List<ContentBO> result = new List<ContentBO>();
            foreach (var content in contents)
            {
                // перекладываем данные из entity в BO
                ContentBO contentBO = new ContentBO()
                {
                    Id = content.Id,
                    DishId = content.DishId,
                    IngredientId = content.IngredientId,
                    Count = content.Count
                };

                result.Add(contentBO);
            }

            return result;
        }
    }
}
