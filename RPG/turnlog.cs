using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class TurnLog
    {
        public HashSet<Creature> heroes;
        public HashSet<Creature> enemies;
        public double battleTimer;
        public Creature attacker;
        public Creature defender;
        public int damage;


        public TurnLog(List<Creature>heroes,List<Creature>enemies,double battletimer, Creature attacker, Creature defender, int damage)
        {
            this.heroes = new HashSet<Creature>(heroes);
            this.enemies = new HashSet<Creature>(enemies);
            this.battleTimer = battletimer;
            this.attacker = attacker;
            this.defender = defender;
            this.damage = damage;
        }

        public string print()
        {
            string ret = "";
            ret += "Currently in battle: ";
            foreach (Creature hero in heroes) ret += hero.Name + ", ";
            foreach (Creature enemy in enemies) ret += enemy.Name + ", ";
            ret += "\nThis turn " + attacker.Name + " fought with " + defender.Name;
            ret += "\nHe did " + damage + " damage total, bringing " + defender.Name + " from " + (defender.HP + damage) + " to " + defender.HP;
            ret += "\nCurrent battle time: " + battleTimer;
            return ret;
        }
    }
}
