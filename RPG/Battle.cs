using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class Battle
    {
        public HashSet<turnlog> battlelog = new HashSet<turnlog>();
        double battletimer = 0;
        List<Creature> heroes, enemies;
        List<Creature> everyone;
        turnlog currentturn;
        public Battle(List<Creature> heroes, List<Creature> enemies)
        {
            this.heroes = heroes;
            this.enemies = enemies;
            everyone = createeveryone();
            
        }

        public bool proceed()
        {
            currentturn = new turnlog(heroes, enemies, 0, null, null, 0);
            Random rnd = new Random();
            everyone = everyone.OrderBy(c => rnd.Next()).ToList();
            Creature currentcreature = updatespeed();
            currentturn.attacker = currentcreature;
            currentturn.battletimer = battletimer;
            if (enemies.Count > 0)
            {
                turn(currentcreature);
                battlelog.Add(currentturn);
            }
            //updatespeed();

            everyone = everyone.OrderBy(c => c.Name).ToList();
            //everyone.Reverse();
            foreach (Creature c in everyone)
            {
                //Console.WriteLine("Creature: " + c.Name + " currently has " + c.HP + " HP and " + c.battlecounter + " aspd.");
            }

            return (heroes.Count > 0 && enemies.Count > 0);
           
        }
        private List<Creature> createeveryone()
        {
            List<Creature> combinedlist = new List<Creature>();
            foreach (Creature hero in heroes)
            {
                combinedlist.Add(hero);
                hero.enterbattle();
            }
            foreach (Creature enemy in enemies)
            {
                combinedlist.Add(enemy);
                enemy.enterbattle();
            }
            return combinedlist;
        }
        public void updatespeedluuk()
        {
            everyone = everyone.OrderBy(c => c.aspd).ToList();
            removedead();
            battletimer += 1;
            foreach (Creature c in everyone)
            {
                if (battletimer % c.aspd == 0)
                {
                    turn(c);
                }
            }
        }
        void removedead()
        {
            foreach (Creature c in everyone) if (c.HP <= 0) c.HP = 0;
            everyone.RemoveAll(c => c.HP == 0);
            heroes.RemoveAll(c => c.HP == 0);
            enemies.RemoveAll(c => c.HP == 0);

        }
        public Creature updatespeed()
        {
            everyone = everyone.OrderBy(c => c.battlecounter).ToList();
            removedead();
            Creature turncreature = everyone[0];
            double duration = everyone[0].battlecounter;
            foreach (Creature c in everyone){
                c.battlecounter -= duration;
            }
            battletimer += duration;
            turncreature.battlecounter = turncreature.aspd;
            return turncreature;
        }

        /*void turn(Creature creature)
        {
            everyone = everyone.OrderBy(c => c.Hate).ToList();
            if (creature.Type == "hero") foreach (Creature c in everyone)
                {
                    if (c.Type == "enemy")
                    {
                        c.damage(creature.Atk);
                        Console.WriteLine("Creature " + creature.Name + " attacks! " + c.Name + " lost " + creature.Atk + " HP!");
                        break;
                    }
                }
            else foreach (Creature d in everyone)
                {
                    if (d.Type == "hero")
                    {
                        d.damage(creature.Atk);
                        Console.WriteLine("Creature " + creature.Name + " attacks! " + d.Name + " lost " + creature.Atk + " HP!");
                        break;
                    }
                }
        }
        */
        void turn(Creature creature)
        {
            int damage;
            Creature defender;
            if (heroes.Contains(creature)){
                enemies = enemies.OrderBy(c => c.Hate).ToList();
                defender = enemies[0];
                damage = creature.Atk;
                defender.damage(damage);
                //Console.WriteLine("Creature " + creature.Name + " attacks! " + defender.Name + " lost " + creature.Atk + " HP!");
                    
            }
            else{
                heroes = heroes.OrderBy(c => c.Hate).ToList();
                defender = heroes[0];
                damage = creature.Atk;
                defender.damage(damage);
                //Console.WriteLine("Creature " + creature.Name + " attacks! " + defender.Name + " lost " + creature.Atk + " HP!");
                    
            }
            currentturn.defender = defender;
            currentturn.damage = damage;
        }
    }
}
