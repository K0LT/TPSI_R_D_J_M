using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster.Core.Models;

namespace Monster.Game.GameState
{
    public class GameState
    {
        private User _currentUser = new User();

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (value != null)
                {
                    _currentUser = value;
                }
                
            }
        }

        private MonsterClass _activeMonster = new MonsterClass();

        public MonsterClass ActiveMonster
        {
            get => _activeMonster;
            set
            {
                if (value != null)
                {
                    _activeMonster = value;
                }
            }
        }
        public List<MonsterClass>? OwnedMonsters { get; set; }
        public Dictionary<string, int>? Inventory { get; set; }
        public int Currency { get; set; }

        // Game progress, achievements, etc.

        public static GameState Current { get; private set; } = new GameState();
    }
}
