using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Gui.Elements;

namespace RPG
{
    class Battle
    {
        public HashSet<TurnLog> battleLog = new HashSet<TurnLog>();
        double battleTimer = 0;
        bool finished;
        double countdown;
        List<Creature> heroes, enemies;
        public List<Creature> everyone;
        TurnLog currentTurn;
        double elapsedTime = 0;
        double speedModifier;
        GuiLabel labelHeroStats, labelEnemyStats, labelElapsedTime, labelCountdown;

        public Battle(List<Creature> heroes, List<Creature> enemies, double speedModifier = 1)//TODO vang droptemplate af (standaard 0)
        {
            this.heroes = heroes;
            this.enemies = enemies;
            this.speedModifier = speedModifier;
            everyone = createEveryone();
            
            //TODO zorg dat hier een timer gezet wordt die bijhoudt hoe lang het gevecht al aan de gang is, 
            //zorg dat wanneer het gevecht beeindigd is(qua rekenwerk) 
            //met behulp van speedmodifier berekend wordt of hij afgelopen is. (speedmodifier*battletimer (minuten))
        }

        private bool proceed()
        {

            currentTurn = new TurnLog(heroes, enemies, 0, null, null, 0);
            Random rnd = RPGGame.RNGsus;
            everyone = everyone.OrderBy(c => rnd.Next()).ToList();
            Creature currentCreature = updateSpeed();
            currentTurn.attacker = currentCreature;
            currentTurn.battleTimer = battleTimer;
            
            turn(currentCreature);
            battleLog.Add(currentTurn);
         
            //-------------------------------------------------------------------------------------------------------------------------------

            everyone = everyone.OrderBy(c => c.Name).ToList();
            finished = (heroes.Count <= 0 || enemies.Count <= 0);
            return (!finished);
        }

        public void writeLog()
        {
            foreach (TurnLog turn in battleLog)
                System.Console.WriteLine(turn.print());
        }

        public bool update(GameTime gameTime)
        {
            updateLabels();
            everyone = everyone.OrderBy(c => c.battleCounter).ToList();
            //removedead();
            Creature turnCreature = everyone[0];
            elapsedTime += gameTime.ElapsedGameTime.TotalMinutes;
            if (turnCreature.battleCounter*speedModifier<elapsedTime)
            {
                elapsedTime = 0;
                return proceed();
            }
            countdown = 60*(turnCreature.battleCounter - elapsedTime);
            return !finished;
        }

        private List<Creature> createEveryone()
        {
            List<Creature> combinedList = new List<Creature>();
            foreach (Creature hero in heroes)
            {
                combinedList.Add(hero);
                hero.enterBattle();
            }
            foreach (Creature enemy in enemies)
            {
                combinedList.Add(enemy);
                enemy.enterBattle();
            }
            return combinedList;
        }

        public double entireBattle()
        {
            while (proceed()) {}
            return battleTimer;
        }

        public void updateSpeedLuuk()
        {
            everyone = everyone.OrderBy(c => c.attackSpeed).ToList();
            //removedead();
            battleTimer += 1;
            foreach (Creature c in everyone)
            {
                if (battleTimer % c.attackSpeed == 0)
                {
                    turn(c);
                }
            }
        }

        void removeDead()
        {
            // Make sure all dead creatures are set to 0 hp.
            foreach (Creature c in everyone)
                if (c.HP <= 0)
                    c.HP = 0;

            // Remove all dead creatures
            Predicate<Creature> isDead = 
                c => c.HP == 0;

            everyone.RemoveAll(isDead);
            heroes.RemoveAll(isDead);
            enemies.RemoveAll(isDead);
        }

        public Creature updateSpeed()
        {
            everyone = everyone.OrderBy(c => c.battleCounter).ToList();
            //removedead();
            Creature turnCreature = everyone[0];
            double duration = everyone[0].battleCounter;
            foreach (Creature c in everyone){
                c.battleCounter -= duration;
            }
            battleTimer += duration;
            turnCreature.battleCounter = turnCreature.attackSpeed;
            return turnCreature;
        }

        /*void turn(Creature creature)
        {
            everyone = everyone.OrderBy(c => c.Hate).ToList();
            if (creature.Type == "hero") foreach (Creature c in everyone)
                {
                    if (c.Type == "enemy")
                    {
                        c.damage(creature.Atk);
                        Console.WriteLine("Creature " + creature.Name + " attacks! " + c.Name + " lost " + creature.Atk + " HP!");
                        break;
                    }
                }
            else foreach (Creature d in everyone)
                {
                    if (d.Type == "hero")
                    {
                        d.damage(creature.Atk);
                        Console.WriteLine("Creature " + creature.Name + " attacks! " + d.Name + " lost " + creature.Atk + " HP!");
                        break;
                    }
                }
        }
        */
        void turn(Creature creature)
        {
            int damage;
            Creature defender;
            Func<Creature, int> attackPriority = ((c) => c.Hate);
            if (heroes.Contains(creature)){
                enemies = enemies.OrderBy(attackPriority).ToList();
                defender = enemies[0];
                damage = creature.Atk;
                defender.takeDamage(damage);
                //Console.WriteLine("Creature " + creature.Name + " attacks! " + defender.Name + " lost " + creature.Atk + " HP!");
                    
            }
            else{
                heroes = heroes.OrderBy(attackPriority).ToList();
                defender = heroes[0];
                damage = creature.Atk;
                defender.takeDamage(damage);
                //Console.WriteLine("Creature " + creature.Name + " attacks! " + defender.Name + " lost " + creature.Atk + " HP!");
            }
            currentTurn.defender = defender;
            currentTurn.damage = damage;
            removeDead();
        }

        public void onFinish()
        {
            labelHeroStats.setLabelText("");
            labelEnemyStats.setLabelText("");
            labelElapsedTime.setLabelText("");
            labelCountdown.setLabelText("");
        }

        public void updateLabels()
        {
            labelHeroStats.setLabelText("Hero " + heroes[0].Name + " has " + heroes[0].HP + " HP.");
            labelEnemyStats.setLabelText("Enemy " + enemies[0].Name + " has " + enemies[0].HP + " HP.");
            labelElapsedTime.setLabelText("Elapsed time: " + Math.Round(elapsedTime, 2));
            labelCountdown.setLabelText("Countdown: " + Math.Round(countdown, 2));
        }

        public GuiList getLabels(int xPos, string fontName)
        {
            // Create a list of labels
            List<GuiLabel> allLabels = new List<GuiLabel>();

            // Initialize the labels and add them to the list

            // TODO it would be better to make these labels fields and update them, rather than creating new ones every update.
            // This would also eliminate the need to re-add them to another list every update, as the reference stays equal. -Ebilkill

            labelHeroStats = GuiLabel.createNewLabel(new Vector2(xPos, 0), "Hero " + heroes[0].Name + " has " + heroes[0].HP + " HP.", fontName);
            labelEnemyStats = GuiLabel.createNewLabel(new Vector2(xPos, 200), "Enemy " + enemies[0].Name + " has " + enemies[0].HP + " HP.", fontName);
            labelElapsedTime = GuiLabel.createNewLabel(new Vector2(xPos, 300), "Elapsed time " + Math.Round(elapsedTime, 2), fontName);
            labelCountdown = GuiLabel.createNewLabel(new Vector2(xPos, 400), "Countdown " + Math.Round(countdown, 2), fontName);

            allLabels.Add(labelHeroStats);
            allLabels.Add(labelEnemyStats);
            allLabels.Add(labelElapsedTime);
            allLabels.Add(labelCountdown);

            // Return the generated list
            return GuiList.createNewList(new Point(xPos, 0), 3, allLabels);
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font, int x)
        {
            spriteBatch.DrawString(font, "Hero " + heroes[0].Name + " has " + heroes[0].HP + " HP.", new Vector2(x, 0), Color.Black);
            spriteBatch.DrawString(font, "Enemy " + enemies[0].Name + " has " + enemies[0].HP + " HP.", new Vector2(x, 200), Color.Black);
            spriteBatch.DrawString(font, "Elapsed time " + Math.Round(elapsedTime,2), new Vector2(x, 300), Color.Black);
            spriteBatch.DrawString(font, "Countdown " + Math.Round(countdown,2), new Vector2(x, 400), Color.Black);
        }
    }
}
