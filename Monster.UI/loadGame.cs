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

namespace Monster.UI
{
    public partial class loadGame : UserControl
    {
        public loadGame()
        {
            InitializeComponent();
        }
        private Form1 ParentForm => this.FindForm() as Form1;
        
        private void button1_Click(object sender, EventArgs e)
        {
            string temp = textBox_LoadGame_InputForUsername.Text;
           

            ParentForm.LoadGame(temp);
            ParentForm.NavigateTo("Monster");
        }
        
        private void button_LoadGame_Exit_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("MainMenu");
        }
    }
}
