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
    class Screen
    {
        Button menuButton;
        Texture2D testure;

        public virtual void loadContent(ContentManager Content)
        {
            testure = Content.Load<Texture2D>("testure");
            menuButton = new Button(new Rectangle(new Point(0), new Point(64)), testure);
        }

        public virtual void draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.White);
            menuButton.draw(spriteBatch);
        }

        public virtual void update(GameTime gameTime, InputHelper inputHelper)
        {
            if (menuButton.isClicked(inputHelper))
                ScreenManager.selectScreen(ScreenManager.menuScreen);
        }
    }
}
