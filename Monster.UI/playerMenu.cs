using Monster.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    public partial class playerMenu : UserControl
    {
        BindingSource _playerData = new BindingSource();


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object PlayerData
        {
            get => _playerData.DataSource;
            set => _playerData.DataSource = value;
        }

        public playerMenu()
        {
            InitializeComponent();
        }
        public void HookBindings()
        {
            //progressBar_myMonster_LVL.DataBindings.Clear(); 
            pictureBox1.DataBindings.Clear();
            //progressBar_myMonster_LVL.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource,
            // nameof(MonsterClass.HealthPoints));

            System.Diagnostics.Debug.WriteLine(@"HookBindings exiting.");
        }
    }
}
