using System;
using System.IO;

namespace xyz_airlines
{
    class Program
    {
        public static Coordinator coordinator;

        public static void Main(string[] args)
        {
            Console.Clear();

            FlightList flightList = new FlightList(100);
            BookingList bookingList = new BookingList(100);
            CustomerList customerList = new CustomerList(100);

            // Load the data from the files if they exist
            if (File.Exists("flights.txt"))
            {
                flightList.LoadFromFile("flights.txt");
            }
            if (File.Exists("customers.txt"))
            {
                customerList.LoadFromFile("customers.txt");
            }
            if (File.Exists("bookings.txt"))
            {
                bookingList.LoadFromFile("bookings.txt", flightList, customerList);
            }

            coordinator = new Coordinator(flightList, bookingList, customerList);

            RunProgram();

            // Save the data to the files after program ends
            flightList.SaveToFile("flights.txt");
            bookingList.SaveToFile("bookings.txt");
            customerList.SaveToFile("customers.txt");
        }

        // Main Program loop
        public static void RunProgram()
        {
            string input;
            do
            {
                Menus.DisplayMainMenu();
                input = InputUtilities.GetValidInput();
                HandleMenuSelection(input);
            } while (input != "4");

            Console.WriteLine("Thank you for using XYZ Airlines Limited.");
            Console.Write("\nPress Enter To Exit...");
            Console.ReadLine();
        }

        public static void HandleMenuSelection(string selected)
        {
            switch (selected)
            {
                case "1": // Customer Menu
                    Console.Clear();
                    HandleCustomerMenu();
                    break;
                case "2": // Flight Menu
                    Console.Clear();
                    HandleFlightMenu();
                    break;
                case "3": // Booking Menu
                    Console.Clear();
                    HandleBookingMenu();
                    break;
                case "4": // Exit the program
                    Console.Clear();
                    break;
                default: // Any other input
                    Console.Clear();
                    Console.WriteLine("Invalid Input of \"" + selected + "\". Please Try Again Below.");
                    break;
            }
        }

        public static void HandleCustomerMenu()
        {
            string customerChoice = "";
            // Loop until the user chooses to exit
            while (customerChoice != "4")
            {
                Menus.DisplayCustomerMenu();
                customerChoice = InputUtilities.GetValidInput();
                switch (customerChoice)
                {
                    case "1": // Add Customer
                        Console.Clear();
                        AddCustomerProcess();
                        break;
                    case "2": // View Customers
                        Console.Clear();
                        ViewCustomersProcess();
                        break;
                    case "3": // Delete Customer
                        Console.Clear();
                        Console.WriteLine("Delete Customer");
                        DeleteCustomerProcess();
                        break;
                    case "4": // Exit
                        Console.Clear();
                        break;
                    default: // Any other input
                        Console.Clear();
                        Console.WriteLine("Invalid Input of \"" + customerChoice + "\". Please Try Again Below.");
                        break;
                }
            }
        }

        public static void AddCustomerProcess()
        {
            Console.Clear();

            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Add Customer                                |");
            Console.WriteLine("+" + new string('-', 45) + "+");

            string firstName, lastName, phone;

            firstName = InputUtilities.GetValidInput(" Enter First Name: ");
            lastName = InputUtilities.GetValidInput(" Enter Last Name: ");
            phone = InputUtilities.GetValidInputStrNumber(" Enter Phone: ");

            Console.WriteLine("+" + new string('-', 45) + "+");

            if (coordinator.AddCustomer(firstName, lastName, phone))
            {
                Console.WriteLine(" Customer Added Successfully.");
            }
            else
            {
                Console.WriteLine(" Sorry, The Customer Could Not Be Added.");

            }

            Console.Write("\nPress Enter To Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void ViewCustomersProcess()
        {
            Console.Clear();

            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| View Customers                              |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine(coordinator.ViewCustomers());
            Console.WriteLine("+" + new string('-', 45) + "+");

            Console.Write("\nPress Enter To Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void DeleteCustomerProcess()
        {
            Console.Clear();

            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Delete Customer                             |");
            Console.WriteLine("+" + new string('-', 45) + "+");

            // Not using the helper method here because we want to allow the user to exist after entering an invalid input
            Console.Write(" Enter Customer ID: ");
            string customerId = InputUtilities.GetValidInput();
            Console.WriteLine("+" + new string('-', 45) + "+");
            if (int.TryParse(customerId, out int parsedCustomerId))
            {
                bool isDeleted = coordinator.DeleteCustomer(parsedCustomerId);

                if (isDeleted)
                {
                    Console.WriteLine(" Customer Deleted Successfully.");
                }
                else
                {
                    Console.WriteLine(" Sorry, The Customer Could Not Be Deleted.");
                }
            }
            else
            {
                Console.WriteLine(" Invalid customer ID. Please enter a valid integer.");
            }

            Console.Write("\nPress Enter To Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void HandleFlightMenu()
        {
            string flightChoice = "";
            // Loop until the user chooses to exit
            while (flightChoice != "5")
            {
                Menus.DisplayFlightMenu();
                flightChoice = InputUtilities.GetValidInput();
                switch (flightChoice)
                {
                    case "1": // Add Flight
                        Console.Clear();
                        AddFlightProcess();
                        break;
                    case "2": // View Flights
                        Console.Clear();
                        ViewFlightsProcess();
                        break;
                    case "3": // View Specific Flight
                        Console.Clear();
                        ViewSpecificFlightProcess();
                        break;
                    case "4": // Delete Flight
                        Console.Clear();
                        DeleteFlightProcess();
                        break;
                    case "5": // Exit To Main Menu
                        Console.Clear();
                        break;
                    default: // Any other input
                        Console.Clear();
                        Console.WriteLine("Invalid Input of \"" + flightChoice + "\". Please Try Again Below.");
                        break;
                }
            }
        }

        public static void AddFlightProcess()
        {
            Console.Clear();

            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Add Flight                                  |");
            Console.WriteLine("+" + new string('-', 45) + "+");

            int flightNumber = InputUtilities.GetValidInputNumber(" Enter Flight Number: ");
            string departureCity = InputUtilities.GetValidInput(" Enter Departure City: ");
            string arrivalCity = InputUtilities.GetValidInput(" Enter Arrival City: ");
            int capacity = InputUtilities.GetValidInputNumber(" Enter Capacity: ");

            Console.WriteLine("+" + new string('-', 45) + "+");

            if (coordinator.AddFlight(flightNumber, departureCity, arrivalCity, capacity, 0))
            {
                Console.WriteLine(" Flight added successfully!");
            }
            else
            {
                Console.WriteLine(" Sorry, The Flight Could Not Be Added.");
            }

            Console.Write("\nPress Enter To Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void ViewFlightsProcess()
        {
            Console.Clear();

            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| View Flights                                |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine(coordinator.ViewFlights());
            Console.WriteLine("+" + new string('-', 45) + "+");

            Console.Write("\nPress Enter To Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void ViewSpecificFlightProcess()
        {
            Console.Clear();

            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| View a Particular Flight                    |");
            Console.WriteLine("+" + new string('-', 45) + "+");

            string conditionalText = coordinator.ViewFlights();
            Console.WriteLine(conditionalText);
            Console.WriteLine("+" + new string('-', 45) + "+");
            // Not using helper method here because we want to allow the user to exit after entering an invalid input
            if (conditionalText != " No Flights Yet...")
            {
                Console.Write(" Enter Specific Flight Number From Above: ");
                string flightNumber = InputUtilities.GetValidInput();

                if (int.TryParse(flightNumber, out int parsedFlightNumber))
                {
                    Console.WriteLine("\n" + coordinator.ViewSpecificFlight(parsedFlightNumber));
                }
                else
                {
                    Console.WriteLine("\n Invalid flight number. Please enter a valid integer.");
                }
                Console.WriteLine("+" + new string('-', 45) + "+");
            }

            Console.Write("\nPress Enter To Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void DeleteFlightProcess()
        {
            Console.Clear();

            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Delete Flight                               |");
            Console.WriteLine("+" + new string('-', 45) + "+");

            string conditionalText = coordinator.ViewFlights();
            Console.WriteLine(conditionalText);
            Console.WriteLine("+" + new string('-', 45) + "+");

            if (conditionalText != " No Flights Yet...")
            {

                Console.Write(" Enter Flight Number: ");
                string flightNumber = InputUtilities.GetValidInput();
                // Dont loop this in case the user wants to exit
                if (int.TryParse(flightNumber, out int parsedFlightNumber))
                {
                    bool isDeleted = coordinator.DeleteFlight(parsedFlightNumber);

                    if (isDeleted)
                    {
                        Console.WriteLine(" Flight Deleted Successfully.");
                    }
                    else
                    {
                        Console.WriteLine(" Sorry, The Flight Could Not Be Deleted.");
                    }
                }
                else
                {
                    Console.WriteLine(" Invalid flight number. Please enter a valid integer.");
                }
                Console.WriteLine("+" + new string('-', 45) + "+");
            }

            Console.Write("\nPress Enter To Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void HandleBookingMenu()
        {
            string bookingChoice = "";
            // Loop until the user chooses to exit
            while (bookingChoice != "3")
            {
                Menus.DisplayBookingMenu();
                bookingChoice = InputUtilities.GetValidInput();
                switch (bookingChoice)
                {
                    case "1": // Make Booking
                        Console.Clear();
                        MakeBookingProcess();
                        break;
                    case "2": // View Bookings
                        Console.Clear();
                        ViewBookingsProcess();
                        break;
                    case "3": // Exit To Menu
                        Console.Clear();
                        break;
                    default: // Any other input
                        Console.Clear();
                        Console.WriteLine("Invalid Input of \"" + bookingChoice + "\". Please Try Again Below.");
                        break;
                }
            }
        }

        public static void MakeBookingProcess()
        {
            Console.Clear();

            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| Make Booking                                |");
            Console.WriteLine("+" + new string('-', 45) + "+");

            string conditionalFlightText = coordinator.ViewFlights();
            string conditionalCustomerText = coordinator.ViewCustomers();
            Console.WriteLine("Flights: \n" + conditionalFlightText);
            Console.WriteLine("\nCustomers: \n" + conditionalCustomerText);
            // You can only book when there is a flight and a customer
            if (conditionalFlightText != " No Flights Yet..." && conditionalCustomerText != " No Customers Yet...")
            {
                Console.WriteLine("+" + new string('-', 45) + "+");
                string date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
                int flightNumber = InputUtilities.GetValidInputNumber(" Enter Flight Number: ");
                int customerId = InputUtilities.GetValidInputNumber(" Enter Customer ID: ");

                // Dont loop this in case the user wants to exit
                bool isBooked = coordinator.MakeBooking(date, flightNumber, customerId);

                if (isBooked)
                {
                    Console.WriteLine(" Booking Made Successfully.");
                }
                else
                {
                    Console.WriteLine(" Sorry, The Booking Could Not Be Made.");
                }
            }
            Console.WriteLine("+" + new string('-', 45) + "+");

            Console.Write("\nPress Enter To Continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public static void ViewBookingsProcess()
        {
            Console.Clear();

            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| XYZ Airlines Limited.                       |");
            Console.WriteLine("+" + new string('-', 45) + "+");
            Console.WriteLine("| View Bookings                               |");
            Console.WriteLine("+" + new string('-', 45) + "+");

            Console.WriteLine(coordinator.ViewBookings());
            Console.WriteLine("+" + new string('-', 45) + "+");

            Console.Write("\nPress Enter To Continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}