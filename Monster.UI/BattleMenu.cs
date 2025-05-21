using System;
using System.Windows.Forms;

namespace Monster.UI
{
    public partial class BattleMenu : UserControl
    {
        public BattleMenu()
        {
            InitializeComponent();
        }

        private Form1 ParentForm => this.FindForm() as Form1;

        private void button_Battle_Exit_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("Monster");
        }

        private void pictureBox_battleMenu_Red_Click(object sender, EventArgs e)
        {

            ParentForm.NavigateTo("BattleGame");
        }

        private void pictureBox_battleMenu_Skull_Click(object sender, EventArgs e)
        {

            ParentForm.NavigateTo("BattleGame");
        }
    }
}
