using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using RestaurantTables.Restaurant.Enums;
using RestaurantTables.Restaurant.Exceptions;
using RestaurantTables.Restaurant.Interfaces;

namespace RestaurantTables.Restaurant.Tables
{
    public abstract class Table : IStatus
    {
        private readonly int numberOfSeats;

        protected TimeSpan takenFor;

        private DateTime reservedUntil;

        protected Table(int numberOfSeats)
        {
            this.numberOfSeats = numberOfSeats;
            this.reservedUntil = DateTime.Now;
        }

        public bool Reserved
        {
            get { return DateTime.Now <= this.reservedUntil; }
        }

        public bool Taken
        {
            get { return this.takenFor != TimeSpan.Zero; }
        }

        public TableStatus Status
        {
            get
            {
                if (this.Reserved)
                {
                    return TableStatus.Reserved;
                }

                if (this.Taken)
                {
                    return TableStatus.Taken;
                }

                return TableStatus.Free;
            }
        }

        public abstract string TableName { get; }

        public bool CanAccomodate(int numberOfPeople)
        {
            return this.numberOfSeats >= numberOfPeople;
        }

        public bool Reserve()
        {
            if (this.Status == TableStatus.Free)
            {
                this.reservedUntil = DateTime.Now.AddMinutes(30);
                Console.WriteLine("Table {0} is now reserved until {1}.", this.TableName, this.reservedUntil);
                return true;
            }

            Console.WriteLine("Reservation failed. Table is already: {0}", this.Status);
            return false;
        }

        public virtual void Free()
        {
            if (this.Status != TableStatus.Free)
            {
                this.reservedUntil = DateTime.Now;
                this.takenFor = TimeSpan.Zero;
                Console.WriteLine("Table {0} is now free.", this.TableName);
                return;
            }

            throw new Exception("This table is already free.");
        }

        public void Take()
        {
            if (this.Status != TableStatus.Taken)
            {
                this.takenFor = TimeSpan.FromMinutes(30);
                Console.WriteLine("Someone has taken this table for {0}. It is unavailable now.", this.takenFor);
                return;
            }

            throw new TableTakenException("This table is already taken!");
        }
    }
}
