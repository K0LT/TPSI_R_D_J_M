namespace Monster.UI
{
    /// <summary>
    /// Represents the Credits screen UI component.
    /// Provides navigation back to the main menu.
    /// </summary>
    public partial class credits : UserControl
    {
        // Constructor - initializes the credits UI components
        public credits()
        {
            InitializeComponent();
        }

        // Helper property to access the main parent form (Form1)
        private Form1 ParentForm => this.FindForm() as Form1;

        /// <summary>
        /// Handles the exit button click event.
        /// Navigates the user back to the main menu.
        /// </summary>
        private void button_MiniGames_Exit_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("MainMenu");
        }
    }
}
