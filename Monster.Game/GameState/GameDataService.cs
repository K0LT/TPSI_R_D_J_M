using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Monster.Game.GameState
{
    /// <summary>
    /// Handles persistent storage of game data using JSON serialization
    /// Stores save files in user's AppData folder for proper Windows integration
    /// </summary>
    public class GameDataService
    {
        #region Constants and Fields

        private const string SaveFileExtension = ".monster";

        // Store saves in AppData to avoid permission issues and follow Windows conventions
        private readonly string _saveDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MonsterGame", "Saves");

        #endregion

        #region Constructor

        public GameDataService()
        {
            // Ensure save directory exists on service creation
            // CreateDirectory is idempotent - won't fail if directory already exists
            Directory.CreateDirectory(_saveDirectory);
        }

        #endregion

        #region Save Operations

        /// <summary>
        /// Serialize and save game state to disk
        /// </summary>
        public void SaveGame(GameState state)
        {
            string filePath = GetSaveFilePath(state.CurrentUser.Username);

            // Use indented JSON for easier debugging and manual inspection
            string json = JsonSerializer.Serialize(state, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        #endregion

        #region Load Operations

        /// <summary>
        /// Load and deserialize game state from disk
        /// Returns null if save file doesn't exist (not an error condition)
        /// </summary>
        public GameState LoadGame(string username)
        {
            string filePath = GetSaveFilePath(username);

            if (!File.Exists(filePath))
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG-GDService]: LoadGame({username}): {filePath} not found, returning null to caller.");
                return null;
            }

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<GameState>(json);
        }

        /// <summary>
        /// Get list of all available save files for load game UI
        /// Returns usernames without file extensions
        /// </summary>
        public List<string> GetSavedGames()
        {
            return Directory.GetFiles(_saveDirectory, $"*{SaveFileExtension}")
                .Select(Path.GetFileNameWithoutExtension)
                .ToList();
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Generate standardized file path for save files
        /// Ensures consistent naming convention across all save operations
        /// </summary>
        private string GetSaveFilePath(string username)
        {
            return Path.Combine(_saveDirectory, $"{username}{SaveFileExtension}");
        }

        #endregion
    }
}