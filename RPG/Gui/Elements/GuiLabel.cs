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
    /// <summary>
    /// Objects of this class are the way for a GuiScreen to draw text on the screen. 
    /// </summary>
    class GuiLabel : GuiElement
    {
        private string fontName;
        private string labelText;
        private SpriteFont font;
        private Color labelColor;

        public static GuiLabel createNewLabel(Vector2 position, string labelText, string fontName)
        {
            return createNewLabel(position, labelText, fontName, Color.Black);
        }

        public static GuiLabel createNewLabel(Vector2 position, string labelText, string fontName, Color labelColor)
        {
            GuiLabel label = new GuiLabel(new Rectangle(), labelText, fontName, labelColor);
            label.calculateBounds(position);
            return label;
        }

        private GuiLabel(Rectangle bounds, string labelText, string fontName, Color labelColor) : base(bounds)
        {
            this.labelText = labelText;
            this.fontName = fontName;
            this.labelColor = labelColor;
        }

        public override void drawElement(SpriteBatch spriteBatch, GraphicsDevice graphics)
        {
            spriteBatch.DrawString(font, labelText, Bounds.Location.ToVector2(), labelColor);
        }

        public override void loadContent(AssetManager content)
        {
            this.font = content.getFont(this.fontName);
        }

        private void calculateBounds(Vector2 position)
        {
            Vector2 size = GuiScreen.getLabelSize(labelText, fontName);
            this.Bounds = new Rectangle(position.ToPoint(), size.ToPoint());
        }

        public void setLabelText(string text)
        {
            this.labelText = text;
            this.calculateBounds(Bounds.Location.ToVector2());
        }

        public SpriteFont Font
        {
            get
            {
                return font;
            }
            set
            {
                if (value != null)
                    font = value;
            }
        }
    }
}
