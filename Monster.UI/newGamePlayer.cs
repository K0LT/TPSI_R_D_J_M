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
    public partial class newGamePlayer : UserControl
    {
        private BindingSource _bsUserName = new BindingSource();
        private User _tempUser = new User();

        // TODO: Implement newGameMonster binding pattern, this is outdated

        public newGamePlayer()
        {
            InitializeComponent();
            HookBindings();
        }

        private void HookBindings()
        {
            _bsUserName.DataSource = _tempUser;

            textBox_newGamePlayer_InputForUsername.DataBindings.Add(
                nameof(TextBox.Text), _bsUserName, nameof(User.Username), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void button_newGamePlayer_ChooseFemale_Click(object sender, EventArgs e)
        {
            _tempUser.UserType = "girl";
        }

        private void button_newGamePlayer_ChooseMale_Click(object sender, EventArgs e)
        {
            _tempUser.UserType = "boy";
        }

        private void button_newGamePlayer_RegisterText_Click(object sender, EventArgs e)
        {
            Form1 parentForm = this.FindForm() as Form1;

            if (parentForm != null)
            {
                parentForm.SetupUser(_tempUser.Username, _tempUser.UserType);
                parentForm.SaveGame();
                parentForm.NavigateTo("NewMonster");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG-myMonster] Parent form is null.");
            }
        }
    }
}
