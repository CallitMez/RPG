using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory
{
    public class Item
    {
        private static Dictionary<string, Item> allItems = new Dictionary<string, Item>();
        int maxStackSize;
        string name;
        private Item(string name, int maxStackSize = 1)
        {
            this.name = name;
            this.maxStackSize = maxStackSize;
        }

        public static void loadItems(FileManager f)
        {
            allItems.Add("sword", new Item("sword"));
            allItems.Add("hpPot", new Item("hpPot", 5));
        }

        public static Item getItem(string name)
        {
            return allItems[name];
        }

        public int MaxStackSize => maxStackSize;
        public string Name => name;
    }
}
