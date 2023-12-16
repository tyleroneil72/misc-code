using System;

namespace xyz_airlines
{
    // Moved to Separate File to clean up code
    class InputUtilities
    {
        // Phone number can have () or - in it, just no spaces
        public static string GetValidInputStrNumber(string question)
        {
            string input = "";
            while (string.IsNullOrEmpty(input) || ContainsSpace(input))
            {
                Console.Write(question);
                input = GetValidInput(); // Normal one
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(" \n Invalid Input. Please Enter a Valid Number\n");
                }
                else if (ContainsSpace(input))
                {
                    Console.WriteLine(" \n Invalid Input. Please Enter a Valid Number Without Spaces\n");
                }
            }

            return input;
        }

        // Helper method to check if a string contains a space
        private static bool ContainsSpace(string input)
        {
            foreach (char c in input)
            {
                if (char.IsWhiteSpace(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static int GetValidInputNumber(string question)
        {
            string input = "";
            while (string.IsNullOrEmpty(input))
            {
                Console.Write(question);
                input = GetValidInput(); // Normal one
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(" \n Invalid Input. Please Enter a Valid Number\n");
                }
                else if (!int.TryParse(input, out int parsedInput))
                {
                    Console.WriteLine(" \n Invalid Input. Please Enter a Valid Number\n");
                    input = "";
                }
            }
            return int.Parse(input);
        }

        public static string GetValidInput()
        {
            string input = Console.ReadLine() ?? ""; // If null, set to empty string (Just so IDE Stops warning)  
            return input;
        }

        // Helper method to get valid input with a question for processes
        public static string GetValidInput(string question)
        {
            string input = "";
            while (string.IsNullOrEmpty(input) || ContainsNumber(input))
            {
                Console.Write(question);
                input = GetValidInput(); // Normal one
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(" \n Invalid Input. Please Enter a Valid String.\n");
                }
                else if (ContainsNumber(input))
                {
                    Console.WriteLine(" \n Invalid Input. Please Enter a Valid String Without Numbers or Spaces\n");
                }
            }

            return input;
        }

        // Helper method to check if a string contains a number
        private static bool ContainsNumber(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c) || char.IsWhiteSpace(c))
                {
                    return true;
                }
            }
            return false;
        }
    }
}