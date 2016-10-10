using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Creature
    {
        string name;
        int attack, HP, MaxHP;
        public Creature(string name, int HP, int attack)
        {
            this.name = name;
            this.MaxHP = HP;
            this.HP = HP;
            this.attack = attack;
        }

        public string Name
        {
            get { return name; }
        }
    }
    class Enemy : Creature
    {
        public Enemy(string name, int HP, int attack) : base(name, HP, attack)
        {

        }
    }
    class Hero : Creature
    {
        int attack, HP;
        public Hero(string name, int HP, int attack) : base(name, HP, attack)
        {

        }
    }
}
