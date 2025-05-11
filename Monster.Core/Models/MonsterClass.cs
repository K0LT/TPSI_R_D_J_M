using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;

namespace Monster.Core.Models
{
    public class MonsterClass : INotifyPropertyChanged
    {
        // TODO: ADD DATE_TIME IMPLEMENTATION

        private string _name = "defaultMonsterType";
        private string _type = "draco";
        private int _healthPoints = 50;
        private int _experiencePoints = 0;
        private int _level = 1;
        private int _energy = 100;
        private Image _monsterImage;
        
        public MonsterClass()
        {
            UpdateMonsterImage();
        }

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
                if (_experiencePoints + value > 100)
                {
                    _experiencePoints = 0;
                    _level += 1;
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
                    UpdateMonsterImage();
                    OnPropertyChanged();
                }
            }
        }

        private void UpdateMonsterImage()
        {
            int stage = _level < 5 ? 1 : _level < 10 ? 2 : 3;
            string type = Type?.ToLower() ?? "default";
            string resourceName = $"{type}_stage{stage}";

            // TODO: Add monster images as Monster.Core resources
            var imageObj = monsterImages.ResourceManager.GetObject(resourceName);
            //Default
            MonsterImage = ConvertByteArrayToImage(imageObj as byte[]);
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
        public Image MonsterImage
        {
            get => _monsterImage;
            private set
            {
                if (_monsterImage != value)
                {
                    _monsterImage = value;
                    OnPropertyChanged();
                }
            }
        }

        private Image ConvertByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}