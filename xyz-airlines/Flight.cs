using System;

namespace xyz_airlines
{
    public class Flight
    {
        private readonly int flightNumber;
        private readonly string origin;
        private readonly string destination;
        private readonly int capacity;
        private int numberOfPassengers;
        private Customer[] passengers;

        public Flight(int flightNumber, string origin, string destination, int capacity, int numberOfPassengers = 0)
        {
            this.flightNumber = flightNumber++;
            this.origin = origin;
            this.destination = destination;
            this.capacity = capacity;
            this.numberOfPassengers = numberOfPassengers;
            this.passengers = new Customer[capacity];
        }

        // Getters
        public int GetFlightNumber() { return flightNumber; }
        public string GetOrigin() { return origin; }
        public string GetDestination() { return destination; }
        public int GetCapacity() { return capacity; }
        public int GetNumberOfPassengers() { return numberOfPassengers; }
        public string GetPassengers()
        {
            String s = "\nPassengers:";
            for (int i = 0; i < capacity; i++)
            {
                if (passengers[i] != null)
                {
                    s += "\nName: " + passengers[i].GetFirstName() + " " + passengers[i].GetLastName() + " ID: " + passengers[i].GetCustomerID();
                }
            }
            return s + "\n";
        }

        public void AddPassenger(Customer passenger)
        {
            passengers[numberOfPassengers] = passenger;
            numberOfPassengers++;
        }

        public override string ToString()
        {
            return (
                "Flight Number: " + flightNumber +
                "\tOrigin: " + origin +
                "\tDestination: " + destination +
                "\tCapacity: " + capacity +
                "\tNumber of Passengers: " + numberOfPassengers
            );
        }
    }
}