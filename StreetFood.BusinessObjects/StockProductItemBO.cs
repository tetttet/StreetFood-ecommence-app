using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessObjects
{
    public class StockProductItemBO
    {
        public string IngredientName { get; set; }

        public string LastRevisionDateStr { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public int Count { get; set; }
    }
}
