using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Creatures
{
    public class Hero : Creature
    {
        public Hero(string name, CreatureStats stats) : base(name, stats, CreatureType.HERO)
        {

        }
        //TODO add level system
    }
}
