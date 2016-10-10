using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Battle
    {
        double battletimer = 1;
        List<Creature> heroes, enemies;
        List<Creature> everyone = new List<Creature>();
        public Battle(List<Creature> heroes, List<Creature> enemies)
        {
            this.heroes = heroes;
            this.enemies = enemies;
            
            foreach (Hero hero in heroes)
            {
                everyone.Add(hero);
                hero.enterbattle();
            }
            foreach (Enemy enemy in enemies)
            {
                everyone.Add(enemy);
                enemy.enterbattle();
            }
        }

        public bool proceed()
        {
            Random rnd = new Random();
            everyone = everyone.OrderBy(c => rnd.Next()).ToList();
            /*Creature currentcreature = updatespeed();
            turn(currentcreature);*/
            updatespeed();

            everyone = everyone.OrderBy(c => c.Name).ToList();
            //everyone.Reverse();
            foreach (Creature c in everyone)
            {
                Console.WriteLine("Creature: " + c.Name + " currently has " + c.HP + " HP and " + c.battlecounter + " aspd.");
            }
            if (true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void updatespeed()
        {
            everyone = everyone.OrderBy(c => c.aspd).ToList();
            foreach (Creature c in everyone) if (c.HP <= 0) c.HP = 0;
            everyone.RemoveAll(c => c.HP == 0);
            battletimer += 1;
            foreach (Creature c in everyone)
            {
                if (battletimer % c.aspd == 0)
                {
                    turn(c);
                }
            }
        }
        public Creature updatespeedOldAndFailed()
        {
            everyone = everyone.OrderBy(c => c.aspd).ToList();
            foreach (Creature c in everyone)
            {
                if (c.HP <= 0){
                    c.HP = 0;
                }
            }
            everyone.RemoveAll(c => c.HP == 0);
            Creature turncreature = everyone[0];
            double duration = everyone[0].battlecounter;
            foreach (Creature c in everyone){
                c.battlecounter -= duration;
            }
            turncreature.battlecounter = turncreature.aspd;
            return turncreature;
        }

        void turn(Creature creature)
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
    }
}
