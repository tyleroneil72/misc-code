using System;
using System.IO;

namespace xyz_airlines
{
    class FileUtilities
    {
        public static void SaveFlights(string location, Flight[] flights, int num)
        {
            using (StreamWriter outputStream = new StreamWriter(location))
            {
                outputStream.WriteLine(num);
                for (int x = 0; x < num; x++)
                {
                    // string written to file in this format
                    outputStream.WriteLine($"{flights[x].GetFlightNumber()} {flights[x].GetOrigin()} {flights[x].GetDestination()} {flights[x].GetCapacity()} {flights[x].GetNumberOfPassengers()}");
                }
            }
        }

        public static Flight[] LoadFlights(string location)
        {
            int num;
            string line;
            Flight[] temp;
            using (StreamReader inputStream = new StreamReader(location))
            {
                num = Convert.ToInt32(inputStream.ReadLine());
                temp = new Flight[num + 100];
                for (int x = 0; x < num; x++)
                {
                    line = inputStream.ReadLine() ?? "";
                    string[] tokens = line.Split();
                    // convert the string from the file to a flight object, Make number of passengers ZERO so it can be added later in load bookings
                    temp[x] = new Flight(Convert.ToInt32(tokens[0]), tokens[1], tokens[2], Convert.ToInt32(tokens[3]), 0);

                }
            }
            return temp;
        }

        public static void SaveBookings(string location, Booking[] bookings, int num)
        {
            using (StreamWriter outputStream = new StreamWriter(location))
            {
                outputStream.WriteLine(num);
                for (int x = 0; x < num; x++)
                {
                    // string written to file in this format
                    outputStream.WriteLine($"{bookings[x].GetDate()} {bookings[x].GetFlight().GetFlightNumber()} {bookings[x].GetCustomer().GetCustomerID()}");
                }
            }
        }

        public static Booking[] LoadBookings(string location, Flight[] flights, Customer[] customers)
        {
            int num;
            string line;
            Booking[] temp;
            using var inputStream = new StreamReader(location);
            num = Convert.ToInt32(inputStream.ReadLine());
            temp = new Booking[num + 100];
            for (int x = 0; x < num; x++)
            {
                line = inputStream.ReadLine() ?? "";
                string[] tokens = line.Split();
                // the last two tokens are parsed to integers
                if (tokens.Length >= 3 && int.TryParse(tokens[3], out int flightNumber) && int.TryParse(tokens[4], out int customerID))
                {
                    Flight flight = FindFlightByNumber(flightNumber, flights);
                    Customer customer = FindCustomerByID(customerID, customers);
                    // Add customer to flight passengers
                    flight.AddPassenger(customer);
                    // convert the string from the file to a booking object, spaces added to the date for proper format from split()
                    temp[x] = new Booking(tokens[0] + " " + tokens[1] + " " + tokens[2], flight, customer);
                }
            }
            return temp;
        }
        // Helper methods for LoadBookings to find flight by number
        private static Flight? FindFlightByNumber(int flightNumber, Flight[] flights)
        {
            foreach (Flight flight in flights)
            {
                if (flight != null && flight.GetFlightNumber() == flightNumber)
                {
                    return flight;
                }
            }
            return null;
        }
        // Helper methods for LoadBookings to find customer by ID
        private static Customer? FindCustomerByID(int customerID, Customer[] customers)
        {
            foreach (Customer customer in customers)
            {
                if (customer != null && customer.GetCustomerID() == customerID)
                {
                    return customer;
                }
            }
            return null;
        }

        public static void SaveCustomers(string location, Customer[] customers, int num)
        {
            using (StreamWriter outputStream = new StreamWriter(location))
            {
                outputStream.WriteLine(num);
                for (int x = 0; x < num; x++)
                {
                    // string written to file in this format
                    outputStream.WriteLine($"{customers[x].GetFirstName()} {customers[x].GetLastName()} {customers[x].GetPhone()} {customers[x].GetNumberOfBookings()}");
                }
            }
        }

        public static Customer[] LoadCustomers(string location)
        {
            int num;
            string line;
            Customer[] temp;
            using (StreamReader inputStream = new StreamReader(location))
            {
                num = Convert.ToInt32(inputStream.ReadLine());
                temp = new Customer[num + 100];
                for (int x = 0; x < num; x++)
                {
                    line = inputStream.ReadLine() ?? "";
                    string[] tokens = line.Split();
                    if (tokens.Length >= 4 && int.TryParse(tokens[3], out int numberOfBookings))
                    {
                        // convert the string from the file to a customer object
                        temp[x] = new Customer(tokens[0], tokens[1], tokens[2], numberOfBookings);
                    }
                }
            }
            return temp;
        }
    }
}