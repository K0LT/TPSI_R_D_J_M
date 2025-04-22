using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    internal class LevelGoals
    {

        public int FeedCount { get; private set; }
        public int CorrectGamesCount { get; private set; }
        public int Level { get; private set; }
        public int Attack { get; private set; }
        public int Exp { get; private set; }
        public int Stamina { get; private set; }

        // Dicionário para armazenar os requisitos de cada nível
        private Dictionary<int, (int feedGoal, int correctGamesGoal, int attackThreshold)> levelRequirements;

        public LevelGoals()
        {
            FeedCount = 0;
            CorrectGamesCount = 0;
            Level = 0;
            Attack = 0;
            Exp = 0;
            Stamina = 0;

  

        }



    }
}

