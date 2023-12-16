using System;

namespace xyz_airlines
{
    public class BookingList
    {
        private readonly int max;
        private int numPersons;
        private readonly Booking[] bookings;

        public BookingList(int max)
        {
            this.max = max;
            this.bookings = new Booking[max];
            this.numPersons = 0;
        }

        public bool Add(Booking booking)
        {
            // if there is room in the array, add the booking
            if (numPersons < max)
            {
                bookings[numPersons] = booking;
                numPersons++;
                return true;
            }
            return false;
        }

        public string PrintAll()
        {
            string output = "";
            // loop through all bookings and add them to the output string
            for (int i = 0; i < numPersons; i++)
            {
                output += "\n" + bookings[i].ToString() + "\tName: " + bookings[i].GetCustomer().GetFirstName() + " " + bookings[i].GetCustomer().GetLastName();
            }
            return output;
        }

        public void SaveToFile(string fileName)
        {
            // save the bookings to the file
            FileUtilities.SaveBookings(fileName, bookings, numPersons);
        }

        public void LoadFromFile(string fileName, FlightList flightList, CustomerList customerList)
        {
            // load the bookings from the file
            Booking[] temp = FileUtilities.LoadBookings(fileName, flightList.GetFlights(), customerList.GetCustomers());
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != null)
                {
                    Add(temp[i]);
                }
            }
        }
    }
}