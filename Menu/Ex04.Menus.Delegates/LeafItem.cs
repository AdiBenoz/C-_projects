using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public delegate void ActionsToExecuteDelegate();

    public class LeafItem : MenuItem
    {
        public event ActionsToExecuteDelegate ItemChosen;

        public LeafItem(string i_ItemName, ActionsToExecuteDelegate i_AddActionToActionsExecute)
        {
            ItemName = i_ItemName;
            ItemChosen += i_AddActionToActionsExecute;
        }

        public override void DoWhenChosen()
        {
            OnItemChosen();
            Console.ReadLine();
            Console.Clear();
            MenuOfTheItem.Show();
        }

        protected virtual void OnItemChosen()
        {
            if (ItemChosen != null)
            {
                ItemChosen.Invoke();
            }
        }
    }
}
