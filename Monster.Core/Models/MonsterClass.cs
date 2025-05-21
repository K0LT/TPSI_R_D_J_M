using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Xml.Linq;
using System.Diagnostics;

namespace Monster.Core.Models
{
    public class MonsterClass : INotifyPropertyChanged
    {

        private string _name = "";
        private string _type = "draco";
        private int _healthPoints = 50;
        private int _experiencePoints = 0;
        private int _level = 10;
        private int _stamina = 50;
        private Image _monsterImage;
        private Image _monsterIcon;
        public MonsterClass()
        {
            
            System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass constructor call.");
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
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass Name Setter Call.");
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
                    UpdateMonsterImage();
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass Type Setter Call.");
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
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass HealthPoints Setter Call.");
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
                    Level += 1;
                    OnPropertyChanged();
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass ExperiencePoints Setter Call. Level incremented by 1 to : " + Level);
                    return;
                }
                _experiencePoints += value;
                OnPropertyChanged();
                System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass ExperiencePoints Setter Call.");
            }
        }

        public int Level
        {
            get => _level;
            set
            {
                if (value != null)
                {
                    _level = value;
                    UpdateMonsterImage();
                    OnPropertyChanged();
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass Level Setter Call.");
                }
            }
        }

        private void UpdateMonsterImage()
        {
            int stage = _level < 5 ? 1 : _level < 10 ? 2 : 3;
            string type = Type?.ToLower() ?? "";
            string resourceName = $"{type}_stage{stage}";
            string iconName = $"{type}_icon";
            System.Diagnostics.Debug.WriteLine("UpdateMonsterImage call! iconName: " + iconName + " | resourceName: " + resourceName);
            var imageObj = monsterImages.ResourceManager.GetObject(resourceName);
            var iconObj = monsterImages.ResourceManager.GetObject(iconName);
            MonsterImage = ConvertByteArrayToImage(imageObj as byte[]);
            MonsterIcon = ConvertByteArrayToImage(iconObj as byte[]);

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
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass Stamina Setter Call.");
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
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass MonsterImage Setter Call.");
                }
            }
        }

        public Image MonsterIcon
        {
            get => _monsterIcon;
            private set
            {
                if (_monsterIcon != value)
                {
                    _monsterIcon = value;
                    OnPropertyChanged();
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass Image Setter Call.");
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
        public void AddExperience(int amount)
        {
            System.Diagnostics.Debug.WriteLine(@"[DEBUG] AddExperience call, current experience: " + ExperiencePoints);
            if (amount <= 0)
            {
                System.Diagnostics.Debug.WriteLine(@"[DEBUG] AddExperience call, value: " + amount);
                return;
            }
            ExperiencePoints += amount;
            System.Diagnostics.Debug.WriteLine(@"[DEBUG] AddExperience call, value: " + amount + " | current experience: " + ExperiencePoints);
        }


    }
}