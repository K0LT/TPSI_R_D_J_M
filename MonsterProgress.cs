using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Monster.Core
{
    public class MonsterProgress : INotifyPropertyChanged
    {
        private int _feedCount;
        public int FeedCount 
        {
            get => _feedCount;
            set
            {
                if (_feedCount == value) return;
                _feedCount = value;
                OnPropertyChanged();
            }
        }

        private int _correctGamesCount;
        public int CorrectGamesCount
        {
            get => _correctGamesCount;
            set
            {
                if (_correctGamesCount == value) return;
                _correctGamesCount = value;
                OnPropertyChanged();
            }
        }

        private int _level;
        public int Level
        {
            get => _level;
            set
            {
                if (_level == value) return;
                _level = value;
                OnPropertyChanged();
            }
        }
        private int _attack;
        public int Attack
        {
            get => _attack;
            set
            {
                if (_attack == value) return;
                _attack = value;
                OnPropertyChanged();
            }
        }
        private int _exp;
        public int Exp
        {
            get => _exp;
            set
            {
                if (_exp == value) return;
                _exp = value;
                OnPropertyChanged();
            }
        }

        private int _stamina;
        public int Stamina
        {
            get => _stamina;
            set
            {
                if (_stamina == value) return;
                _stamina = value;
                OnPropertyChanged();
            }
        }

        // Dicionário para armazenar os requisitos de cada nível
        private Dictionary<int, (int feedGoal, int correctGamesGoal, int attackThreshold)> levelRequirements = new Dictionary<int, (int feedGoal, int correctGamesGoal, int attackThreshold)>();

        public MonsterProgress()
        {
            FeedCount = 0;
            CorrectGamesCount = 0;
            Level = 0;
            Attack = 0;
            Exp = 0;
            Stamina = 0;
        }

        public int CalculateProgress()
        {
            int progress = 0;

            // calcula o progresso com base naquilo que foi feito, em percentagem
            if (FeedCount > 0)
            {
                progress += (FeedCount * 100 / 5);
            }
            if (CorrectGamesCount > 0)
            {
                progress += (CorrectGamesCount * 100 / 2);
            }
            if (Attack > 5)
            {
                progress += 100;
            }

            // limita o progresso a 100%
            if (progress > 100) progress = 100;

            return progress;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string PropertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }
}

