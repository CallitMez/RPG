using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Gui
{
    abstract class GuiElement
    {
        private Rectangle bounds;

        protected GuiElement(Rectangle bounds)
        {
            this.bounds = bounds;
        }

        public abstract void loadContent(ContentManager content);
        public abstract void drawElement(SpriteBatch spriteBatch, GraphicsDevice graphics);

        public virtual void onClick()
        {
        }

        public virtual void handleKeyboardInput(InputHelper helper)
        {
        }

        public void move(Point pos)
        {
            bounds.Location = pos;
        }

        public Rectangle Bounds => bounds;
    }
}
