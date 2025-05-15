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
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] GameState::CurrentUser setter call.");
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
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] GameState::ActiveMonster setter call.");
                    _activeMonster = value;
                }
            }
        }
        public List<MonsterClass>? OwnedMonsters { get; set; } = new List<MonsterClass>();
        public List<Item> Inventory { get; set; } = new List<Item> { new HealthItem(), new StaminaItem() };
        
        public int Currency { get; set; }

        // Game progress, achievements, etc.

        public static GameState Current { get; private set; } = new GameState();

        public void AddExperience(int amount)
        {
            _activeMonster.AddExperience(amount);
        }
    }
}
