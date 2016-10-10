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
    class Button
    {
        Rectangle size;
        Texture2D sprite;
        public Button(Rectangle size, Texture2D sprite)
        {
            this.size = size;
            this.sprite = sprite;
        }

        public void Move(Point pos)
        {
            size.Location = pos;
        }
        public bool isClicked(InputHelper inputHelper)
        {
            if (inputHelper.MouseLeftButtonPressed())
            {
                Console.WriteLine("CLick");
                if (size.Contains(inputHelper.MousePosition.X, inputHelper.MousePosition.Y))
                {
                    return true;
                }
            }
            return false;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, size, Color.White);
        }
    }
}
