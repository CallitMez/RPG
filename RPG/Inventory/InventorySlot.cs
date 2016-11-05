using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Gui.Elements;
using Microsoft.Xna.Framework;

namespace RPG.Inventory
{
    class InventorySlot
    {
        Item item;
        int amount;

        public InventorySlot(Item item, int amount = 1)
        {
            this.item = item;
            this.amount = amount;
        }

        public GuiLabel ToLabel(string fontName)
        {
            string display = item.Name;
            if (amount > 1)
            {
                display += " " + amount;
            }
            return GuiLabel.createNewLabel(Vector2.Zero, display, fontName);
        }

        public Item ItemType => item;

        public int StackSize
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value >= item.MaxStackSize ? item.MaxStackSize : value;
            }
        }
    }
}
