using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Drawing;
using System.Resources;

namespace Monster.Core.Models
{
    /// <summary>
    /// Core monster entity with stat management, leveling system, and visual evolution
    /// Implements data binding for real-time UI updates during gameplay
    /// </summary>
    public class MonsterClass : INotifyPropertyChanged
    {
        #region Private Fields

        private string _name = "";
        private string _type = "draco";
        private int _healthPoints = 100;
        private int _experiencePoints = 0;
        private int _level = 1;
        private int _stamina = 100;
        private Image _monsterImage;
        private Image _monsterIcon;

        #endregion

        #region Constructor

        public MonsterClass()
        {
            System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass constructor call.");
            // Initialize visual representation based on starting level
            UpdateMonsterImage();
        }

        #endregion

        #region Core Properties

        /// <summary>
        /// Monster's display name - customizable by player
        /// </summary>
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

        /// <summary>
        /// Monster species type - determines visual appearance and evolution path
        /// Triggers image update when changed to reflect new monster type
        /// </summary>
        public string Type
        {
            get => _type;
            set
            {
                if (_type != value) // Fixed bug: was checking _name instead of _type
                {
                    _type = value;
                    OnPropertyChanged();
                    UpdateMonsterImage(); // Visual appearance depends on type
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass Type Setter Call.");
                }
            }
        }

        #endregion

        #region Combat Stats

        /// <summary>
        /// Current health - cannot go below 0 (monster faints but doesn't die)
        /// </summary>
        public int HealthPoints
        {
            get => _healthPoints;
            set
            {
                // Prevent negative health to avoid game logic issues
                int newValue = value < 0 ? 0 : value;
                if (_healthPoints != newValue)
                {
                    _healthPoints = newValue;
                    OnPropertyChanged(nameof(HealthPoints));
                }
            }
        }

        /// <summary>
        /// Current stamina for activities - depleted by games and battles
        /// </summary>
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

        #endregion

        #region Progression System

        /// <summary>
        /// Experience points - automatically handles level up when reaching 100
        /// Resets to 0 and increments level when threshold is reached
        /// </summary>
        public int ExperiencePoints
        {
            get => _experiencePoints;
            set
            {
                // Handle level up logic when experience exceeds maximum
                if (_experiencePoints + value > 100)
                {
                    _experiencePoints = 0;
                    Level += 1; // This will trigger visual evolution
                    OnPropertyChanged();
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass ExperiencePoints Setter Call. Level incremented by 1 to : " + Level);
                    return;
                }
                _experiencePoints += value;
                OnPropertyChanged();
                System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass ExperiencePoints Setter Call.");
            }
        }

        /// <summary>
        /// Current level - determines monster's visual evolution stage
        /// Triggers image update to show evolved form
        /// </summary>
        public int Level
        {
            get => _level;
            set
            {
                if (value != null) // Note: int can't be null - this check is redundant
                {
                    _level = value;
                    UpdateMonsterImage(); // Visual evolution based on level
                    OnPropertyChanged();
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass Level Setter Call.");
                }
            }
        }

        /// <summary>
        /// Public method for awarding experience from battles and activities
        /// Validates input to prevent negative experience exploits
        /// </summary>
        public void AddExperience(int amount)
        {
            System.Diagnostics.Debug.WriteLine(@"[DEBUG] AddExperience call, current experience: " + ExperiencePoints);

            if (amount <= 0)
            {
                System.Diagnostics.Debug.WriteLine(@"[DEBUG] AddExperience call, invalid amount: " + amount);
                return;
            }

            ExperiencePoints += amount;
            System.Diagnostics.Debug.WriteLine(@"[DEBUG] AddExperience call, added: " + amount + " | current experience: " + ExperiencePoints);
        }

        #endregion

        #region Visual Representation

        /// <summary>
        /// Main monster image for detailed view - shows current evolution stage
        /// </summary>
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

        /// <summary>
        /// Small icon version for UI elements like lists and menus
        /// </summary>
        public Image MonsterIcon
        {
            get => _monsterIcon;
            private set
            {
                if (_monsterIcon != value)
                {
                    _monsterIcon = value;
                    OnPropertyChanged();
                    System.Diagnostics.Debug.WriteLine(@"[DEBUG] MonsterClass Icon Setter Call.");
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Update monster visuals based on current type and level
        /// Implements 3-stage evolution system: levels 1-4, 5-9, 10+
        /// </summary>
        private void UpdateMonsterImage()
        {
            // Determine evolution stage based on level ranges
            int stage = _level < 5 ? 1 : _level < 10 ? 2 : 3;
            string type = Type?.ToLower() ?? "";
            string resourceName = $"{type}_stage{stage}";
            string iconName = $"{type}_stage{stage}_icon";

            System.Diagnostics.Debug.WriteLine("UpdateMonsterImage call! iconName: " + iconName + " | resourceName: " + resourceName);

            // Load images from embedded resources
            var imageObj = monsterImages.ResourceManager.GetObject(resourceName);
            var iconObj = monsterImages.ResourceManager.GetObject(iconName);

            MonsterImage = ConvertByteArrayToImage(imageObj as byte[]);
            MonsterIcon = ConvertByteArrayToImage(iconObj as byte[]);
        }

    



        /// <summary>
        /// Convert embedded resource byte arrays to Image objects for UI display
        /// </summary>
        private Image ConvertByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Automatic property change notification for UI data binding
        /// </summary>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}