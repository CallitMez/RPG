using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPG.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Creatures.Tests
{
    [TestClass()]
    public class CreatureTests
    {
        [TestMethod()]
        public void takeDamageTest()
        {
            // Create a Hero and an Enemy
            CreatureStats heroStats = new CreatureStats(100, 10, 10, 0);
            Hero hero = new Hero("HENK :D", heroStats);

            CreatureStats enemyStats = new CreatureStats(100, 5, 5, 0);
            Enemy enemy = new Enemy("KEES D:", enemyStats);

            // Do a bunch of damaging and check if the values are correct
            hero.takeDamage(15);
            enemy.takeDamage(99);

            Assert.IsFalse(hero.IsDead, "Hero has " + hero.Stats.HP + "HP, but is dead.");
            Assert.IsFalse(enemy.IsDead, "Enemy has " + enemy.Stats.HP + "HP, but is dead.");

            hero.takeDamage(15);

            Assert.AreEqual(hero.Stats.MaxHP - 30, hero.Stats.HP, 0.0F, "Hero didn't take the expected amount of damage.");
            Assert.AreEqual(enemy.Stats.MaxHP - 99, enemy.Stats.HP, 0.0F, "Enemy didn't take the expected amount of damage.");

            hero.takeDamage(69);
            enemy.takeDamage(100);

            Assert.IsFalse(hero.IsDead, "Hero has " + hero.Stats.HP + "HP, but is dead.");
            Assert.IsTrue(enemy.IsDead, "Enemy has " + enemy.Stats.HP + "HP, but is alive.");

            hero.takeDamage(1);

            Assert.IsTrue(hero.IsDead, "Hero has " + hero.Stats.HP + "HP, but is alive.");
        }

        [TestMethod()]
        public void healDamageTest()
        {
            throw new NotImplementedException();
        }
    }
}