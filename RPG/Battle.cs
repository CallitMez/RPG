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

        bool proceed()
        {
            foreach (Hero hero in heroes)
            {
                enemies;
            }
            if ()
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
