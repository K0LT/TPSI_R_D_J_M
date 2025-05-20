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
        private Form1 ParentForm => this.FindForm() as Form1;

        public MonsterClass? newMonster = new MonsterClass();

        public newGameMonster()
        {
            InitializeComponent();
        }

        private void button_newGameMonster_Draco_Click(object sender, EventArgs e)
        {
            newMonster.Type = "draco";
            panelNewMonsterName.Visible = true;
        }

        private void button_newGameMonster_Grifo_Click(object sender, EventArgs e)
        {
            newMonster.Type = "grifo";
            panelNewMonsterName.Visible = true;

        }
        private void button_newGame_Monster_Tauro_Click(object sender, EventArgs e)
        {
            newMonster.Type = "tauro"; ;
            panelNewMonsterName.Visible = true;
        }


        private void button_newGameMonster_Siren_Click(object sender, EventArgs e)
        {
            newMonster.Type = "siren";
            panelNewMonsterName.Visible = true;

        }

        private void label2_newGameMonster_Next_Click(object sender, EventArgs e)
        {
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