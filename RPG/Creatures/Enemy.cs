using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Creatures
{

    public class Enemy : Creature
    {
        DropTemplate drops = new DropTemplate();

        public Enemy(string name, CreatureStats stats) : base(name, stats, CreatureType.ENEMY)
        {

        }
    }
}
