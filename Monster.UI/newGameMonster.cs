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
    public partial class newGameMonster : UserControl
    {
        // Gets the parent Form1 instance hosting this control, enabling interaction with main form methods.
        private Form1 ParentForm => this.FindForm() as Form1;

        // Holds the new MonsterClass instance currently being created. Nullable to indicate no selection yet.
        public MonsterClass? newMonster;

        // Constructor initializes the UserControl and its components.
        public newGameMonster()
        {
            InitializeComponent();
        }

        // Event handler for selecting the "Draco" monster type.
        // Initializes a new MonsterClass with type "draco" and shows the naming panel.
        private void button_newGameMonster_Draco_Click(object sender, EventArgs e)
        {
            newMonster = new MonsterClass();
            newMonster.Type = "draco";
            panelNewMonsterName.Visible = true;
        }

        // Event handler for selecting the "Grifo" monster type.
        // Creates a new MonsterClass with type "grifo" and displays the naming panel.
        private void button_newGameMonster_Grifo_Click(object sender, EventArgs e)
        {
            newMonster = new MonsterClass();
            newMonster.Type = "grifo";
            panelNewMonsterName.Visible = true;
        }

        // Event handler for selecting the "Tauro" monster type.
        // Creates a new MonsterClass with type "tauro" and reveals the naming UI.
        private void button_newGame_Monster_Tauro_Click(object sender, EventArgs e)
        {
            newMonster = new MonsterClass();
            newMonster.Type = "tauro";
            panelNewMonsterName.Visible = true;
        }

        // Event handler for selecting the "Siren" monster type.
        // Initializes a new MonsterClass with type "siren" and makes the name input visible.
        private void button_newGameMonster_Siren_Click(object sender, EventArgs e)
        {
            newMonster = new MonsterClass();
            newMonster.Type = "siren";
            panelNewMonsterName.Visible = true;
        }

        // Event handler for the "Next" label click.
        // Assigns the entered name to the newMonster, clears the input box,
        // adds the monster to the main form, and prompts the user to skip the tutorial.
        // Navigates based on the user's choice to either the main monster screen or tutorial.
        private void label2_newGameMonster_Next_Click(object sender, EventArgs e)
        {
            if (textBox_newGameMonster_InputUsername.Text == "")
            {
                MessageBox.Show("The monster name must not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox_newGameMonster_InputUsername.Text.Count() > 8)
            {
                MessageBox.Show("The name must not exceed six(6) characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            newMonster.Name = textBox_newGameMonster_InputUsername.Text;
            textBox_newGameMonster_InputUsername.Clear();
            ParentForm.AddMonster(newMonster);

            DialogResult result = MessageBox.Show(
                "Do you want to skip the tutorial?",
                "Skip Tutorial",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ParentForm.NavigateTo("Monster");
            }
            else
            {
                ParentForm.NavigateTo("Tutorial1");
            }
        }

        // Handles the Enter key press in the username textbox to trigger the "Next" action,
        // improving user experience with keyboard navigation.
        private void textBox_newGameMonster_InputUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                label2_newGameMonster_Next_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
