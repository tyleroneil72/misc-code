using System;

namespace xyz_airlines
{
    public class FlightList
    {
        private readonly int max;
        private int numPersons;
        private readonly Flight[] flights;

        public FlightList(int max)
        {
            this.max = max;
            this.flights = new Flight[max];
            this.numPersons = 0;
        }

        public Flight[] GetFlights() { return flights; }

        public bool Add(Flight flight)
        {
            // if there is room in the array, add the flight
            if (numPersons < max)
            {
                flights[numPersons] = flight;
                numPersons++;
                return true;
            }
            return false;
        }

        public bool Remove(Flight flight)
        {
            for (int i = 0; i < numPersons; i++)
            {
                // if the flight is found, remove it from the array
                if (flights[i].GetFlightNumber() == flight.GetFlightNumber())
                {
                    for (int j = i; j < numPersons - 1; j++)
                    {
                        flights[j] = flights[j + 1];
                    }
                    flights[numPersons - 1] = null;
                    numPersons--;
                    return true;
                }
            }
            return false;
        }

        public Flight Search(int flightNumber)
        {
            for (int i = 0; i < numPersons; i++)
            {
                // if the flight is found, return it
                if (flights[i].GetFlightNumber() == flightNumber)
                {
                    return flights[i];
                }
            }
            return null;
        }

        public string PrintAll()
        {
            string output = "";
            // loop through all flights and add them to the output string
            for (int i = 0; i < numPersons; i++)
            {
                output += "\n" + flights[i].ToString();
            }
            return output;
        }

        public bool Exists(int flightNumber)
        {
            for (int i = 0; i < numPersons; i++)
            {
                // if the flight is found, return true
                if (flights[i].GetFlightNumber() == flightNumber)
                {
                    return true;
                }
            }
            return false;
        }

        public void SaveToFile(string fileName)
        {
            // save the flights to the file
            FileUtilities.SaveFlights(fileName, flights, numPersons);
        }

        public void LoadFromFile(string fileName)
        {
            Flight[] temp = FileUtilities.LoadFlights(fileName);
            // load the flights from the file
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