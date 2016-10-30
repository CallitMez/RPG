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

        /// <summary>
        /// Called when the content of this GuiElement should be loaded.
        /// </summary>
        /// <param name="content">The ContentManager to load the content with.</param>
        public abstract void loadContent(ContentManager content);

        /// <summary>
        /// Called by the parent GuiScreen when this GuiElement should be drawn to the screen.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch to draw the element with.</param>
        /// <param name="graphics">The GraphicsDevice used by the game window.</param>
        public abstract void drawElement(SpriteBatch spriteBatch, GraphicsDevice graphics);

        public virtual void onClick()
        {
        }

        public virtual void handleKeyboardInput(InputHelper helper)
        {
        }

        /// <summary>
        /// Repositions this GuiElement to another place.
        /// </summary>
        /// <param name="pos">The position to move to.</param>
        public void move(Point pos)
        {
            bounds.Location = pos;
        }

        public Rectangle Bounds
        {
            get
            {
                return bounds;
            }
            protected set
            {
                bounds = value;
            }
        }
    }
}
