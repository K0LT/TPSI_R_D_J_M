namespace Monster.UI
{
    /// <summary>
    /// Represents the mini-games menu UserControl.
    /// Allows navigation to different mini-games and returning to the main game screen.
    /// </summary>
    public partial class miniGamesMenu : UserControl
    {
        /// <summary>
        /// Gets a reference to the parent Form1 that hosts this control.
        /// </summary>
        private Form1 ParentForm => this.FindForm() as Form1;

        /// <summary>
        /// Initializes the mini-games menu control, sets up event handlers and cursor styles.
        /// </summary>
        public miniGamesMenu()
        {
            InitializeComponent();

            // Attach click event handlers for mini-game picture boxes
            pictureBox_miniGames_Memory.Click += pictureBox_miniGames_Memory_Click;
            pictureBox_miniGames_ticTac.Click += pictureBox_miniGames_Pattern_Click;

            // Set cursor to hand icon to indicate clickable elements
            pictureBox_miniGames_Memory.Cursor = Cursors.Hand;
            pictureBox_miniGames_ticTac.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Handles the click event on the Memory Game picture box.
        /// Navigates to the MemoryGame screen.
        /// </summary>
        private void pictureBox_miniGames_Memory_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("MemoryGame");
        }

        /// <summary>
        /// Handles the click event on the Tic Tac Toe / Pattern Game picture box.
        /// Navigates to the PatternGame screen.
        /// </summary>
        private void pictureBox_miniGames_Pattern_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("PatternGame");
        }

        /// <summary>
        /// Handles the exit button click event.
        /// Returns to the main Monster game screen.
        /// </summary>
        private void button_MiniGames_Exit_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("Monster");
        }
    }
}
