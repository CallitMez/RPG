using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Gui.Elements;

namespace RPG
{
    class OngoingBattles
    {
        public static List<Battle> ongoingBattleList = new List<Battle>();
        public static List<Battle> finishedBattleList = new List<Battle>();

        public static bool checkIfOccupied(Creature creature)
        {
            bool sofar = false;
            foreach (Battle b in ongoingBattleList)
            {
                if (b.everyone.Contains(creature))
                    sofar = true;
            }
            return sofar;
        }

        public static void update(GameTime gametime)
        {
            foreach (Battle b in ongoingBattleList)
                if (!b.update(gametime))
                {
                    finishedBattleList.Add(b);
                }
            foreach(Battle b in finishedBattleList)
            {
                if (ongoingBattleList.Contains(b))
                {
                    ongoingBattleList.Remove(b);
                    b.onFinish();
                }
            }
        }

        public static List<GuiList> getBattleLabels(string fontName)
        {
            // Create a list of labels
            List<GuiList> battlesInformation = new List<GuiList>();

            for (int i = 0; i < ongoingBattleList.Count; ++i)
            {
                GuiList battleLabels = ongoingBattleList[i].getLabels(300 * i, fontName);
                battlesInformation.Add(battleLabels);
            }

            // Return the created list
            return battlesInformation;
        }

        public static void draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            for (int i = 0;i<ongoingBattleList.Count;i++)
            {
                ongoingBattleList[i].Draw(spriteBatch,font,300*i);
            }
            //TODO make a function that draws the ongoing battles, clickable so you can see their status
            //TODO make a class and function that stores old battles
        }

    }
}
