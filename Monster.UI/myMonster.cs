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
using Monster.Core.Models;

namespace Monster.UI
{
    public partial class myMonster : UserControl
    {
        private BindingSource _bsMonster;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsDataSource
        {
            get => _bsMonster.DataSource;
            set => _bsMonster.DataSource = value;
        }
        public myMonster()
        {
            System.Diagnostics.Debug.WriteLine(@"myMonster Constructor call.");
            _bsMonster = new BindingSource();
            System.Diagnostics.Debug.WriteLine(@"Created raw binding source.");
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine(@"myMonster InitializeComponent() called.");
        }

        public void HookBindings()
        {
            progressBar_myMonster_EXP.DataBindings.Clear();
            progressBar_myMonster_HP.DataBindings.Clear();
            progressBar_myMonster_LVL.DataBindings.Clear();
            progressBar_myMonster_ST.DataBindings.Clear();
            
            
            label_myMonster_CurrentMonsterName.DataBindings.Clear();
            
            
            progressBar_myMonster_EXP.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource,
                nameof(MonsterClass.ExperiencePoints));
            progressBar_myMonster_HP.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource,
                nameof(MonsterClass.HealthPoints));
            progressBar_myMonster_LVL.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource,
                nameof(MonsterClass.HealthPoints));
            progressBar_myMonster_ST.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource,
                nameof(MonsterClass.HealthPoints));
            label_myMonster_CurrentMonsterName.DataBindings.Add(nameof(Label.Text), bsDataSource,
                nameof(MonsterClass.Name));
            System.Diagnostics.Debug.WriteLine(@"HookBindings exiting.");
        }
        
        private void progressBar_myMonster_EXP_Click(object sender, EventArgs e)
        {

        }
    }
}
