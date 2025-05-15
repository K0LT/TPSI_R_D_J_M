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
    public partial class inventory : UserControl
    {
        public inventory()
        {
            InitializeComponent();
        }

        private void button_inventory_ReturnToMyMonster_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;

            ParentForm.NavigateTo("Monster");
        }
    }
}
