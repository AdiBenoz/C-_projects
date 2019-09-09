using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class LeafItem : MenuItem
    {
        private readonly IExecutable r_ExceutableAction;

        public LeafItem(string i_ItemName, IExecutable i_ExceutableAction)
        {
            ItemName = i_ItemName;
            r_ExceutableAction = i_ExceutableAction;
        }

        public override void ActionChosen()
        {
            r_ExceutableAction.ExecuteAction();
            Console.ReadLine();
            Console.Clear();
            MenuOfTheItem.Show();
        }
    }
}