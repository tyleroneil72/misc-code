using System;

namespace xyz_airlines
{
    // Moved to separate file to clean up code
    class Menus
    {
        public static void DisplayMainMenu()
        {
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Please Select a choice from the menu below: |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| 1. Customers                                |");
            Console.WriteLine("| 2. Flights                                  |");
            Console.WriteLine("| 3. Bookings                                 |");
            Console.WriteLine("| 4. Exit                                     |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.Write(" Enter Your Choice: ");
        }

        public static void DisplayCustomerMenu()
        {
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Customer Menu                               |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Please Select a choice from the menu below: |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| 1. Add Customer                             |");
            Console.WriteLine("| 2. View Customers                           |");
            Console.WriteLine("| 3. Delete Customer                          |");
            Console.WriteLine("| 4. Back to Main Menu                        |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.Write(" Enter Your Choice: ");
        }

        public static void DisplayFlightMenu()
        {
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Flights Menu                                |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Please Select a Choice From The Menu Below: |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| 1. Add Flight                               |");
            Console.WriteLine("| 2. View Flights                             |");
            Console.WriteLine("| 3. View a Particular Flight                 |");
            Console.WriteLine("| 4. Delete Flight                            |");
            Console.WriteLine("| 5. Back to Main Menu                        |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.Write(" Enter Your Choice: ");
        }

        public static void DisplayBookingMenu()
        {
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Bookings Menu                               |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Please Select a choice from the menu below: |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| 1. Make Booking                             |");
            Console.WriteLine("| 2. View Bookings                            |");
            Console.WriteLine("| 3. Back to Main Menu                        |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.Write(" Enter Your Choice: ");
        }
    }
}