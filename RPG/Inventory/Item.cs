using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory
{
    class Item
    {
        bool stackable; //TODO make this work
                        // How about making this an int called maxStackSize? -Ebilkill
        string name;
        public Item(string name)
        {
            this.name = name;
        }
    }
}
