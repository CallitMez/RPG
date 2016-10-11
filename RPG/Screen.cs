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
        Button menubutton;
        Texture2D testure;
        public virtual void loadcontent(ContentManager Content)
        {
            testure = Content.Load<Texture2D>("testure");
            menubutton = new Button(new Rectangle(new Point(0), new Point(64)), testure);
        }
        public virtual void draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.White);
            menubutton.Draw(spriteBatch);
        }
        public virtual void update(GameTime gameTime, InputHelper inputHelper)
        {
            if (menubutton.isClicked(inputHelper)) screenmanager.selectscreen(screenmanager.Menuscreen);
        }
    }
}
