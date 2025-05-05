using System;
using System.Windows.Forms;

namespace Monster.Core
{
    public static class MonsterBarProgressManager
    {
        public static void InitializeMonsterProgressBar(ProgressBar progressBar)
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
        }

        public static void UpdateMonsterProgressBar(ProgressBar progressBar, MonsterProgress monster)
        {
            if (monster == null || progressBar == null) return;

            progressBar.Minimum = 0;
            progressBar.Maximum = 5;
            progressBar.Value = Math.Min(monster.Level, progressBar.Maximum);
        }
    }
}