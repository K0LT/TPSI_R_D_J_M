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

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = textBox_LoadGame_InputForUsername.Text;
            Form1 form = this.FindForm() as Form1;

            form.LoadGame(temp);
            form.NavigateTo("Monster");
        }


    }
}
