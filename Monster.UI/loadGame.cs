using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monster.Game.GameState;
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

            string temp = textBox_LoadGame_InputForUsername.Text;

            
            flag = ParentForm.LoadGame(temp);
            if (flag)
            {
                ParentForm.NavigateTo("Monster");
            }
            else
            {
                ParentForm.NavigateTo("MainMenu");
            }
        }
        
        private void button_LoadGame_Exit_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;

            ParentForm.NavigateTo("MainMenu");
        }
    }
}
