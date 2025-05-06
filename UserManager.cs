using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Monster.Core
{
    // Represents the collection of all users
    public class UserData
    {
        public List<User> Users { get; set; } = new List<User>();
    }

    // Represents a single user with property change notifications
    public class User : INotifyPropertyChanged
    {
        private string _playerType;
        private string _username;

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string PlayerType
        {
            get => _playerType;
            set
            {
                if (_playerType != value)
                {
                    _playerType = value;
                    OnPropertyChanged(nameof(PlayerType));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    // Manages user-related operations
    public static class UserManager
    {
        private static readonly string ResourcesPath = Path.Combine(Application.StartupPath, "Resources");
        private static readonly string usersFilePath = Path.Combine(ResourcesPath, "users.json");

        /// <summary>
        ///     Registers a new user and returns the created User object.
        /// </summary>
        public static User RegisterUserAndReturn(string username, string playerType)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(playerType))
                return null;

            if (!RegisterUser(username, playerType))
                return null;

            return new User { Username = username, PlayerType = playerType };
        }

        /// <summary>
        ///     Registers a new user by saving their data to persistent storage.
        /// </summary>
        public static bool RegisterUser(string username, string playerType)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(playerType))
                return false;

            EnsureJsonFileExists();

            var usersData = LoadUsersData();
            if (usersData.Users.Any(u => u.Username == username))
                return false; // Username already exists

            // Add the new user and save the data
            usersData.Users.Add(new User { Username = username, PlayerType = playerType });
            SaveUsersData(usersData);

            // Create a directory for the user
            CreateUserDirectory(username);

            return true;
        }

        /// <summary>
        ///     Loads the player type for a given username.
        /// </summary>
        public static string LoadPlayerType(string username)
        {
            EnsureJsonFileExists();

            var usersData = LoadUsersData();
            var user = usersData.Users.FirstOrDefault(u => u.Username == username);
            return user?.PlayerType ?? string.Empty;
        }

        /// <summary>
        ///     Updates and saves the player type for a given username.
        /// </summary>
        public static void SavePlayerType(string username, string playerType)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(playerType))
                return;

            EnsureJsonFileExists();

            var usersData = LoadUsersData();
            var user = usersData.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.PlayerType = playerType;
                SaveUsersData(usersData);
            }
        }

        /// <summary>
        ///     Ensures the JSON file and resources directory exist.
        /// </summary>
        private static void EnsureJsonFileExists()
        {
            if (!Directory.Exists(ResourcesPath))
                Directory.CreateDirectory(ResourcesPath);

            if (!File.Exists(usersFilePath))
                SaveUsersData(new UserData());
        }

        /// <summary>
        ///     Loads all user data from the JSON file.
        /// </summary>
        public static UserData LoadUsersData()
        {
            var json = File.ReadAllText(usersFilePath);
            return JsonSerializer.Deserialize<UserData>(json) ?? new UserData();
        }

        /// <summary>
        ///     Saves all user data to the JSON file.
        /// </summary>
        private static void SaveUsersData(UserData data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(usersFilePath, json);
        }

        /// <summary>
        ///     Creates a directory for the user if it doesn't already exist.
        /// </summary>
        private static void CreateUserDirectory(string username)
        {
            var userDirectoryPath = Path.Combine(ResourcesPath, username);
            if (!Directory.Exists(userDirectoryPath))
                Directory.CreateDirectory(userDirectoryPath);
        }
    }
}