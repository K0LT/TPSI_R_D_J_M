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
    public partial class mainMenu : UserControl
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void button_mainMenu_NewGame_Click(object sender, EventArgs e)
        {
            Form1 form = this.FindForm() as Form1;

            form.NavigateTo("NewUser");
        }

        private void button_mainMenu_LoadGame_Click(object sender, EventArgs e)
        {
            Form1 form = this.FindForm() as Form1;

            //form.NavigateTo("LoadGame");
        }

        private void button_mainMenu_Exit_Click(object sender, EventArgs e)
        {
            Form1 form = this.FindForm() as Form1;

            form.Close();
        }
    }
}
