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
    class ongoingbattles
    {
        static public List<Battle> ongoingbattlelist = new List<Battle>();
        static public List<Battle> finnishedbattlelist = new List<Battle>();

        static public bool checkifoccupied(Creature creature)
        {
            bool sofar = false;
            foreach (Battle b in ongoingbattlelist)
            {
                if (b.everyone.Contains(creature))
                    sofar = true;
            }
            return sofar;
        }
        static public void update(GameTime gametime)
        {
            foreach (Battle b in ongoingbattlelist)
                if (!b.update(gametime))
                {
                    finnishedbattlelist.Add(b);
                }
            foreach(Battle b in finnishedbattlelist)
            {
                if (ongoingbattlelist.Contains(b))
                {
                    ongoingbattlelist.Remove(b);
                }
            }
        }
        static public void draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            for (int i = 0;i<ongoingbattlelist.Count;i++)
            {
                ongoingbattlelist[i].Draw(spriteBatch,font,200*i);
            }
            //TODO make a function that draws the ongoing battles, clickable so you can see their status
            //TODO make a class and function that stores old battles
        }

    }
}
