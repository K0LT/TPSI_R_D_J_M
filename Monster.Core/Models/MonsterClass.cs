using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Monster.Core.Models
{
    public class MonsterClass : INotifyPropertyChanged
    {
        // TODO: ADD DATE_TIME IMPLEMENTATION

        private string _name = "defaultMonsterType";
        private string _type = "defaultMonsterType";
        private int _healthPoints = 10;
        private int _experiencePoints = 0;
        private int _level = 1;
        private int _energy = 100;
        
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
                if (_name != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int HealthPoints
        {
            get => _healthPoints;
            set
            {
                if (_healthPoints != value)
                {
                    _healthPoints = value;
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
                }
            }
        }
        
        public int Level
        {
            get => _level;
            set
            {
                if (_level != value)
                {
                    _level = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int Energy
        {
            get => _energy;
            set
            {
                if (_energy != value)
                {
                    _energy = value;
                    OnPropertyChanged();
                }
            }
        }

        // TODO: Add rest of properties

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}