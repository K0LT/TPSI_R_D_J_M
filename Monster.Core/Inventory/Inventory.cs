using System.Collections.Generic;
using System.IO;
using Monster.Core.Models;
using Newtonsoft.Json;

namespace Monster.Core.Managers
{
    public static class Inventory
    {
        private static string _itemsFile = "itens.json";

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

        public static void SaveItem(Item item)
        {
            var items = LoadItems();
            int index = items.FindIndex(i => i.Name == item.Name);

            if (index >= 0)
                items[index] = item;
            else
                items.Add(item);

            SaveItems(items);
        }

        public static void RemoveItem(string itemName)
        {
            var items = LoadItems();
            items.RemoveAll(i => i.Name == itemName);
            SaveItems(items);
        }

        public static Item GetItem(string itemName)
        {
            var items = LoadItems();
            return items.Find(i => i.Name == itemName);
        }
    }
}