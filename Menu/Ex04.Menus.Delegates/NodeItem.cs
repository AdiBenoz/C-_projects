using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class NodeItem : MenuItem
    {
        private readonly List<MenuItem> r_MenuItemsInsideNode;

        public NodeItem(string i_ItemName, List<MenuItem> i_MenuItemsInsideNode)
        {
            r_MenuItemsInsideNode = i_MenuItemsInsideNode;
            ItemName = i_ItemName;
        }

        public override void DoWhenChosen()
        {
            Console.Clear();
            MainMenu currentMenu = new MainMenu(ItemName, r_MenuItemsInsideNode);
            currentMenu.PreviousMenu = MenuOfTheItem;
            currentMenu.Show();
        }
    }
}