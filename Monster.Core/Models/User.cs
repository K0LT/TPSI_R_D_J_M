using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.Core.Models
{
    public class User : INotifyPropertyChanged
    {
        private string _userType = "defaultUserType";
        private string _username = "defaultUserName";

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string UserType
        {
            get => _userType;
            set
            {
                if (_userType != value)
                {
                    _userType = value;
                    OnPropertyChanged(nameof(UserType));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
