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
    public partial class miniGamesMenu : UserControl
    {
        public miniGamesMenu()
        {
            InitializeComponent();


            pictureBox_miniGames_Memory.Click += pictureBox_miniGames_Memory_Click;
            pictureBox_miniGames_ticTac.Click += pictureBox_miniGames_ticTac_Click;

           
            pictureBox_miniGames_Memory.Cursor = Cursors.Hand;
            pictureBox_miniGames_ticTac.Cursor = Cursors.Hand;

        }

        private Form1 ParentForm => this.FindForm() as Form1;

        private void pictureBox_miniGames_Memory_Click(object sender, EventArgs e)
        {
            
            ParentForm.NavigateTo("MemoryGame");
        }

        private void pictureBox_miniGames_ticTac_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("TicTacToe");
        }

        private void button_MiniGames_Exit_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("Monster");
        }

        
    }
}
