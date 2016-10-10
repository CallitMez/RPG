﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class turnlog
    {
        public HashSet<Creature> heroes;
        public HashSet<Creature> enemies;
        public double battletimer;
        public Creature attacker;
        public Creature defender;
        public int damage;


        public turnlog(List<Creature>heroes,List<Creature>enemies,double battletimer, Creature attacker, Creature defender, int damage)
        {
            this.heroes = new HashSet<Creature>(heroes);
            this.enemies = new HashSet<Creature>(enemies);
            this.battletimer = battletimer;
            this.attacker = attacker;
            this.defender = defender;
            this.damage = damage;
        }

        public string Print()
        {
            string ret = "";
            ret += "Currently in battle: ";
            foreach (Creature hero in heroes) ret += hero.Name + ", ";
            foreach (Creature enemy in enemies) ret += enemy.Name + ", ";
            ret += "\nThis turn " + attacker.Name + " fought with " + defender.Name;
            ret += "\nHe did " + damage + " damage total, bringing " + defender.Name + " from " + (defender.HP + damage) + " to " + defender.HP;
            ret += "\nCurrent battle time: " + battletimer;
            return ret;
        }
    }
}