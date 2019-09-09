using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.RegularExpressions.Regex;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public static class UIValidation
    {
        public static string ReadAndValidateNameFormat(string io_FullName)
        {
            bool isValidName = IsLegalName(io_FullName);
            while (!isValidName)
            {
                Console.WriteLine("please enter a valid name");
                io_FullName = Console.ReadLine();
                isValidName = IsLegalName(io_FullName);
            }
            return io_FullName;
        }

        public static bool IsLegalName(string i_CustomerResponse)
        {
            bool isLegalName = true;
            foreach (char c in i_CustomerResponse)
            {
                if (!(char.IsLetter(c) || c == ' '))
                {
                    isLegalName = false;
                    break;
                }
            }

            return isLegalName;
        }

        public static string ReadValidateNumberSequence(String io_PhoneNumber, int length)
        {
            bool isOnlyDigits =IsOnlyDigits(io_PhoneNumber);
            while (!isOnlyDigits || io_PhoneNumber.Length != length)
            {
                Console.WriteLine("invalid number. please enter {0} digits:", length);
                io_PhoneNumber = Console.ReadLine();
                isOnlyDigits = IsOnlyDigits(io_PhoneNumber);
            }

            return io_PhoneNumber;
        }


        public static bool IsOnlyDigits(string i_CustomerResponse)
        {
            bool isNumeric = true;
            foreach (char c in i_CustomerResponse)
            {
                if (!char.IsDigit(c))
                {
                    isNumeric = false;
                    break;
                }
            }

            return isNumeric;
        }

        public static string ValidateChoiceNumberInRange(int i_LowerBoundOfChoice, int i_UpperBoundOfChoice, string io_Choice)
        {
            int choiceNumber = 0;
            bool isValidNumber = int.TryParse(io_Choice, out choiceNumber);
            while (!isValidNumber || choiceNumber < i_LowerBoundOfChoice || choiceNumber > i_UpperBoundOfChoice)
            {
                Console.WriteLine("invalid input. please choose a number between {0} to {1} from the options above", i_LowerBoundOfChoice, i_UpperBoundOfChoice);
                io_Choice = Console.ReadLine();
                isValidNumber = int.TryParse(io_Choice, out choiceNumber);
            }

            return io_Choice;
        }
    }
}
