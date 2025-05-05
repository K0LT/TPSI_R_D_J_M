using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Monster.Core
{
    public class UserData
    {
        public List<User> Users { get; set; } = new List<User>();
    }

    public class User
    {
        public string Username { get; set; }
        public string PlayerType { get; set; }
    }

    public static class UserManager
    {
        private static readonly string ResourcesPath = Path.Combine(Application.StartupPath, "Resources");
        private static readonly string JsonFilePath = Path.Combine(ResourcesPath, "users.json");

        public static bool RegisterUser(string username, string playerType)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(playerType))
                return false;

            EnsureJsonFileExists();

            var usersData = LoadUsersData();
            if (usersData.Users.Any(u => u.Username == username))
                return false;

            usersData.Users.Add(new User { Username = username, PlayerType = playerType });
            SaveUsersData(usersData);

            string userDirectoryPath = Path.Combine(ResourcesPath, username);
            Directory.CreateDirectory(userDirectoryPath);

            return true;
        }

        public static string LoadPlayerType(string username)
        {
            EnsureJsonFileExists();

            var usersData = LoadUsersData();
            var user = usersData.Users.FirstOrDefault(u => u.Username == username);
            return user?.PlayerType ?? "";
        }

        public static void SavePlayerType(string username, string playerType)
        {
            EnsureJsonFileExists();

            var usersData = LoadUsersData();
            var user = usersData.Users.FirstOrDefault(u => u.Username == username);
            if (user != null)
            {
                user.PlayerType = playerType;
                SaveUsersData(usersData);
            }
        }

        private static void EnsureJsonFileExists()
        {
            if (!Directory.Exists(ResourcesPath))
                Directory.CreateDirectory(ResourcesPath);

            if (!File.Exists(JsonFilePath))
                SaveUsersData(new UserData());
        }

        private static UserData LoadUsersData()
        {
            var json = File.ReadAllText(JsonFilePath);
            return JsonSerializer.Deserialize<UserData>(json) ?? new UserData();
        }

        private static void SaveUsersData(UserData data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JsonFilePath, json);
        }
    }

}

