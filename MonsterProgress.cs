using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Monster.Core
{
    public class MonsterProgress : INotifyPropertyChanged
    {
        private int _attack;

        private int _correctGamesCount;
        private int _exp;
        private int _feedCount;

        private int _level;

        private int _stamina;

        // Dicionário para armazenar os requisitos de cada nível
        private Dictionary<int, (int feedGoal, int correctGamesGoal, int attackThreshold)> levelRequirements =
            new Dictionary<int, (int feedGoal, int correctGamesGoal, int attackThreshold)>();

        public MonsterProgress()
        {
            FeedCount = 0;
            CorrectGamesCount = 0;
            Level = 0;
            Attack = 0;
            Exp = 0;
            Stamina = 0;
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        public int CalculateProgress()
        {
            var progress = 0;

            // calcula o progresso com base naquilo que foi feito, em percentagem
            if (FeedCount > 0) progress += FeedCount * 100 / 5;
            if (CorrectGamesCount > 0) progress += CorrectGamesCount * 100 / 2;
            if (Attack > 5) progress += 100;

            // limita o progresso a 100%
            if (progress > 100) progress = 100;

            return progress;
        }

        private void OnPropertyChanged([CallerMemberName] string PropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}