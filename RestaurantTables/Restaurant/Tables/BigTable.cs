using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTables.Restaurant.Tables
{
    public class BigTable : Table
    {
        private const string Name = "BigTable";

        private readonly TimeSpan cleaningTime = TimeSpan.FromMinutes(1);

        public BigTable() : base(6)
        {
        }

        public override string TableName
        {
            get { return Name; }
        }

        public override void Free()
        {
            base.Free();
            Console.WriteLine("This table will be taken for {0} more to clean up.", this.cleaningTime);
            this.takenFor = this.cleaningTime;
        }
    }
}
