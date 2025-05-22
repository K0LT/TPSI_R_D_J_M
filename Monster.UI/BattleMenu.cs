using Monster.Core.Models;
using System.Data.Common;

namespace Monster.UI
{
    /// <summary>
    /// Represents the battle menu screen where the player selects a boss to fight.
    /// Provides navigation to the battle game screen and back to the monster screen.
    /// </summary>
    public partial class BattleMenu : UserControl
    {
        // Constructor - initializes the UI components for the battle menu
        public BattleMenu()
        {
            InitializeComponent();
        }
        private BindingSource _bsMonster = new BindingSource();

        // Accessor to get the parent form safely cast
        private Form1 ParentForm => this.FindForm() as Form1;

        // Shortcut to access the currently selected monster
        public MonsterClass Monster => _bsMonster.Current as MonsterClass;

        // External access to bind a list to the internal binding source
        public object bsMonster
        {
            get => _bsMonster.DataSource;
            set => _bsMonster.DataSource = value;
        }
        public object bsDataSource
        {
            get => _bsMonster.DataSource;
            set => _bsMonster.DataSource = value;
        }


        /// <summary>
        /// Handles the "Exit" button click to return to the monster overview screen
        /// </summary>
        private void button_Battle_Exit_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("Monster");
        }

        /// <summary>
        /// Handles click on the red boss image.
        /// Sets the selected boss to "red" and navigates to the battle game screen.
        /// </summary>
        private void pictureBox_battleMenu_Red_Click(object sender, EventArgs e)
        {
            if (bsDataSource is MonsterClass monster)
            {
                if (monster.Stamina < 20)
                {
                    MessageBox.Show("You don't have enough Stamina!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            ParentForm.SetSelectedBossType("red");
            ParentForm.NavigateTo("BattleGame");

        }

        /// <summary>
        /// Handles click on the skull boss image.
        /// Sets the selected boss to "skull" and navigates to the battle game screen.
        /// </summary>
        private void pictureBox_battleMenu_Skull_Click(object sender, EventArgs e)
        {
            if (bsDataSource is MonsterClass monster)
            {
                if (monster.Stamina < 30)
                {
                    MessageBox.Show("You don't have enough Stamina!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            ParentForm.SetSelectedBossType("skull");
            ParentForm.NavigateTo("BattleGame");
        }
    }
}
