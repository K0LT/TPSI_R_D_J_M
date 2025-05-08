using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Monster.Core.Models
{
    public class Item : INotifyPropertyChanged
    {
        private string _name = "defaultItemName";
        private string _description = "defaultItemDescription";
        private Dictionary<string, int> _effects = new Dictionary<string, int>();

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
            if (Effects.ContainsKey(nameof(Monster.Stamina)))
                monster.Stamina += Effects[nameof(Monster.Stamina)];

            if (Effects.ContainsKey(nameof(Monster.HP)))
                monster.HP += Effects[nameof(Monster.HP)];

           
        
        }
    }
}