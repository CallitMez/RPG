using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using RPG.Gui.Elements;
using RPG.Gui.Screens;

namespace RPG.Inventory
{
    class InventoryPlayer
    {
        List<InventorySlot> contentList;
        GuiList itemsToDraw;
        string fontName;

        public InventoryPlayer(InventoryScreen parent, string inventoryFont) : this(parent, inventoryFont, new Point(0, 0)) { }

        public InventoryPlayer(InventoryScreen parent, string inventoryFont, Point position)
        {
            contentList = new List<InventorySlot>();
            itemsToDraw = GuiList.createNewList(position, 10, new List<GuiLabel>(), 300);
            parent.addElement(itemsToDraw);
            fontName = inventoryFont;
        }

        public void addItem(Item item, int amount = 1)
        {
            // If we don't have the item, we can just add this whole stack.
            if (!containsItem(item))
            {
                contentList.Add(new InventorySlot(item, amount));
            }

            // If we have this item, we gotta stack it. 
            // If we can stack it, this will be done by stackItem.
            // If we can't stack it, we gotta add the item with the amount that could not be stacked to a new slot.
            else if (!stackItem(item, ref amount))
            {
                contentList.Add(new InventorySlot(item, amount));
            }

            // We have this item AND it can be stacked? This has already been done.

            // All that is left, is to update the labels
            updateItemsToDraw(this.fontName);
        }

        public bool containsItem(Item item)
        {
            foreach (InventorySlot slot in contentList)
            {
                if (slot.ItemType == item)
                    return true;
            }
            return false;
        }

        private bool stackItem(Item item, ref int amount)
        {
            foreach (InventorySlot slot in contentList)
            {
                // Make sure these items are of equal type before doing anything else
                if (slot.ItemType != item)
                    continue;

                // Check if we can stack this together
                if (slot.StackSize + amount < item.MaxStackSize)
                {
                    slot.StackSize += amount;
                    amount = 0;
                    return true;
                }
                int amountLeft = item.MaxStackSize - slot.StackSize;
                slot.StackSize += amountLeft;
                amount -= amountLeft;
            }
            return false;
        }

        /// <summary>
        /// Newest item is on top.
        /// </summary>
        /// <param name="fontName">The name of the font to use when drawing.</param>
        public void updateItemsToDraw(string fontName)
        {
            // First clear the list of Labels
            itemsToDraw.clear();

            // Check every single slot of the inventory
            for (int i = contentList.Count - 1; i >= 0; --i)
            {
                // This is the current inventory slot.
                InventorySlot slot = contentList[i];

                // If there are no items in this slot...
                if (slot.StackSize <= 0)
                {
                    // ... remove it, and continue
                    contentList.RemoveAt(i);
                    continue;
                }

                // Hey, we now know there ARE items in here. Let's make sure the GuiList knows about them.
                itemsToDraw.addLabel(slot.ToLabel(fontName));
            }
        }
    }
}
