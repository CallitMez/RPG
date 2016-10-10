using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Creature
    {
        string name, type;
        int attack, MaxHP, taunt = 1;
        public int HP;
        public double aspd;
        public double battlecounter = 1;
        public Creature(string name, int HP, int attack, int aspd = 5, string type = "creature")
        {
            this.name = name;
            this.type = type;
            this.MaxHP = HP;
            this.aspd = aspd;
            this.HP = HP;
            this.attack = attack;
        }

        public string Name { get { return name; } }
        public int Atk { get { return attack; } }
        public string Type { get { return type; } }
        public int Hate { get { return taunt; } }

        public void damage(int amount)
        {
            HP -= amount;
        }
        public void enterbattle()
        {
            battlecounter = aspd;
        }
    }
    class Enemy : Creature
    {
        public Enemy(string name, int HP, int attack, int aspd) : base(name, HP, attack, aspd, "enemy")
        {
            
        }
    }
    class Hero : Creature
    {
        public Hero(string name, int HP, int attack) : base(name, HP, attack, 1, "hero")
        {
            
        }
    }
}
