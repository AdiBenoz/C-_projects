using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class MenuActions
    {
        public class ShowDateTimeData : IExecutable
        {
            public string m_DesiredDateTimeData;

            public ShowDateTimeData(string i_DesiredDateTimeData)
            {
                m_DesiredDateTimeData = i_DesiredDateTimeData;
            }

            public void ExecuteAction()
            {
                Console.WriteLine(DateTime.Now.ToString(m_DesiredDateTimeData));
            }
        }

        public class CountDigits : IExecutable
        { 
            public void ExecuteAction()
            {
                Console.WriteLine("Please enter a sentence");
                string userSentence = Console.ReadLine();
                int numberOfDigits = 0;
                for(int i=0; i<userSentence.Length; i++)
                {
                    if (char.IsDigit(userSentence[i]))
                    {
                        numberOfDigits++;
                    }
                }

                Console.WriteLine("The number of Digits in your sentence is {0}", numberOfDigits);
            }
        }

        public class ShowVersion : IExecutable
        {
            private const string k_Version = "Version: 19.2.4.32";

            public void ExecuteAction()
            {
                Console.WriteLine(k_Version);
            }
        }
    }
}
