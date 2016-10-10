using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    class ongoingbattles
    {
        static List<Battle> ongoingbattlelist = new List<Battle>();

        static public bool checkifoccupied(Creature creature)
        {
            bool sofar = false;
            foreach (Battle b in ongoingbattlelist)
            {
                if (b.everyone.Contains(creature))
                    sofar = true;
            }
            return sofar;
        }
        static public void draw()
        {
            //TODO make a function that draws the ongoing battles, clickable so you can see their status
           
        }

    }
}
