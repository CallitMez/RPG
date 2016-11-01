using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Gui.Elements
{
    class GuiList : GuiElement
    {
        private GuiButton up;
        private GuiButton down;
        private List<GuiLabel> labelList;
        private int currentTop;
        private int displayableItems;
        private int itemHeight;
        private int itemWidth;

        public static GuiList createNewList(Point position, int displayableItems, List<GuiLabel> labels, int maxWidth = -1)
        {
            // Create a container for the width of the display
            int width = 16;

            // Get the biggest width of labels
            foreach (GuiLabel label in labels)
            {
                width = Math.Max(label.Bounds.Width + 16, width);
            }

            // Make sure the width of the labels is smaller than the maxWidth, but that the list can always contain the buttons.
            if (maxWidth > 16)
            {
                width = Math.Min(maxWidth, width);
            }

            // Get the height of the list.
            int height = labels[0].Bounds.Height * displayableItems;

            // Return a new GuiList based on position, width and height. 
            GuiList retVal = new GuiList(new Rectangle(position, new Point(width, height)), labels);
            retVal.displayableItems = displayableItems;
            retVal.itemHeight = labels[0].Bounds.Height;
            retVal.itemWidth = width - 16;
            retVal.calculateLabelPositions();
            return retVal;
        }

        private GuiList(Rectangle bounds, List<GuiLabel> labels) : base(bounds)
        {
            // Create the up-button
            up = new GuiButton(new Rectangle(new Point(bounds.Right - 16, bounds.Top), new Point(16)), "testure");
            up.ClickHandler = () => scroll(true);

            // Create the down-button
            down = new GuiButton(new Rectangle(new Point(bounds.Right - 16, bounds.Bottom - 16), new Point(16)), "testure");
            down.ClickHandler = () => scroll(false);

            // Create the list-related variables
            labelList = labels;
            currentTop = 0;
        }

        private void calculateLabelPositions()
        {
            for (int i = 0; i < labelList.Count; ++i)
            {
                labelList[i].move(new Point(Bounds.Location.X, Bounds.Location.Y - (currentTop - i) * itemHeight));
            }
        }

        private void scroll(bool up)
        {
            int move = up ? -1 : 1;

            if (currentTop + move < 0 || currentTop + move >= labelList.Count)
            {
                return;
            }

            currentTop += move;
            calculateLabelPositions();
        }

        public override void drawElement(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            for (int i = currentTop; i < currentTop + displayableItems; ++i)
            {
                labelList[i].drawElement(spriteBatch, graphics);
            }
            up.drawElement(spriteBatch, graphics);
            down.drawElement(spriteBatch, graphics);
        }

        public override void loadContent(ContentManager content)
        {
            up.loadContent(content);
            down.loadContent(content);
            foreach (GuiLabel label in labelList)
                label.loadContent(content);
        }

        public List<GuiLabel> AllLabels => labelList;
    }
}
