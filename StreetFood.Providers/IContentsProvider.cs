using StreetFood.BusinessObjects;
using StreetFood.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Providers
{
    public interface IContentsProvider
    {
        List<ContentBO> GetContents();
        
        /// <summary>
        /// Получить состав по dishId
        /// </summary>
        /// <param name="dishId"></param>
        /// <returns></returns>
        List<ContentBO> GetContentsByDishId(int dishId);
    }
}
