using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantTables.Restaurant.Enums;

namespace RestaurantTables.Restaurant.Interfaces
{
    public interface IStatus
    {
        TableStatus Status { get; }
    }
}
