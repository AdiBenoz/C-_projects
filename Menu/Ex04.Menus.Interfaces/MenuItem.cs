using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private string m_ItemName;
        private MainMenu m_MenuOfTheItem;

       public string ItemName
       {
            get
            {
                return m_ItemName;
            }
            set
            {
                m_ItemName = value;
            }
       }

        public MainMenu MenuOfTheItem
        {
            get
            {
                return m_MenuOfTheItem;
            }
            set
            {
                m_MenuOfTheItem = value;
            }
        } 

       public abstract void ActionChosen();
    }
}
