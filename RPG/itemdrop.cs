using RPG.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class ItemDrop
    {
        public Item drop;
        public double chance;
        public ItemDrop(Item drop, double chance)
        {
            this.drop = drop;
            this.chance = chance;
        }
       
    }
}
