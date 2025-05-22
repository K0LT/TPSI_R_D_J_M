using System.Runtime.CompilerServices;
using System.Drawing;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Monster.Core.Models
{
    /// <summary>
    /// Base class for all consumable items in the monster game
    /// Implements data binding for UI updates and JSON polymorphism for save/load
    /// </summary>
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(HealthItem), "Health Item")]
    [JsonDerivedType(typeof(StaminaItem), "Stamina Item")]
    [JsonDerivedType(typeof(FullRestoreItem), "FullRestoreItem")]
    public abstract class Item : INotifyPropertyChanged
    {
        #region Private Fields

        private string _name;
        private int _quantity;
        private Image _icon;
        private string _iconName;

        #endregion

        #region Public Properties

        /// <summary>
        /// Item icon for UI display - excluded from JSON to avoid serialization issues with Image objects
        /// </summary>
        [JsonIgnore]
        public Image Icon { get; protected set; }

        /// <summary>
        /// Item display name with change notification for UI binding
        /// Protected setter prevents external modification while allowing derived classes to set it
        /// </summary>
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

        /// <summary>
        /// Available quantity - decreases when items are consumed
        /// Public setter allows inventory management from game logic
        /// </summary>
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

        /// <summary>
        /// String identifier for icon - serializable alternative to Image object
        /// Used to reconstruct UI elements after loading from save file
        /// </summary>
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

        #endregion

        #region Constructor

        /// <summary>
        /// Base constructor for all item types
        /// </summary>
        /// <param name="name">Display name for the item</param>
        /// <param name="icon">UI icon (not serialized)</param>
        /// <param name="quantity">Initial quantity (defaults to 0)</param>
        protected Item(string name, Image icon, int quantity = 0)
        {
            _name = name;
            _icon = icon;
            _quantity = quantity;
        }

        #endregion

        #region Virtual Methods

        /// <summary>
        /// Base implementation for item usage - overridden by derived classes
        /// Returns effect value (health/stamina restoration amount)
        /// </summary>
        public virtual int Use() { return 0; }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Automatic property change notification using CallerMemberName
        /// Eliminates need to manually specify property names, reducing errors
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion
    }

    #region Derived Item Classes

    /// <summary>
    /// Consumable item that restores monster health points
    /// </summary>
    public class HealthItem : Item
    {
        /// <summary>
        /// Amount of health restored when consumed
        /// </summary>
        public int HealthRestore { get; }

        public HealthItem(string name, Image icon, int healthRestore, int quantity = 0)
            : base(name, icon, quantity)
        {
            HealthRestore = healthRestore;
        }

        /// <summary>
        /// Returns health restoration value for game logic
        /// </summary>
        public override int Use()
        {
            return HealthRestore;
        }
    }

    /// <summary>
    /// Consumable item that restores monster stamina points
    /// </summary>
    public class StaminaItem : Item
    {
        /// <summary>
        /// Amount of stamina restored when consumed
        /// </summary>
        public int StaminaRestore { get; }

        public StaminaItem(string name, Image icon, int staminaRestore, int quantity = 0)
            : base(name, icon, quantity)
        {
            StaminaRestore = staminaRestore;
        }

        /// <summary>
        /// Returns stamina restoration value for game logic
        /// </summary>
        public override int Use()
        {
            return StaminaRestore;
        }
    }

    /// <summary>
    /// Premium item that restores both health and stamina
    /// More valuable than single-effect items but typically rarer
    /// </summary>
    public class FullRestoreItem : Item
    {
        public int HealthRestore { get; }
        public int StaminaRestore { get; }

        public FullRestoreItem(string name, Image icon, int healthRestore, int staminaRestore, int quantity = 0)
            : base(name, icon, quantity)
        {
            HealthRestore = healthRestore;
            StaminaRestore = staminaRestore;
        }

        /// <summary>
        /// Note: Only returns health value for compatibility with base Use() method
        /// Full restore logic is handled in GameState.UseItemAtIndex() via pattern matching
        /// </summary>
        public override int Use()
        {
            return HealthRestore;
        }
    }

    #endregion
}