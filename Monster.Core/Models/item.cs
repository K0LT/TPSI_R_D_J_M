using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.ComponentModel;
using System.Drawing;
using System.Text.Json.Serialization;

namespace Monster.Core.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(HealthItem), "Health Item")]
    [JsonDerivedType(typeof(StaminaItem), "Stamina Item")]
    [JsonDerivedType(typeof(ExperienceItem), "Experience Item")]
    [JsonDerivedType(typeof(FullRestoreItem), "FullRestoreItem")]
    public abstract class Item : INotifyPropertyChanged
    {
        private string _name;
        private int _quantity;

        private Image _icon;

        [JsonIgnore]
        public Image Icon { get; protected set; }

        public string Name
        {
            get => _name;
            protected set
            {
                if (_name != value)
                {
                    _name = value;
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
        private string _iconName;
        public string IconName
        {
            get => _iconName;
            protected set
            {
                if (_iconName != value)
                {
                    _iconName = value;
                    OnPropertyChanged();
                }
            }
        }

        protected Item(string name, Image icon, int quantity = 0)
        {
            _name = name;
            _icon = icon;
            _quantity = quantity;
        }

        public virtual int Use() { return 0; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public class HealthItem : Item
    {
        public int HealthRestore { get; }

        public HealthItem(string name, Image icon, int healthRestore, int quantity = 0)
            : base(name, icon, quantity)
        {
            HealthRestore = healthRestore;
        }

        public override int Use()
        {
            return HealthRestore;
        }
    }

    public class StaminaItem : Item
    {
        public int StaminaRestore { get; }

        public StaminaItem(string name, Image icon, int staminaRestore, int quantity = 0)
            : base(name, icon, quantity)
        {
            StaminaRestore = staminaRestore;
        }

        public override int Use()
        {
            return StaminaRestore;
        }
    }

    public class ExperienceItem : Item
    {
        public int ExperienceGain { get; }

        public ExperienceItem(string name, Image icon, int experienceGain, int quantity = 0)
            : base(name, icon, quantity)
        {
            ExperienceGain = experienceGain;
        }

        public override int Use()
        {
            return ExperienceGain;
        }
    }

    public class FullRestoreItem : Item
    {
        public int HealthRestore { get; }
        public int StaminaRestore { get; }
        public int ExperienceGain { get; }

        public FullRestoreItem(string name, Image icon, int healthRestore, int staminaRestore, int experienceGain, int quantity = 0)
            : base(name, icon, quantity)
        {
            HealthRestore = healthRestore;
            StaminaRestore = staminaRestore;
            ExperienceGain = experienceGain;
        }

        public override int Use()
        {
            return HealthRestore;
        }
    }
}

