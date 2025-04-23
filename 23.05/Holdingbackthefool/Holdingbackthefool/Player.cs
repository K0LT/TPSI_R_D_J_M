using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Holdingbackthefool
{
    internal class Player
    {
        public string name { get; set; }

        //Tempo jogado
        public string timePlayed { get; set; }

        public List<Monster> myMonsters;

        public Player()
        {
            name = "Undefined Player name";
            myMonsters = new List<Monster>();
            timePlayed = "0";
        }

        public bool AddMonster(Monster m)
        {
            if (myMonsters.Count < 4)
            {
                myMonsters.Add(m);
                return true;
            }
            return false;
        }

    }
}
