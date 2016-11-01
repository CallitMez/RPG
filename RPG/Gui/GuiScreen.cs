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
            // Get the font
            SpriteFont font = RPGGame.AssetManager.getAsset<SpriteFont>(fontName);
            
            // Return a measurement for the string plus some padding.
            return font.MeasureString(labelText) + new Vector2(8, 8);
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
                        element.onClick();

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
