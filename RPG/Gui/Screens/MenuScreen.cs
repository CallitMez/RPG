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
using RPG.Battles;
using RPG.Creatures;

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

            // Add the Exit button
            GuiButton buttonExit = new GuiButton(new Rectangle(0, 0, 32, 32), "testure");
            buttonExit.ClickHandler = kill;
            addElement(buttonExit);

            // Add an Inventory button
            GuiButton buttonInventory = new GuiButton(new Rectangle(300, 0, 32, 32), "testure");
            buttonInventory.ClickHandler = () => ScreenManager.Instance.selectScreen("inventory");
            addElement(buttonInventory);

            // Set the font
            font = "font";
        }

        private void kill()
        {
            throw new NotImplementedException();
        }

        public override void loadContent(AssetManager content)
        {
            base.loadContent(content);
            //this.clearElements();
            List<GuiList> battleLabels = OngoingBattles.getBattleLabels(font);

            foreach (GuiList list in battleLabels)
            {
                foreach (GuiLabel label in list.AllLabels)
                    label.Font = content.getFont(font);
                this.addElement(list);
            }
        }

        public override void update(GameTime gameTime, InputHelper inputHelper)
        {
            base.update(gameTime, inputHelper);
        }
    }
}
