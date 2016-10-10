using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Item
    {
        bool stackable; //TODO make this work
        string name;
        public Item(string name)
        {
            this.name = name;
        }
    }
}
