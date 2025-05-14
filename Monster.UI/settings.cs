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
    public partial class settings : UserControl
    {
        public settings()
        {
            InitializeComponent();
        }

        private Form1 ParentForm => this.FindForm() as Form1;

        private void button_Settings_Exit_Click(object sender, EventArgs e)
        {

            ParentForm.NavigateTo("MainMenu");
        }
    }
}
