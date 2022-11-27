using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.Entities
{
    public class Content
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
    }
}
