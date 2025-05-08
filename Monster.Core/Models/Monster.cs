using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Monster.Core.Models
{
    public class Monster : INotifyPropertyChanged
    {
        private string _name = "defaultMonsterName";
        private string _type = "defaultMonsterType";
        private int _experiencePoints;
        private int _level = 1;
        private int _hp = 100;
        private int _maxHP = 100;
        private int _attack = 10;
        private int _stamina = 100;
        private int _maxStamina = 100;

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

        public string Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ExperiencePoints
        {
            get => _experiencePoints;
            set
            {
                if (_experiencePoints != value)
                {
                    _experiencePoints = value;
                    OnPropertyChanged();
                    CheckLevelUp();
                }
            }
        }

        public int Level
        {
            get => _level;
            private set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged();
                }
            }
        }

        public int HP
        {
            get => _hp;
            set
            {
                value = Math.Clamp(value, 0, MaxHP);
                if (_hp != value)
                {
                    _hp = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MaxHP
        {
            get => _maxHP;
            set
            {
                if (_maxHP != value)
                {
                    _maxHP = value;
                    HP = Math.Clamp(HP, 0, _maxHP); // Adjust current HP if max changes
                    OnPropertyChanged();
                }
            }
        }

        public int Attack
        {
            get => _attack;
            set
            {
                if (_attack != value)
                {
                    _attack = value;
                    OnPropertyChanged();
                }
            }
        }

      
        public int Stamina
        {
            get => _stamina;
            set
            {
                value = Math.Clamp(value, 0, MaxStamina);
                if (_stamina != value)
                {
                    _stamina = value;
                    OnPropertyChanged();
                }
            }
        }

        public int MaxStamina
        {
            get => _maxStamina;
            set
            {
                if (_maxStamina != value)
                {
                    _maxStamina = value;
                    Stamina = Math.Clamp(Stamina, 0, _maxStamina); // Adjust current stamina if max changes
                    OnPropertyChanged();
                }
            }
        }

        private void CheckLevelUp()
        {
            int requiredExp = Level * 100;
            if (ExperiencePoints >= requiredExp)
            {
                Level++;
                MaxHP += 10;
                HP = MaxHP; // Fully heal on level up
                Attack += 5;
                MaxStamina += 10;
                Stamina = MaxStamina; // Restore all stamina on level up
                ExperiencePoints -= requiredExp;
            }
        }

        public void UseItem(Item item)
        {
            if (item != null)
            {
                item.ApplyEffects(this);
            }
        }

        public void RestoreAll()
        {
            HP = MaxHP;
            Stamina = MaxStamina;
        }

        public Monster Clone()
        {
            return new Monster
            {
                Name = this.Name,
                Type = this.Type,
                Level = this.Level,
                HP = this.HP,
                MaxHP = this.MaxHP,
                Attack = this.Attack,
                Stamina = this.Stamina,
                MaxStamina = this.MaxStamina,
                ExperiencePoints = this.ExperiencePoints
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}