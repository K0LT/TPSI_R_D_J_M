using System.Collections.Generic;
using System.IO;
using System.Linq;
using Monster.Core.Models;
using Newtonsoft.Json;

namespace Monster.Core.Managers
{
    public static class Inventory
    {
        private static string _itemsFile = "itens.json";
        private static List<Item> _playerItems = new List<Item>();

        public static List<Item> LoadItems()
        {
            if (!File.Exists(_itemsFile))
                return new List<Item>();

            string json = File.ReadAllText(_itemsFile);
            return JsonConvert.DeserializeObject<List<Item>>(json) ?? new List<Item>();
        }

        public static void SaveItems(List<Item> items)
        {
            string json = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(_itemsFile, json);
        }

        public static void AddItem(Item item)
        {
            var items = _playerItems;
            var existing = items.FirstOrDefault(i => i.Name == item.Name);

            if (existing != null)
            {
                existing.Quantity += item.Quantity;
            }
            else
            {
                items.Add(item);
            }

            SavePlayerInventory();
        }

        public static void RemoveItem(string itemName, int quantity = 1)
        {
            var item = _playerItems.FirstOrDefault(i => i.Name == itemName);

            if (item != null)
            {
                item.Quantity -= quantity;
                if (item.Quantity <= 0)
                {
                    _playerItems.Remove(item);
                }
                SavePlayerInventory();
            }
        }

        public static Item GetItem(string itemName)
        {
            return _playerItems.FirstOrDefault(i => i.Name == itemName);
        }

        public static List<Item> GetPlayerItems()
        {
            return _playerItems;
        }

        public static void LoadPlayerInventory()
        {
            if (File.Exists("player_inventory.json"))
            {
                string json = File.ReadAllText("player_inventory.json");
                _playerItems = JsonConvert.DeserializeObject<List<Item>>(json) ?? new List<Item>();
            }
        }

        public static void SavePlayerInventory()
        {
            string json = JsonConvert.SerializeObject(_playerItems, Formatting.Indented);
            File.WriteAllText("player_inventory.json", json);
        }

        public static void AddRewards(List<Item> rewards)
        {
            foreach (var reward in rewards)
            {
                AddItem(reward);
            }
        }
    }
}