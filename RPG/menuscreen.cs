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
    class MenuScreen : Screen
    {
        Hero hero;
        Enemy baddude;
        List<Creature> heroList;
        List<Creature> baddudes;
        Battle newBattle;
        SpriteFont font;
        public MenuScreen()
        {
            heroList = new List<Creature>();
            baddudes = new List<Creature>();
            hero = new Hero("tester", 100, 5, 0.5);
            baddude = new Enemy("tester", 100, 5, 0.1);
            baddudes.Add(baddude);
            heroList.Add(hero);
            newBattle = new Battle(heroList,baddudes);
            OngoingBattles.ongoingBattleList.Add(newBattle);
        }

        public override void loadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("font");
        }

        public override void draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.Blue);
            OngoingBattles.draw(spriteBatch, font);
        }
        public override void update(GameTime gameTime, InputHelper inputHelper) {
        }
    }
}
