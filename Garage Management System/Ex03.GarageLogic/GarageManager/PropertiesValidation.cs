using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public static class PropertiesValidation
    {
        public static float PositiveFloatValidation(string i_stringToValidat)
        {
            float floatToReturn = 0;
            bool isFloat = float.TryParse(i_stringToValidat, out floatToReturn);
            if (!isFloat || floatToReturn < 0)
            {
                throw new FormatException("Input must contain only positive numbers");
            }

            return floatToReturn;
        }

        public static void PositiveIntEngineCapaityValidation(string i_stringToValidat)
        {
            int inputAsInt = 0;
            bool isInt = int.TryParse(i_stringToValidat, out inputAsInt);
            if (!isInt || inputAsInt < 0)
            {
                throw new FormatException("Impossible engine capacity. Input must contain only positive numbers");
            }
        }

        public static void ValidateCurrentAmount(float i_CurrentAmount, float i_MaxinalAmount)
        {
            bool isInRange = (i_CurrentAmount <= i_MaxinalAmount);
            if (!isInRange)
            {
                throw new ValueOutOfRangeException(0, i_MaxinalAmount);
            }
        }

        public static T EnumTryParse<T>(string i_userResponse, string i_enumName)
        {
            T inputAsEnum = default(T);
            bool isValid = false;
            foreach (string enumName in Enum.GetNames(typeof(T)))
            {
                if (enumName.Equals(i_userResponse, StringComparison.CurrentCultureIgnoreCase))
                {
                    inputAsEnum = (T)Enum.Parse(typeof(T), i_userResponse, true);
                    isValid = true;
                    break;
                }
            }

            if (!isValid)
            {
                throw new ArgumentException("Sorry, our garage can not handle with this type of " + i_enumName);
            }

            return inputAsEnum;
        }

        public static void EnumValidation<T>(string i_userResponse, string i_enumName)
        {
            EnumTryParse<T>(i_userResponse, i_enumName);
        }

        public static void CheckeIfAnswerIsYesOrNo(String i_Response)
        {
            if (!(i_Response.ToLower() == "yes" || i_Response.ToLower() == "no"))
            {
                throw new ArgumentException("Truck is carrying dangerous substance? please answer yes/no!");
            }
        }

        public static void ValidateLisenceNumber(String i_LisenceNumber)
        {
            bool isOnlyDigits = true;
            foreach (char c in i_LisenceNumber)
            {
                if (!char.IsDigit(c))
                {
                    isOnlyDigits = false;
                    break;
                }
            }

            if (!isOnlyDigits || i_LisenceNumber.Length != 8)
            {
                throw new ArgumentException("Lisence number must contain 8 digits");
            }
        }

        public static void ValidateNumberOfDoors(string i_userRespone)
        {
            i_userRespone.Replace(" ", string.Empty);
            if (!(i_userRespone.Equals("2") || i_userRespone.Equals("3") || i_userRespone.Equals("4") || i_userRespone.Equals("5")))
            {
                throw new ArgumentException("Sorry, our garage can not handle with this amount of doors");
            }
        }
    }
}