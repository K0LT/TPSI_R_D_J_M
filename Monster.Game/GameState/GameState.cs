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

        public List<Item> Inventory { get; set; } = new List<Item> { };

        public int Currency { get; set; }

        // Game progress, achievements, etc.

        public static GameState Current { get; private set; } = new GameState();

        public bool InventoryVisited { get; set; }

      

        public void UseItemAtIndex(int index)
        {
            if (index < 0 || index >= Inventory.Count)
                return;

            var item = Inventory[index];
            if (item == null || item.Quantity <= 0)
                return;

            var monster = ActiveMonster;

            switch (item)
            {
                case HealthItem healthItem:
                    monster.HealthPoints = Math.Min(monster.HealthPoints + healthItem.HealthRestore, 100);
                    break;
                case StaminaItem staminaItem:
                    monster.Stamina = Math.Min(monster.Stamina + staminaItem.StaminaRestore, 100);
                    break;
           
                case FullRestoreItem fullItem:
                    monster.HealthPoints = Math.Min(monster.HealthPoints + fullItem.HealthRestore, 100);
                    monster.Stamina = Math.Min(monster.Stamina + fullItem.StaminaRestore, 100);
                    break;
            }

            item.Quantity--;
        }
    }
}
