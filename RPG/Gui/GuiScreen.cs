using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace RPG.Gui
{
    abstract class GuiScreen
    {
        private List<GuiElement> elements;
        private int activeElement;

        public static Vector2 getLabelSize(string labelText, string fontName)
        {
            // Get the glyph sizes
            SpriteFont font = RPGGame.AssetManager.getFont(fontName);
            Dictionary<char, SpriteFont.Glyph> charSizes = font.GetGlyphs();

            // Create a new size vector
            Vector2 size = Vector2.Zero;

            // Get the biggest height and the total width
            foreach (char c in labelText)
            {
                size.X += charSizes[c].WidthIncludingBearings;
                size.Y = Math.Max(size.Y, charSizes[c].BoundsInTexture.Size.Y);
            }

            // Return the size
            return size;
        }

        protected GuiScreen()
        {
            elements = new List<GuiElement>();
            activeElement = -1;
        }

        public void addElement(GuiElement element)
        {
            elements.Add(element);
        }

        public void removeElement(GuiElement element)
        {
            elements.Remove(element);
        }

        public void clearElements()
        {
            elements.Clear();
        }

        public virtual void loadContent(AssetManager content)
        {
            foreach(GuiElement element in elements)
            {
                element.loadContent(content);
            }
        }

        public virtual void draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.White);
            foreach (GuiElement element in elements)
            {
                element.drawElement(spriteBatch, graphicsDevice);
            }
        }

        public virtual void update(GameTime gameTime, InputHelper inputHelper)
        {
            if (inputHelper.MouseLeftButtonPressed())
            {
                // Set no element active if none has been pressed
                activeElement = -1;

                // Check if an element has been clicked.
                for (int i = 0; i < elements.Count; ++i)
                {
                    GuiElement element = elements[i];
                    if (element.Bounds.Contains(inputHelper.MousePosition)) {
                        // Handle the click
                        element.onClick(new Events.ClickEvent(inputHelper.MousePosition));

                        // Make this element active
                        activeElement = i;
                    }
                }
            }

            if(activeElement >= 0 && activeElement < elements.Count)
                elements[activeElement].handleKeyboardInput(inputHelper);
        }
    }
}
