using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Battle
    {
        int round = 1;
        List<Creature> heroes, enemies;
        List<Creature> everyone;
        public Battle(List<Creature> heroes, List<Creature> enemies)
        {
            this.heroes = heroes;
            this.enemies = enemies;
            
            foreach (Hero hero in heroes)
            {
                everyone.Add(hero);
                hero.enterbattle();
            }
            foreach (Hero enemy in enemies)
            {
                everyone.Add(enemy);
                enemy.enterbattle();
            }
        }

        public bool proceed()
        {

            Creature currentcreature = updatespeed();
            turn(currentcreature);

            everyone = everyone.OrderBy(c => c.aspd).ToList();
            //everyone.Reverse();
            foreach (Creature c in everyone)
            {
                Console.WriteLine(c.Name);
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
        public Creature updatespeed()
        {
            everyone = everyone.OrderBy(c => c.aspd).ToList();
            foreach(Creature c in everyone)
            {
                if (c.HP <= 0){
                    c.HP = 0;
                    everyone.Remove(c);
                }
            }
            Creature turncreature = everyone[1];
            double duration = everyone[1].aspd;
            foreach (Creature c in everyone){
                c.aspd-= duration;
            }
            turncreature.battlecounter = turncreature.aspd;
            return turncreature;
        }
    }
}
