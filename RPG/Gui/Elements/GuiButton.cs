using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

namespace RPG.Gui.Elements
{
    class GuiButton : GuiElement
    {
        public delegate void OnClickHandler();

        private Texture2D sprite;
        private OnClickHandler clickHandler;
        private string spriteName;

        public GuiButton(Rectangle bounds, string spriteName) : base(bounds)
        {
            this.spriteName = spriteName;
        }

        public override void loadContent(AssetManager content)
        {
            this.sprite = content.getAsset<Texture2D>(spriteName);
        }

        public override void drawElement(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            spriteBatch.Draw(sprite, Bounds, Color.White);
        }

        public override void onClick()
        {
            clickHandler();
        }

        public OnClickHandler ClickHandler
        {
            set
            {
                this.clickHandler = value;
            }
        }
    }
}
