using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Creatures
{
    public class CreatureStats
    {
        private int attack;
        private int maxHP;
        private int taunt;

        public int HP;
        public double attackSpeed;
        public double battleCounter;

        public CreatureStats(int maxHP, int attack, double attSpd, int taunt = 1)
        {
            this.maxHP = maxHP;
            this.attack = attack;
            this.attackSpeed = attSpd;
            this.taunt = taunt;
            HP = maxHP;
            battleCounter = 1;
        }

        public int Attack => attack;
        public int MaxHP => maxHP;
        public int Hate => taunt;
    }
}
