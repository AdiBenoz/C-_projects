using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    internal class ValidateUserChoice
    {
        public static bool IsInputInRange(int i_NumberOfUserChoice, int i_MaxValue)
        {
            return i_NumberOfUserChoice <= i_MaxValue;
        }

        public static int ReadAndValidateUserInput(string i_UserInput, int i_NumberOfOptions)
        {
            bool isValidInput = (int.TryParse(i_UserInput, out int choiceNumber) && 
                    IsInputInRange(choiceNumber, i_NumberOfOptions));
            while (!isValidInput)
            {
                Console.WriteLine("Invalid Input. Please try again");
                i_UserInput = Console.ReadLine();
                isValidInput = (int.TryParse(i_UserInput, out choiceNumber)
                    && IsInputInRange(choiceNumber, i_NumberOfOptions));
            }

            return choiceNumber;
        }
    }
}
