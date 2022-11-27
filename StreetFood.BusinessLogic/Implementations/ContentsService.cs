using StreetFood.BusinessLogic.Interfaces;
using StreetFood.BusinessObjects;
using StreetFood.Entities;
using StreetFood.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessLogic.Implementations
{
    public class ContentsService : IContentsService
    {
        private IContentsProvider contentsProvider;

        public ContentsService(IContentsProvider contentsProvider)
        {
            // провайдер будем получать через конструктоп
            this.contentsProvider = contentsProvider;
        }

        public List<ContentBO> GetContents()
        {
            return contentsProvider.GetContents();
        }
        
        /// <summary>
        /// Получить состав по dishId
        /// </summary>
        /// <param name="dishId"></param>
        /// <returns></returns>
        public List<ContentBO> GetContentsByDishId(int dishId)
        {
            // обратимся к провайдеру, чтобы получить состав по dishId
            return contentsProvider.GetContentsByDishId(dishId);
        }
    }
}
