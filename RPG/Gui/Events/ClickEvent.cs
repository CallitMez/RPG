using Microsoft.Xna.Framework;

namespace RPG.Gui.Events
{
    class ClickEvent
    {
        Vector2 position;

        public ClickEvent(Vector2 position)
        {
            this.position = position;
        }

        public Vector2 Position => position;
    }
}
