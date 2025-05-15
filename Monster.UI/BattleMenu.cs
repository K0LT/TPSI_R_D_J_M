using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void pictureBox_miniGames_Memory_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("BattleGame");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("BattleGame");
        }
    }
}
