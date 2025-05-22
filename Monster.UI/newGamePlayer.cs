using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monster.Core.Models;

namespace Monster.UI
{
    public partial class newGamePlayer : UserControl
    {
        // Temporary User object to hold user information during registration
        private User _tempUser = new User();

        // Constructor initializes the UserControl components
        public newGamePlayer()
        {
            InitializeComponent();
        }

        // Event handler for selecting the female user type
        // Sets the user type to "girl" and displays the user registration panel
        private void button_newGamePlayer_ChooseFemale_Click(object sender, EventArgs e)
        {
            _tempUser.UserType = "girl";
            panelNewUserRegister.Visible = true;
        }

        // Event handler for selecting the male user type
        // Sets the user type to "boy" and makes the registration panel visible
        private void button_newGamePlayer_ChooseMale_Click_1(object sender, EventArgs e)
        {
            _tempUser.UserType = "boy";
            panelNewUserRegister.Visible = true;
        }

        // Event handler for selecting the "other" user type option
        // Assigns "other" as the user type and reveals the registration panel
        private void button_newGamePlayer_ChooseOther_Click(object sender, EventArgs e)
        {
            _tempUser.UserType = "other";
            panelNewUserRegister.Visible = true;
        }

        // Handles the registration button click event
        // Passes the username and user type to the parent form to finalize setup,
        // saves the game, clears the input, and navigates to the new monster creation screen.
        private void button_newGamePlayer_RegisterText_Click(object sender, EventArgs e)
        {
            Form1 parentForm = this.FindForm() as Form1;

            if (parentForm != null)
            {
                parentForm.SetupUser(textBox_newGamePlayer_InputForUsername.Text, _tempUser.UserType);
                parentForm.SaveGame();
                textBox_newGamePlayer_InputForUsername.Text = "";
                parentForm.NavigateTo("NewMonster");
            }
            else
            {
                // Log a debug message if the parent form reference is missing
                System.Diagnostics.Debug.WriteLine("[DEBUG-myMonster] Parent form is null.");
            }
        }

        // Placeholder event handler for TextChanged on username input
        // Kept to prevent designer errors; no functional code here
        private void textBox_newGamePlayer_InputForUsername_TextChanged(object sender, EventArgs e)
        {
            // Designer breaks on removal
        }

        // Handles the Enter key press in the username input field
        // Triggers the registration process and suppresses the default key press behavior
        private void textBox_newGamePlayer_InputForUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_newGamePlayer_RegisterText_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
