using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace Monster.Core.Models
{
    public class Item : INotifyPropertyChanged
    {
        private string _name = "defaultItemName";
        private string _description = "defaultItemDescription";
        private Dictionary<string, int> _effects = new Dictionary<string, int>();
        private int _quantity = 1;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public Dictionary<string, int> Effects
        {
            get => _effects;
            set
            {
                if (_effects != value)
                {
                    _effects = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonIgnore]
        public string EffectsJson
        {
            get => JsonConvert.SerializeObject(_effects);
            set => _effects = JsonConvert.DeserializeObject<Dictionary<string, int>>(value ?? "{}");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ApplyEffects(Monster monster)
        {
            foreach (var effect in Effects)
            {
                switch (effect.Key.ToLower())
                {
                    case "hp":
                        monster.HP += effect.Value;
                        if (monster.HP > monster.MaxHP) monster.HP = monster.MaxHP;
                        break;
                    case "stamina":
                        monster.Stamina += effect.Value;
                        if (monster.Stamina > monster.MaxStamina) monster.Stamina = monster.MaxStamina;
                        break;
                }
            }
        }

        public Item Clone()
        {
            return new Item
            {
                Name = this.Name,
                Description = this.Description,
                Effects = new Dictionary<string, int>(this.Effects),
                Quantity = 1
            };
        }
    }
}