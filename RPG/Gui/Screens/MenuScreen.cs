using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Gui.Elements;
using RPG;


namespace RPG.Gui.Screens
{
    class MenuScreen : GuiScreen
    {
        Hero hero;
        Enemy baddude;
        List<Creature> heroList;
        List<Creature> baddudes;
        Battle newBattle;

        string font;

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
            GuiButton buttonExit = new GuiButton(new Rectangle(0, 0, 32, 32), "testure");
            buttonExit.ClickHandler = kill;
            addElement(buttonExit);
            font = "font";
        }

        private void kill()
        {
            throw new NotImplementedException();
        }

        public override void loadContent(AssetManager content)
        {
            base.loadContent(content);
            this.clearElements();
            List<GuiLabel> battleLabels = OngoingBattles.getBattleLabels(font);

            foreach (GuiLabel label in battleLabels)
            {
                label.Font = content.getFont(font);
                this.addElement(label);
            }
        }

        public override void update(GameTime gameTime, InputHelper inputHelper)
        {
            base.update(gameTime, inputHelper);
            this.clearElements();
            List<GuiLabel> battleLabels = OngoingBattles.getBattleLabels(font);
        }
    }
}
