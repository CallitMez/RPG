using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Inventory;
using RPG.Gui.Elements;

namespace RPG.Gui.Screens
{
    public class InventoryScreen : GuiScreen
    {
        InventoryPlayer inventory;
        private string inventoryFont;

        public InventoryScreen(string inventoryFont)
        {
            // Set the font for the inventory
            this.inventoryFont = inventoryFont;

            // Add some buttons to add / delete from player inv
            GuiButton buttonAddSword = GuiButton.createButtonWithLabel(new Point(0, 300), "Add Sword", "testure", "font");
            buttonAddSword.ClickHandler = () => inventory.addItem(Item.getItem("sword"));
            addElement(buttonAddSword);

            GuiButton buttonAddPotion = GuiButton.createButtonWithLabel(new Point(buttonAddSword.Bounds.Right + 16, buttonAddSword.Bounds.Top), "Add Potion", "testure", "font");
            buttonAddPotion.ClickHandler = () => inventory.addItem(Item.getItem("hpPot"));
            addElement(buttonAddPotion);

            GuiButton buttonRemoveSword = GuiButton.createButtonWithLabel(new Point(buttonAddSword.Bounds.Left, buttonAddSword.Bounds.Bottom + 16), "Remove Sword", "testure", "font");
            buttonRemoveSword.ClickHandler = () => inventory.removeItem(Item.getItem("sword"));
            addElement(buttonRemoveSword);

            GuiButton buttonRemovePotion = GuiButton.createButtonWithLabel(new Point(buttonAddPotion.Bounds.Left, buttonAddPotion.Bounds.Bottom + 16), "Remove Potion", "testure", "font");
            buttonRemovePotion.ClickHandler = () => inventory.removeItem(Item.getItem("hpPot"));
            addElement(buttonRemovePotion);
        }

        public override void loadContent(AssetManager content)
        {
            base.loadContent(content);

            inventory = new InventoryPlayer(this, inventoryFont);
        }
    }
}
