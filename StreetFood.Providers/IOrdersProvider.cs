using StreetFood.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreetFood.Entities;

namespace StreetFood.Providers
{
    public interface IOrdersProvider
    {
        void AddOrder(OrderBO orderBO);
        List<OrderBO> GetOrders();
    }
}
