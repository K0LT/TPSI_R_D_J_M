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
        private User _tempUser = new User();

        public newGamePlayer()
        {
            InitializeComponent();
        }

        private void button_newGamePlayer_ChooseFemale_Click(object sender, EventArgs e)
        {
            _tempUser.UserType = "girl";
            panelNewUserRegister.Visible = true;
        }

        private void button_newGamePlayer_ChooseMale_Click_1(object sender, EventArgs e)
        {
            _tempUser.UserType = "boy";
            panelNewUserRegister.Visible = true;

        }

        private void button_newGamePlayer_ChooseOther_Click(object sender, EventArgs e)
        {
            _tempUser.UserType = "jonnyBoy";
            panelNewUserRegister.Visible = true;
        }

        private void button_newGamePlayer_RegisterText_Click(object sender, EventArgs e)
        {
            Form1 parentForm = this.FindForm() as Form1;

            if (parentForm != null)
            {
                parentForm.SetupUser(textBox_newGamePlayer_InputForUsername.Text, _tempUser.UserType);
                parentForm.SaveGame();
                parentForm.NavigateTo("NewMonster");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG-myMonster] Parent form is null.");
            }

        }

        private void textBox_newGamePlayer_InputForUsername_TextChanged(object sender, EventArgs e)
        {
            // Designer breaks on removal
        }
    }
}
