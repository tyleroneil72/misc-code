using System;

namespace xyz_airlines
{
    public class CustomerList
    {
        private readonly int max;
        private int numPersons;
        private readonly Customer[] customers;

        public CustomerList(int max)
        {
            this.max = max;
            this.customers = new Customer[max];
            this.numPersons = 0;
        }

        public Customer[] GetCustomers() { return customers; }
        public bool Add(Customer customer)
        {
            // if there is room in the array, add the customer
            if (numPersons < max)
            {
                customers[numPersons] = customer;
                numPersons++;
                return true;
            }
            return false;
        }

        public bool Remove(Customer customer)
        {
            for (int i = 0; i < numPersons; i++)
            {
                // if the customer is found, remove them from the array
                if (customers[i].GetCustomerID() == customer.GetCustomerID())
                {
                    for (int j = i; j < numPersons - 1; j++)
                    {
                        customers[j] = customers[j + 1];
                    }
                    customers[numPersons - 1] = null;
                    numPersons--;
                    return true;
                }
            }
            return false;
        }

        public Customer Search(int customerID)
        {
            for (int i = 0; i < numPersons; i++)
            {
                // if the customer is found, return them
                if (customers[i].GetCustomerID() == customerID)
                {
                    return customers[i];
                }
            }
            return null;
        }

        public string PrintAll()
        {
            string s = "";
            // loop through all customers and add them to the output string
            for (int x = 0; x < numPersons; x++)
            {
                s += "\n" + customers[x].ToString();
            }
            return s;
        }

        public bool Exists(string firstName, string lastName, string phone)
        {
            for (int i = 0; i < numPersons; i++)
            {
                // if the customer is found, return true
                if (customers[i].GetFirstName() == firstName && customers[i].GetLastName() == lastName && customers[i].GetPhone() == phone)
                {
                    return true;
                }
            }
            return false;
        }

        public void SaveToFile(string fileName)
        {
            // save the customers to the file
            FileUtilities.SaveCustomers(fileName, customers, numPersons);
        }

        public void LoadFromFile(string fileName)
        {
            // load the customers from the file
            Customer[] temp = FileUtilities.LoadCustomers(fileName);
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