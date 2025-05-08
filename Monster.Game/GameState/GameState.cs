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
        public User CurrentUser { get; set; }
        //public Monster ActiveMonster { get; set; }
        // public List<Monster> OwnedMonsters { get; set; }
        public Dictionary<string, int> Inventory { get; set; }
        public int Currency { get; set; }

        // Game progress, achievements, etc.

        public static GameState Current { get; private set; } = new GameState();

        public void SaveGame()
        {
            // Serialize state to JSON/XML
        }

        public static GameState LoadGame(string username)
        {
            // Deserialize from storage
            return new GameState();
        }
    }
}
