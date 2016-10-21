using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


/// <summary>
/// -----------------------------------------------
/// -------------------Button.cs-------------------
/// ---------------Made by: CallitMez--------------
/// ----------------Made for RPGGame---------------
/// -------------------12-10-2016------------------
/// ------------github.com/CallitMez/RPG-----------
/// -----------------------------------------------
/// </summary>

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
