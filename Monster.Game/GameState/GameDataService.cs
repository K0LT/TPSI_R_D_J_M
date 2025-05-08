using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Monster.Game.GameState
{
    public class GameDataService
    {
        private const string SaveFileExtension = ".monster";
        private readonly string _saveDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MonsterGame", "Saves");

        public GameDataService()
        {
            // Ensure save directory exists
            Directory.CreateDirectory(_saveDirectory);
        }

        public void SaveGame(GameState state, string username)
        {
            string filePath = GetSaveFilePath(username);
            string json = JsonSerializer.Serialize(state, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }

        public GameState LoadGame(string username)
        {
            string filePath = GetSaveFilePath(username);
            if (!File.Exists(filePath))
            {
                return null;
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<GameState>(json);
        }

        public List<string> GetSavedGames()
        {
            return Directory.GetFiles(_saveDirectory, $"*{SaveFileExtension}")
                .Select(Path.GetFileNameWithoutExtension)
                .ToList();
        }

        private string GetSaveFilePath(string username)
        {
            return Path.Combine(_saveDirectory, $"{username}{SaveFileExtension}");
        }
    }
}
