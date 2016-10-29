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

        public virtual void loadContent(ContentManager content)
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
