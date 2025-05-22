using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Monster.Core.Models
{
    /// <summary>
    /// Player profile containing user identity and avatar customization
    /// Minimal model focused on personalization rather than gameplay mechanics
    /// </summary>
    public class User : INotifyPropertyChanged
    {
        #region Private Fields

        private string _userType = "boy"; // Default avatar type
        private string _username = "";

        #endregion

        #region Public Properties

        /// <summary>
        /// Player's chosen display name - used for save files and UI personalization
        /// </summary>
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Avatar type selection (e.g., "boy", "girl") - affects player character appearance
        /// Defaults to "boy" for new users, customizable during character creation
        /// </summary>
        public string UserType
        {
            get => _userType;
            set
            {
                if (_userType != value)
                {
                    _userType = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Automatic property change notification for UI data binding
        /// Enables real-time updates when user customizes their profile
        /// </summary>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}