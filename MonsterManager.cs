using System.Windows.Forms;
using System.IO;

namespace Monster.Core
{
    public static class MonsterManager
    {
        public static bool RegisterMonster(string user, string selectedMonsterType, string monsterName)
        {
            if (string.IsNullOrEmpty(monsterName) || string.IsNullOrEmpty(selectedMonsterType)) return false;

            string userDirectoryPath = Path.Combine(Application.StartupPath, "Resources", user);
            string monstersFilePath = Path.Combine(userDirectoryPath, $"{user}_{selectedMonsterType}_monsters.txt");

            if (!File.Exists(monstersFilePath))
            {
                using (File.Create(monstersFilePath)) { }
            }

            using (StreamWriter sw = File.AppendText(monstersFilePath))
            {
                sw.WriteLine(monsterName);
            }
            return true;
        }
    }

}
