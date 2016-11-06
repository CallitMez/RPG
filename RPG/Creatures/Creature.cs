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
        private CreatureStats stats;
        private string name;
        private CreatureType type;

        public Creature(string name, CreatureStats stats, CreatureType type = CreatureType.CREATURE)
        {
            this.name = name;
            this.type = type;
            this.stats = stats;
        }

        public void enterBattle()
        {
            stats.battleCounter = stats.attackSpeed;
        }

        /// <summary>
        /// Starts a battle with this creature against other creatures.
        /// </summary>
        /// <param name="opponents">The creatures that this creature will fight.</param>
        public void fight(List<Creature> opponents)
        {
            List<Creature> thisEnemy = new List<Creature>();
            thisEnemy.Add(this);
            OngoingBattles.ongoingBattleList.Add(new Battle(opponents, thisEnemy));//WIP droptemplate moet nog toegevoegd aan battle, iig bij enemies
        }

        public void progressBattle(double duration)
        {
            stats.battleCounter -= duration;
        }

        public void resetBattleCounter()
        {
            stats.battleCounter = stats.attackSpeed;
        }

        public void takeDamage(int amount)
        {
            stats.HP -= amount;
        }

        public string Name => name;
        public CreatureType Type => type;
        public CreatureStats Stats => stats;
        public bool IsDead => stats.HP <= 0;
    }
}
