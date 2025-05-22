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

        // Helper property to retrieve the main parent form (Form1)
        private Form1 ParentForm => this.FindForm() as Form1;

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
            ParentForm.SetSelectedBossType("red");
            ParentForm.NavigateTo("BattleGame");
        }

        /// <summary>
        /// Handles click on the skull boss image.
        /// Sets the selected boss to "skull" and navigates to the battle game screen.
        /// </summary>
        private void pictureBox_battleMenu_Skull_Click(object sender, EventArgs e)
        {
            ParentForm.SetSelectedBossType("skull");
            ParentForm.NavigateTo("BattleGame");
        }
    }
}
