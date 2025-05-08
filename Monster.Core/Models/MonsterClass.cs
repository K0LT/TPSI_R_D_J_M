using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Monster.Core.Models
{
    public class Monster : INotifyPropertyChanged
    {
        // TODO: ADD DATE_TIME IMPLEMENTATION

        private string _name = "defaultMonsterName";
        private string _type = "defaultMonsterType";
        private int _experiencePoints;
        private int _level;
        private int _energy;
        
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

        // TODO: Add rest of properties

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}