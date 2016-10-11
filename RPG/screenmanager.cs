using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RPG
{
    class screenmanager
    {
        static public Screen Battlescreen = new battlescreen();
        static public Screen Menuscreen = new menuscreen();
        static public Screen Inventoryscreen = new inventoryscreen();
        static public Screen Heroscreen = new heroscreen();
        static public Screen Questscreen = new questscreen();
        static public List<Screen> screenlist = new List<Screen>();
        static int selected = 0;
        public screenmanager()
        {
            screenlist.Add(Battlescreen);
            screenlist.Add(Menuscreen);
            screenlist.Add(Inventoryscreen);
            screenlist.Add(Questscreen);
            screenlist.Add(Heroscreen);

        }
        public void loadcontent()
        {
            foreach(Screen s in screenlist)
            {
                s.loadcontent();
            }
        }
        public void draw(SpriteBatch spriteBatch)
        {
            screenlist[selected].draw(spriteBatch);
        }
        public void update(GameTime gameTime)
        {
            foreach (Screen s in screenlist)
            {
                s.update(gameTime);
            }
        }
        static public void selectscreen(Screen screen)
        {
            selected = screenlist.IndexOf(screen);
        }
    }
}
