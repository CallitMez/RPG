using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Battles;

namespace RPG.Creatures
{
    class Creature
    {
        //TODO create class stats to be able to easily modify stats (temporary or permanent). 
        //idea: "public Stats creaturestats;" instead of maxHP,aspd,defense,aggro,etc.
        //items also have stats, method to easily add them, also method to change temporary 
        string name, type;
        int attack, MaxHP, taunt = 1;
        public int HP;
        public double attackSpeed;
        public double battleCounter = 1;
        public Creature(string name, int HP, int attack, double attackSpeed = 5, string type = "creature")
        {
            this.name = name;
            this.type = type;
            this.MaxHP = HP;
            this.attackSpeed = attackSpeed;
            this.HP = HP;
            this.attack = attack;
        }

        public string Name => name;
        public int Atk => attack;
        public string Type => type;
        public int Hate => taunt;

        public void takeDamage(int amount)
        {
            HP -= amount;
        }

        public void enterBattle()
        {
            battleCounter = attackSpeed;
        }

        public void fight(List<Creature> opponents)
        {
            List<Creature> thisEnemy = new List<Creature>();
            thisEnemy.Add(this);
            OngoingBattles.ongoingBattleList.Add(new Battle(opponents, thisEnemy));//WIP droptemplate moet nog toegevoegd aan battle, iig bij enemies
        }
    }
    class Enemy : Creature
    {
        DropTemplate drops = new DropTemplate();

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
