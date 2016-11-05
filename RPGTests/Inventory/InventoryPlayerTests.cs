using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Inventory.Tests
{
    [TestClass()]
    public class InventoryPlayerTests
    {
        private const int ITEM_ADD_TEST = 1;
        private const int ITEM_REMOVE_TEST = 2;
        private const int ITEM_CONTAINS_TEST = 4;

        public InventoryPlayer InitInventory(int flag)
        {
            FileManager f = new FileManager();
            Item.loadItems(f);
            RPG.Gui.Screens.InventoryScreen screen = new Gui.Screens.InventoryScreen("font");
            InventoryPlayer inv = new InventoryPlayer(screen, "font");

            if (flag == ITEM_ADD_TEST)
            {
                return inv;
            }

            if (flag == ITEM_CONTAINS_TEST || flag == ITEM_REMOVE_TEST)
            {
                inv.addItem(Item.getItem("sword"));
                inv.addItem(Item.getItem("hpPot"));
            }

            return inv;
        }

        [TestMethod()]
        public void removeItemTest()
        {
            InventoryPlayer inv = InitInventory(ITEM_REMOVE_TEST);

            Assert.IsFalse(inv.removeItem(Item.getItem("sword"), 10), "Removed 10 Swords, didn't have 10.");
            Assert.IsFalse(inv.removeItem(Item.getItem("hpPot"), 5), "Removed 5 hpPot, didn't have 5.");

            Assert.IsTrue(inv.removeItem(Item.getItem("sword")), "Didn't remove 1 sword, had 1.");
            Assert.IsFalse(inv.containsItem(Item.getItem("sword")), "Contains a sword, but should have been removed.");
            Assert.IsTrue(inv.containsItem(Item.getItem("hpPot")), "No longer has a hpPot, but shouldn't have been removed.");

            Assert.IsTrue(inv.removeItem(Item.getItem("hpPot")));
            Assert.IsFalse(inv.containsItem(Item.getItem("sword")));
            Assert.IsFalse(inv.containsItem(Item.getItem("hpPot")));
        }

        [TestMethod()]
        public void addItemTest()
        {
            InventoryPlayer inv = InitInventory(ITEM_ADD_TEST);
            inv.addItem(Item.getItem("sword"), 3);
            inv.addItem(Item.getItem("hpPot"));
            inv.addItem(Item.getItem("hpPot"), 50);

            Assert.IsTrue(inv.containsItem(Item.getItem("sword"), 2));
            Assert.IsTrue(inv.containsItem(Item.getItem("sword"), 3));
            Assert.IsFalse(inv.containsItem(Item.getItem("sword"), 4));
            Assert.IsTrue(inv.containsItem(Item.getItem("hpPot")));
            Assert.IsTrue(inv.containsItem(Item.getItem("hpPot"), 5));
            Assert.IsTrue(inv.containsItem(Item.getItem("hpPot"), 40));
            Assert.IsFalse(inv.containsItem(Item.getItem("hpPot"), 100));
        }

        [TestMethod()]
        public void containsItemTest()
        {
            InventoryPlayer inv = InitInventory(ITEM_CONTAINS_TEST);
            Assert.IsTrue(inv.containsItem(Item.getItem("sword")));
            Assert.IsFalse(inv.containsItem(Item.getItem("sword"), 2));
            Assert.IsTrue(inv.containsItem(Item.getItem("hpPot")));
            Assert.IsFalse(inv.containsItem(Item.getItem("hpPot"), 5));
            try
            {
                Assert.IsFalse(inv.containsItem(Item.getItem("hpPot"), -1));
                Assert.Fail();
            }
            catch (ArgumentException)
            {
            }
        }
    }
}