using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTables.Restaurant.Exceptions
{
    public class TableTakenException : Exception
    {
        public TableTakenException(string message) : base(message)
        {
        }

        public TableTakenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
