using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class ScreenManager
    {
        public static Screen battleScreen = new BattleScreen();
        public static Screen menuScreen = new MenuScreen();
        public static Screen inventoryScreen = new InventoryScreen();
        public static Screen heroScreen = new HeroScreen();
        public static Screen questScreen = new QuestScreen();
        public static List<Screen> screenList = new List<Screen>();
        static int selected = 1;

        public ScreenManager()
        {
            screenList.Add(battleScreen);
            screenList.Add(menuScreen);
            screenList.Add(inventoryScreen);
            screenList.Add(questScreen);
            screenList.Add(heroScreen);
        }

        public void loadContent(ContentManager Content)
        {
            foreach(Screen s in screenList)
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
            foreach (Screen s in screenList)
            {
                s.update(gameTime, inputHelper);
            }
        }

        public static void selectScreen(Screen screen)
        {
            selected = screenList.IndexOf(screen);
        }
    }
}
