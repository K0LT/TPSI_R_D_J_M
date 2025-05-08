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
        private int _attack = 10;
        private int _stamina = 100;

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
                if (_hp != value)
                {
                    _hp = value;
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
                if (_stamina != value)
                {
                    _stamina = value;
                    OnPropertyChanged();
                }
            }
        }

        private void CheckLevelUp()
        {
            // Lógica simples de level up
            int requiredExp = Level * 100;
            if (ExperiencePoints >= requiredExp)
            {
                Level++;
                HP += 10;
                Attack += 5;
                Stamina += 5;
                ExperiencePoints -= requiredExp;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UseItem(Item item)
        {
            if (item != null)
            {
                item.ApplyEffects(this);
            }
        }
    }
}