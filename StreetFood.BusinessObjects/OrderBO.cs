using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessObjects
{
    public class OrderBO
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public DateTime OpenDate { get; set; }
        public decimal Sum { get; set; }
    }
}
