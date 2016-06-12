using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantTables
{
    class Program
    {
        private static bool shouldFinish = false;

        private static Restaurant.Restaurant myRestaurant = new Restaurant.Restaurant();

        private static void Main(string[] args)
        {
            while (!shouldFinish)
            {
                Console.WriteLine("What do you want to do now?");
                var decision = Console.ReadLine();
                switch (decision)
                {
                    case "r":
                        Reserve();
                        break;
                    case "t":
                        Take();
                        break;
                    case "f":
                        Free();
                        break;
                    case "q":
                        shouldFinish = true;
                        break;
                    case "p":
                        myRestaurant.PrintTables();
                        Console.WriteLine("Restaurant's status: {0}", myRestaurant.Status);
                        break;
                    default:
                        PrintInfo();
                        break;
                }
            }
        }

        private static void Check()
        {
            Console.WriteLine("Give me the number of seats you need");
            try
            {
                if (myRestaurant.IsTableFree(int.Parse(Console.ReadLine())))
                {
                    Console.WriteLine("We have a free table that can accomodate this many people.");
                    return;
                }

                Console.WriteLine("Unfortunately, we do not have such a table.");
            }
            catch
            {
                Console.WriteLine("The number you've given is not right.");
            }
        }

        private static void Free()
        {
            Console.WriteLine("Give me the number of table you want to free.");
            try
            {
                myRestaurant.Free(int.Parse(Console.ReadLine()));
            }
            catch
            {
                Console.WriteLine("The number you've given is not right.");
            }
        }

        private static void Take()
        {
            Console.WriteLine("Give me the number of table you want to take.");
            try
            {
                myRestaurant.Take(int.Parse(Console.ReadLine()));
            }
            catch
            {
                Console.WriteLine("The number you've given is not right.");
            }
        }

        private static void Reserve()
        {
            Console.WriteLine("Give me the number of seats you want at the table.");
            try
            {
                myRestaurant.Reserve(int.Parse(Console.ReadLine()));
            }
            catch
            {
                Console.WriteLine("The number you've given is not right.");
            }
        }

        private static void PrintInfo()
        {
            Console.WriteLine("Options:\n\t\"r\" - reserve a table.\n\t\"t\" - take a table.\n\t\"f\" - free a table.\n\t\"q\" - quit the program.\n\t\"p\" - print current status of the restaurant.\n\tAny other - print info.");
        }
    }
}
