using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace Monster.Core
{
    public class Monster
    {
        public string User { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int Level { get; set; } = 0;
        public int MaxLevel { get; set; } = 10;

        public int HP { get; set; } = 15;
        public int MaxHP { get; set; } = 15;

        public int Stamina { get; set; } = 20;
        public int MaxStamina { get; set; } = 20;

        public int Exp { get; set; } = 0;
        public int MaxExp { get; set; } = 100;
    }

    public class MonsterData
    {
        public List<Monster> Monsters { get; set; } = new List<Monster>();
    }

    public static class MonsterManager
    {
        private static readonly string ResourcesPath = Path.Combine(Application.StartupPath, "Resources");
        private static readonly string MonstersFilePath = Path.Combine(ResourcesPath, "monsters.json");

        public static bool RegisterMonster(string user, string selectedMonsterType, string monsterName)
        {
            if (string.IsNullOrWhiteSpace(monsterName) || string.IsNullOrWhiteSpace(selectedMonsterType))
                return false;

            EnsureJsonFileExists();

            var monsterData = LoadMonstersData();

            // Verifica se o monstro já existe para o utilizador
            bool alreadyExists = monsterData.Monsters.Any(m =>
                m.User == user && m.Name.Equals(monsterName, StringComparison.OrdinalIgnoreCase));

            if (alreadyExists)
                return false;

            // Inicializa o novo monstro com os valores padrões
            var newMonster = new Monster
            {
                User = user,
                Name = monsterName,
                Type = selectedMonsterType,
                Level = 0, // Nivel inicial
                MaxLevel = 10, // Max level
                HP = 15, // HP inicial
                MaxHP = 15, // Max HP
                Stamina = 20, // Stamina inicial
                MaxStamina = 20, // Max Stamina
                Exp = 0, // Experiência inicial
                MaxExp = 100 // Max Exp
            };

            // Adiciona o novo monstro à lista
            monsterData.Monsters.Add(newMonster);
            SaveMonstersData(monsterData);

            return true;
        }

        private static void EnsureJsonFileExists()
        {
            if (!Directory.Exists(ResourcesPath))
                Directory.CreateDirectory(ResourcesPath);

            if (!File.Exists(MonstersFilePath))
                SaveMonstersData(new MonsterData()); // Cria o arquivo vazio se não existir
        }

        private static MonsterData LoadMonstersData()
        {
            var json = File.ReadAllText(MonstersFilePath);
            return JsonSerializer.Deserialize<MonsterData>(json) ?? new MonsterData();
        }

        private static void SaveMonstersData(MonsterData data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(MonstersFilePath, json);
        }
    }

}
