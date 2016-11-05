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
    class InventoryScreen : GuiScreen
    {
        InventoryPlayer inventory;
        private string inventoryFont;

        public InventoryScreen(string inventoryFont)
        {
            // Set the font for the inventory
            this.inventoryFont = inventoryFont;

            // Add some buttons to add / delete from player inv
            GuiButton buttonAddSword = new GuiButton(new Rectangle(0, 300, 16, 16), "testure");
            buttonAddSword.ClickHandler = () => inventory.addItem(Item.getItem("sword"));
            addElement(buttonAddSword);

            GuiButton buttonAddPotion = new GuiButton(new Rectangle(32, 300, 16, 16), "testure");
            buttonAddPotion.ClickHandler = () => inventory.addItem(Item.getItem("hpPot"));
            addElement(buttonAddPotion);
        }

        public override void loadContent(AssetManager content)
        {
            base.loadContent(content);

            inventory = new InventoryPlayer(this, inventoryFont);
        }
    }
}
