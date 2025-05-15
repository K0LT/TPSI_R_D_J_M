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
        private BindingSource _bsMonster = new BindingSource();


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsUser
        {
            get => _bsUser;
            set => _bsUser.DataSource = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsMonster
        {
            get => _bsMonster;
            set => _bsMonster.DataSource = value;
        }

        public newGameMonster()
        {
            InitializeComponent();
        }


        public void HookBindings()
        {
            textBox_newGameMonster_InputUsername.DataBindings.Clear();
            textBox_newGameMonster_InputUsername.DataBindings.Add(nameof(TextBox.Text), bsMonster, nameof(MonsterClass.Name), true, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void button_newGameMonster_Draco_Click(object sender, EventArgs e)
        {
            UpdateMonsterType("Draco");
            panelNewMonsterName.Visible = true;
        }

        private void button_newGameMonster_Grifo_Click(object sender, EventArgs e)
        {
            UpdateMonsterType("Grifo");
            panelNewMonsterName.Visible = true;

        }
        private void button_newGame_Monster_Tauro_Click(object sender, EventArgs e)
        {
            UpdateMonsterType("Tauro");
            panelNewMonsterName.Visible = true;
        }


        private void button_newGameMonster_Siren_Click(object sender, EventArgs e)
        {
            UpdateMonsterType("Siren");
            panelNewMonsterName.Visible = true;

        }

        private void UpdateMonsterType(string newType)
        {
            if (_bsMonster.DataSource is MonsterClass monster)
            {
                monster.Type = newType.ToLower();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Binding source is not set or is not a MonsterClass object.");
            }
        }

        private void label2_newGameMonster_Next_Click(object sender, EventArgs e)
        {
            Form1 parentForm = this.FindForm() as Form1;

            parentForm.NavigateTo("Monster");
        }

      
    }
}