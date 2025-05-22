using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster.Core.Models;

namespace Monster.Game.GameState
{
    /// <summary>
    /// Central game state container that holds all persistent game data
    /// Implements singleton pattern for global access while maintaining serialization support
    /// </summary>
    public class GameState
    {
        #region Core Game Entities

        private User _currentUser = new User();

        /// <summary>
        /// Current player - null protection ensures game state remains valid
        /// </summary>
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

        /// <summary>
        /// Currently selected monster for gameplay actions
        /// Null protection prevents crashes when switching between monsters
        /// </summary>
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

        /// <summary>
        /// All monsters owned by the player - nullable for JSON deserialization compatibility
        /// </summary>
        public List<MonsterClass>? OwnedMonsters { get; set; } = new List<MonsterClass>();

        #endregion

        #region Inventory and Economy

        public List<Item> Inventory { get; set; } = new List<Item>();
        public int Currency { get; set; }

        #endregion

        #region Game Progress Tracking

        /// <summary>
        /// Singleton instance for global state access throughout the application
        /// Allows any component to access current game state without dependency injection
        /// </summary>
        public static GameState Current { get; private set; } = new GameState();

        /// <summary>
        /// Tracks tutorial progress - whether player has discovered inventory system
        /// </summary>
        public bool InventoryVisited { get; set; }

        #endregion

        #region Item Usage System

        /// <summary>
        /// Apply item effects to active monster and consume item
        /// Handles different item types with polymorphic behavior
        /// </summary>
        public void UseItemAtIndex(int index)
        {
            // Bounds checking to prevent index errors
            if (index < 0 || index >= Inventory.Count)
                return;

            var item = Inventory[index];

            // Validate item exists and has quantity available
            if (item == null || item.Quantity <= 0)
                return;

            var monster = ActiveMonster;

            // Pattern matching on item type to apply appropriate effects
            // Each item type has different restoration properties
            switch (item)
            {
                case HealthItem healthItem:
                    // Cap health at 100 to prevent over-healing
                    monster.HealthPoints = Math.Min(monster.HealthPoints + healthItem.HealthRestore, 100);
                    break;

                case StaminaItem staminaItem:
                    // Cap stamina at 100 to prevent over-restoration
                    monster.Stamina = Math.Min(monster.Stamina + staminaItem.StaminaRestore, 100);
                    break;

                case FullRestoreItem fullItem:
                    // Full restore items affect both stats
                    monster.HealthPoints = Math.Min(monster.HealthPoints + fullItem.HealthRestore, 100);
                    monster.Stamina = Math.Min(monster.Stamina + fullItem.StaminaRestore, 100);
                    break;
            }

            // Consume one unit of the item after use
            item.Quantity--;
        }

        #endregion
    }
}