using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace Monster.Core
{
    public static class UserManager
    {
        private static string ResourcesPath = Path.Combine(Application.StartupPath, "Resources");

        public static bool RegisterUser(string username, string password)
        {
            string usernameFilePath = Path.Combine(ResourcesPath, "username.txt");
            string passwordFilePath = Path.Combine(ResourcesPath, "password.txt");
            string userDirectoryPath = Path.Combine(ResourcesPath, username);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password)) return false;

            var existingUsers = File.Exists(usernameFilePath) ? File.ReadAllLines(usernameFilePath) : new string[0];
            if (existingUsers.Contains(username)) return false;

            using (StreamWriter swUser = File.AppendText(usernameFilePath))
                swUser.WriteLine(username);

            using (StreamWriter swPass = File.AppendText(passwordFilePath))
                swPass.WriteLine(password);

            Directory.CreateDirectory(userDirectoryPath);
            return true;
        }

        public static void LoadPlayerType(string user)
        {
            string userDirectoryPath = Path.Combine(ResourcesPath, user);
            string playerTypeFilePath = Path.Combine(userDirectoryPath, "playerType.txt");

            if (File.Exists(playerTypeFilePath))
            {
                string playerType = File.ReadAllText(playerTypeFilePath).Trim();
                // Logic to set player type
            }
        }
    }
}
