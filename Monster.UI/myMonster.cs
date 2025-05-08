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
    public partial class myMonster : UserControl
    {
        private BindingSource _bsMonster = new BindingSource();

        public object bsDataSource
        {
            get => _bsMonster.DataSource;
            set => _bsMonster.DataSource = value;
        }
        public myMonster()
        {
            InitializeComponent();
            HookBindings(_bsMonster);
        }

        private void HookBindings(BindingSource bsMonster)
        {
            label_myMonster_CurrentMonsterName.DataBindings.Add(nameof(Label.Text), bsMonster, nameof(MonsterClass.Name));
        }
        private void progressBar_myMonster_EXP_Click(object sender, EventArgs e)
        {

        }
    }
}
