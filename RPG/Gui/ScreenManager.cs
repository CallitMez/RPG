using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Gui.Screens;

namespace RPG.Gui
{
    class ScreenManager
    {
        public static GuiScreen battleScreen = new BattleScreen();
        public static GuiScreen menuScreen = new MenuScreen();
        public static GuiScreen inventoryScreen = new InventoryScreen();
        public static GuiScreen heroScreen = new HeroScreen();
        public static GuiScreen questScreen = new QuestScreen();
        public static List<GuiScreen> screenList = new List<GuiScreen>();
        private static int selected = 1;

        public ScreenManager()
        {
            screenList.Add(battleScreen);
            screenList.Add(menuScreen);
            screenList.Add(inventoryScreen);
            screenList.Add(questScreen);
            screenList.Add(heroScreen);
        }

        public void loadContent(AssetManager Content)
        {
            foreach(GuiScreen s in screenList)
            {
                s.loadContent(Content);
            }
        }

        public void draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            screenList[selected].draw(spriteBatch, graphicsDevice);
        }

        public void update(GameTime gameTime, InputHelper inputHelper)
        {
            foreach (GuiScreen s in screenList)
            {
                s.update(gameTime, inputHelper);
            }
        }

        public static void selectScreen(GuiScreen screen)
        {
            selected = screenList.IndexOf(screen);
        }
    }
}
