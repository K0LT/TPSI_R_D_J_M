namespace Monster.UI
{
    public partial class loadGame : UserControl
    {
        public loadGame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag;
            Form1 ParentForm = this.FindForm() as Form1;

            // Retrieve the username input from the textbox.
            string temp = textBox_LoadGame_InputForUsername.Text;

            // Consider adding a check to prevent empty username input.
            // if (string.IsNullOrWhiteSpace(temp)) {
            //     MessageBox.Show("Please enter a username.");
            //     return;
            // }

            // Attempt to load the game with the given username.
            flag = ParentForm.LoadGame(temp);

            // Navigate based on load success.
            if (flag)
            {
                ParentForm.NavigateTo("Monster");
            }
            else
            {
                ParentForm.NavigateTo("MainMenu");
            }
        }

        // Handles returning to the Main Menu.
        private void button_LoadGame_Exit_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;

            // Consider checking for null before use:
            // if (ParentForm != null) { ... }
            ParentForm.NavigateTo("MainMenu");
        }
    }
}
