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

        private Form1 ParentForm => this.FindForm() as Form1;


        private void button_mainMenu_NewGame_Click(object sender, EventArgs e)
        {
           
            ParentForm.NavigateTo("NewUser");
        }

        private void button_mainMenu_LoadGame_Click(object sender, EventArgs e)
        {

            ParentForm.NavigateTo("LoadGame");
        }

        private void button_mainMenu_Exit_Click(object sender, EventArgs e)
        {

            ParentForm.Close();
        }

        private void button_mainMenu_Settings_Click(object sender, EventArgs e)
        {

            ParentForm.NavigateTo("Settings");
        }

        private void button_mainMenu_Credits_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("Credits");
        }
        private void button_mainMenu_Credits_Click(object sender, EventArgs e)
        {

            var form = this.FindForm() as Form1;
            form.NavigateTo("Credits");
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }
    }


}
