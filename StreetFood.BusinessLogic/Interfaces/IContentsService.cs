using StreetFood.BusinessObjects;
using StreetFood.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessLogic.Interfaces
{
    public interface IContentsService
    {
        List<ContentBO> GetContents();
        
        /// <summary>
        /// Получить состав блюда по его Id
        /// </summary>
        List<ContentBO> GetContentsByDishId(int dishId);
    }
}
