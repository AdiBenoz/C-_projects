using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Test;

namespace Ex04.Menus
{
    public class MenuInitialization
    {
        public static void InitializeUserMenus()
        {
            Interfaces.MainMenu interfaceMenu = createInterfaceMenu();
            interfaceMenu.Show();
            Delegates.MainMenu delegateMenu = createDelegateMenu();
            delegateMenu.Show();
        }

        private static Interfaces.MainMenu createInterfaceMenu()
        {
            List<Interfaces.MenuItem> showDateAndTime = new List<Interfaces.MenuItem>();
            Interfaces.MenuItem showTime = new Interfaces.LeafItem("Show Time", new MenuActions.ShowDateTimeData("HH:mm:ss"));
            Interfaces.MenuItem showDate = new Interfaces.LeafItem("Show Date", new MenuActions.ShowDateTimeData("dd-MM-yyyy"));
            showDateAndTime.Add(showTime);
            showDateAndTime.Add(showDate);
            List<Interfaces.MenuItem> showVersionAndDigits = new List<Interfaces.MenuItem>();
            Interfaces.MenuItem countDigits = new Interfaces.LeafItem("Count Digits", new MenuActions.CountDigits());
            Interfaces.MenuItem showVersion = new Interfaces.LeafItem("Show Version", new MenuActions.ShowVersion());
            showVersionAndDigits.Add(countDigits);
            showVersionAndDigits.Add(showVersion);
            Interfaces.MenuItem showDateAndTimeItem = new Interfaces.NodeItem("Show Date/Time", showDateAndTime);
            Interfaces.MenuItem showVersionAndDigitsItem = new Interfaces.NodeItem("Version and Digits", showVersionAndDigits);
            List<Interfaces.MenuItem> interfaceMenuItems = new List<Interfaces.MenuItem>();
            Interfaces.MainMenu interfaceMenu = new Interfaces.MainMenu("Interface Menu", interfaceMenuItems);
            interfaceMenu.AddItemToMenu(showDateAndTimeItem);
            interfaceMenu.AddItemToMenu(showVersionAndDigitsItem);

            return interfaceMenu;
        }
            
        private static Delegates.MainMenu createDelegateMenu()
        {
            List<Delegates.MenuItem> showDateAndTime = new List<Delegates.MenuItem>();
            Delegates.MenuItem showTime = new Delegates.LeafItem("Show Time", new MenuActions.ShowDateTimeData("HH:mm:ss").ExecuteAction);
            Delegates.MenuItem showDate = new Delegates.LeafItem("Show Date", new MenuActions.ShowDateTimeData("dd-MM-yyyy").ExecuteAction);
            showDateAndTime.Add(showTime);
            showDateAndTime.Add(showDate);
            List<Delegates.MenuItem> showVersionAndDigits = new List<Delegates.MenuItem>();
            Delegates.MenuItem countDigits = new Delegates.LeafItem("Count Digits", new MenuActions.CountDigits().ExecuteAction);
            Delegates.MenuItem showVersion = new Delegates.LeafItem("Show Version", new MenuActions.ShowVersion().ExecuteAction);
            showVersionAndDigits.Add(countDigits);
            showVersionAndDigits.Add(showVersion);
            Delegates.MenuItem showDateAndTimeItem = new Delegates.NodeItem("Show Date/Time", showDateAndTime);
            Delegates.MenuItem showVersionAndDigitsItem = new Delegates.NodeItem("Version and Digits", showVersionAndDigits);
            List<Delegates.MenuItem> delgateMenuItems = new List<Delegates.MenuItem>();
            Delegates.MainMenu delegateMenu = new Delegates.MainMenu("Delegate Menu", delgateMenuItems);
            delegateMenu.AddItemToMenu(showDateAndTimeItem);
            delegateMenu.AddItemToMenu(showVersionAndDigitsItem);

            return delegateMenu;
        }
    }
}