using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monster.Core.Models;

namespace Monster.UI
{
    public partial class newGameMonster : UserControl
    {
        private BindingSource _bsUser = new BindingSource();


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsUser
        {
            get => _bsUser;
            set => _bsUser.DataSource = value;
        }

        public newGameMonster()
        {
            InitializeComponent();
        }

        private void button_newGameMonster_Save_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void HookBindings()
        {
            labelUserName.DataBindings.Add(nameof(Label.Text), bsUser, nameof(User.Username));
        }
    }
}
