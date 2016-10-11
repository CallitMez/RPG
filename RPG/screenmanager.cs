using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace RPG
{
    class screenmanager
    {
        List<Screen> screenlist = new List<Screen>();
        battlescreen Battlescreen = new battlescreen();
        int selected = 0;
        public screenmanager()
        {
            battlescreen Battlescreen = new battlescreen();
            screenlist.Add(Battlescreen);
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
    }
}
