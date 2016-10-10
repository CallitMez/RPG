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
        public Battle(List<Creature> heroes, List<Creature> enemies)
        {
            this.heroes = heroes;
            this.enemies = enemies;
        }

        public bool proceed()
        {
            List<Creature> everyone = enemies;
            foreach (Hero hero in heroes)
            {
                everyone.Add(hero);
            }
            everyone = everyone.OrderBy(c => c.aspd).ToList();
            everyone.Reverse();
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
    }
}
