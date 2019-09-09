using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly string r_MenuName;
        private readonly List<MenuItem> r_MenuItemsList;
        private MainMenu m_PreviousMenu = null;
        private const string k_ExitMessage = "Exit";
        private const string k_BackMessage = "Back";

        public MainMenu(string i_MenuName, List<MenuItem> i_MenuItemesList)
        {
            r_MenuName = i_MenuName;
            r_MenuItemsList = i_MenuItemesList;
        }

        public string MenuName
        {
            get
            {
                return r_MenuName;
            }
        }

        public List<MenuItem> MenuItemsList
        {
            get
            {
                return r_MenuItemsList;
            }
        }
        
        public MainMenu PreviousMenu
        {
            get
            {
                return m_PreviousMenu;
            }
            set
            {
                m_PreviousMenu = value;
            }
        }

        public void AddItemToMenu(MenuItem i_ElementToAdd)
        {
            r_MenuItemsList.Add(i_ElementToAdd);
        }

        public virtual void Show()
        {
            printMenuHeadLine();
            Console.WriteLine(displayMenu());
            string userInput = Console.ReadLine();
            int userChoiceNumber = ValidateUserChoice.ReadAndValidateUserInput(userInput, r_MenuItemsList.Count());
            Console.Clear();
            if(userChoiceNumber == 0)
            {
                if(PreviousMenu == null)
                {
                    Console.WriteLine("bye bye! perss ENTER to exit");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if(PreviousMenu != null)
                {
                    PreviousMenu.Show();
                }
            }
            else
            {
                r_MenuItemsList[userChoiceNumber - 1].MenuOfTheItem = this;
                r_MenuItemsList[userChoiceNumber - 1].ActionChosen();
            }
        }

        private void printMenuHeadLine()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(r_MenuName);
            Console.ResetColor();
            Console.WriteLine(" ");
        }

        private string displayMenu()
        {
            StringBuilder menuBuilder = new StringBuilder();
            int numberOfOptions = MenuItemsList.Count();
            int optionNumber = 1;
            foreach (MenuItem item in MenuItemsList)
            {
                menuBuilder.AppendLine(optionNumber + "." + item.ItemName);
                optionNumber++;
            }

            bool isMainMenu = PreviousMenu == null;
            string backOrExit = isMainMenu ? k_ExitMessage : k_BackMessage;
            menuBuilder.AppendLine(backOrExit);
            menuBuilder.AppendLine(string.Format("please enter your choice (1 to {0}) or enter 0 for {1}"
                , numberOfOptions, backOrExit));

            return menuBuilder.ToString();
        }
    }
}