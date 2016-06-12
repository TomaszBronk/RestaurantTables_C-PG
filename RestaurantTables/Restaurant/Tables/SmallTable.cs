using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTables.Restaurant.Tables
{
    public class SmallTable : Table
    {
        private const string Name = "SmallTable";

        public SmallTable() : base(2)
        {
        }

        public override string TableName
        {
            get { return Name; }
        }
    }
}
