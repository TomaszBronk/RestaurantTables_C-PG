using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantTables.Restaurant.Enums;
using RestaurantTables.Restaurant.Exceptions;
using RestaurantTables.Restaurant.Interfaces;
using RestaurantTables.Restaurant.Tables;

namespace RestaurantTables.Restaurant
{
    public class Restaurant : IStatus
    {
        private Dictionary<int, Table> tables;

        public Restaurant()
        {
            this.tables = new Dictionary<int, Table>
            {
                {1, new SmallTable()},
                {2, new SmallTable()},
                {3, new SmallTable()},
                {4, new BigTable()},
                {5, new BigTable()},
                {6, new BigTable()}
            };
        }

        public bool IsTableFree(int numberOfSeats)
        {
            return this.tables.Values.Any(GetAvailableTablePredicate(numberOfSeats));
        }

        public bool Reserve(int numberOfSeats)
        {
            if (this.IsTableFree(numberOfSeats))
            {
                var table = this.tables.Values.FirstOrDefault(GetAvailableTablePredicate(numberOfSeats));
                if (table != null && table.Reserve())
                {
                    Console.WriteLine("Table no. {0} is now reserved.", this.tables.Single(x => x.Value == table).Key);
                    return true;
                }
            }

            return false;
        }

        public void Take(int numberOfTable)
        {
            try
            {
                this.tables[numberOfTable].Take();
            }
            catch (TableTakenException exception)
            {
                Console.WriteLine("Could not take table no. {0}. See exception message: {1}", numberOfTable, exception.Message);
            }
        }

        public void Free(int numberOfTable)
        {
            try
            {
                this.tables[numberOfTable].Free();
                Console.WriteLine("Table no. {0} is now free", numberOfTable);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Could not free table no. {0}, see exception message: {1}", numberOfTable, exception.Message);
            }
        }

        private Func<Table, bool> GetAvailableTablePredicate(int numberOfSeats)
        {
            return table => !table.Reserved && table.CanAccomodate(numberOfSeats);
        }

        public void PrintTables()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Printing tables' info.");
            foreach (var table in this.tables)
            {
                Console.WriteLine("{0}) Name: {1}, Status: {2}", table.Key, table.Value.TableName, table.Value.Status);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public TableStatus Status
        {
            get
            {
                if (this.tables.Values.Any(table => ((IStatus) table).Status == TableStatus.Free))
                {
                    return TableStatus.Free;
                }

                if (this.tables.Values.Any(table => ((IStatus)table).Status == TableStatus.Reserved))
                {
                    return TableStatus.Reserved;
                }

                return TableStatus.Taken;
            }
        }
    }
}
