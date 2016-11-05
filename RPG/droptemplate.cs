using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Inventory;

namespace RPG
{

    // Yknow I had a good idea for the drops and other data storage (you know what I mean,
    // .txt files FTW) and I'll most likely be working on that, until then I'd prefer to
    // have a game without drops and stuff...
    class DropTemplate
    {
        //TODO add something for multiple drops of same item
        int moneyDrop;
        double moneyVariance;
        int xpDrop;
        double xpVariance;
        List<ItemDrop> dropList = new List<ItemDrop>();

        public void addMoney(int average, double variance = 0)
        {
            moneyDrop = average;
            moneyVariance = variance;
        }

        public void addXP(int average, double variance = 0)
        {
            xpDrop = average;
            xpVariance = variance;
        }

        public void addItem(Item item, double chance)
        {
            dropList.Add(new RPG.ItemDrop(item, chance));
        }

        private List<Item> calculateDrop()
        {
            //TODO calculate amount of xp and money
            List<Item> totalDrops = new List<Item>();
            foreach(ItemDrop id in dropList){
                //TODO calculate if drop
               
            }
            return totalDrops; 
            //we should change it to immediately give the loot to the player or store it inside a finnished battle (last seems better). 
            //if we have to return everything: new class needed to contain the drops. Can be avoided by making money and xp items
        }
    }

}
