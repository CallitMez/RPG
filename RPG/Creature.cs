using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Creature
    {
        //TODO create class stats to be able to easily modify stats (temporary or permanent). 
        //idea: "public Stats creaturestats;" instead of maxHP,aspd,defense,aggro,etc.
        //items also have stats, method to easily add them, also method to change temporary 
        string name, type;
        int attack, MaxHP, taunt = 1;
        public int HP;
        public double aspd;
        public double battlecounter = 1;
        public Creature(string name, int HP, int attack, double aspd = 5, string type = "creature")
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
        public void fight(List<Creature> opponents)
        {
            List<Creature> thisenemy = new List<Creature>();
            thisenemy.Add(this);
            ongoingbattles.ongoingbattlelist.Add(new Battle(opponents, thisenemy));//WIP droptemplate moet nog toegevoegd aan battle, iig bij enemies
        }
    }
    class Enemy : Creature
    {
        droptemplate drops = new droptemplate();

        public Enemy(string name, int HP, int attack, double aspd) : base(name, HP, attack, aspd, "enemy")
        {
            
        }
        //TODO Long term: sort the enemies in worlds.
    }
    class Hero : Creature
    {
        public Hero(string name, int HP, int attack, double aspd = 0.3) : base(name, HP, attack,aspd, "hero")
        {
            
        }//TODO add level system
    }
}
