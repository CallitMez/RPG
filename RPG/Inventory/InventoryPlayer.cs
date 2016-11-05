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
    public class InventoryPlayer
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
            // Make sure the amount to add is positive
            if (amount <= 0)
                throw new ArgumentException("Amount must be > 0, but found " + amount);

            // If we don't have the item, we can just add this whole stack.
            // if we do, stack what we can and then add the rest of the stack
            if (!containsItem(item) || !stackItem(item, ref amount))
            {
                // Add this item in proper stacks
                int stacks = amount / item.MaxStackSize;
                int left = amount % item.MaxStackSize;

                // Add the full stacks
                if (stacks > 0)
                {
                    for (int i = 0; i < stacks; ++i)
                    {
                        contentList.Add(new InventorySlot(item, item.MaxStackSize));
                    }
                }

                // Add the items that are left after adding the stacks
                if(left > 0)
                    contentList.Add(new InventorySlot(item, left));
            }

            // All that is left, is to update the labels
            updateItemsToDraw();
        }

        public bool containsItem(Item item, int amount = 1)
        {
            // An amount <=0 doesn't make sense, does it?
            if (amount <= 0)
                throw new ArgumentException("Amount must be > 0, but found " + amount);

            // Check every slot
            foreach (InventorySlot slot in contentList)
            {
                // If the type is the same...
                if (slot.ItemType == item)
                {
                    // ... the amount we still need will be reduced by what we already found
                    amount -= slot.StackSize;

                    // If the amount left ends up being 0 or smaller, it means we have everything
                    if (amount <= 0)
                        return true;
                }
            }
            return false;
        }

        public bool removeItem(Item item, int amount = 1)
        {
            // We can only remove these items if we have them. 
            if (!containsItem(item, amount))
                return false;

            // Check every position, remove items if needed
            for (int i = contentList.Count - 1; i >= 0; --i)
            {
                // The current slot
                InventorySlot slot = contentList[i];

                // Only do stuff if the item types are equal
                if (slot.ItemType != item)
                    continue;

                // Check if the stack size of the slot is at least equal to the amount to take away;
                // if it is, we can just reduce the stack size by the amount and break from the loop. 
                if (slot.StackSize >= amount)
                {
                    slot.StackSize -= amount;
                    break;
                }

                // Otherwise, the stack is not at least as big as the specified amount
                // in this case, we reduce the amount left by the stack size and set the stack to zero
                amount -= slot.StackSize;
                slot.StackSize = 0;
                continue; // Just for explcitness
            }

            // We removed items from the inventory. Better update the display, then
            updateItemsToDraw();
            return true; // We successfully removed all items
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
        public void updateItemsToDraw()
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
