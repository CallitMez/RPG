using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class droptemplate
    {
        //TODO add something for multiple drops of same item
        int moneydrop;
        double moneyvariance;
        int xpdrop;
        double xpvariance;
        List<itemdrop> droplist = new List<itemdrop>();
        public void addmoney(int average, double variance = 0)
        {
            moneydrop = average;
            moneyvariance = variance;
        }
        public void addXP(int average, double variance = 0)
        {
            xpdrop = average;
            xpvariance = variance;
        }
        public void additem(Item item, double chance)
        {
            droplist.Add(new RPG.itemdrop(item, chance));
        }
        List<Item> calculatedrop()
        {
            //TODO calculate amount of xp and money
            List<Item> totaldrops = new List<Item>();
            foreach(itemdrop id in droplist){
                //TODO calculate if drop
               
            }
            return totaldrops; 
            //we should change it to immediately give the loot to the player or store it inside a finnished battle (last seems better). 
            //if we have to return everything: new class needed to contain the drops. Can be avoided by making money and xp items
        }
    }

}
