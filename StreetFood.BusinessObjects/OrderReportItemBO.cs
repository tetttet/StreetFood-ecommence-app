using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetFood.BusinessObjects
{
    public class OrderReportItemBO
    {
        public string DishName { get; set; }
        public decimal Sum { get; set; }
        public string SumStr => this.Sum.ToString("#.##");
        public DateTime Date { get; set; }
    }
}
