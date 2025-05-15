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


        private Form1 ParentForm => this.FindForm() as Form1;
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
            progressBar_myMonster_ST.DataBindings.Clear();

            pictureBox_myMonster.DataBindings.Clear();

            levelMyMonster.DataBindings.Clear();
            nameMyMonsterLabel.DataBindings.Clear();

            progressBar_myMonster_EXP.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource,
                nameof(MonsterClass.ExperiencePoints));
            progressBar_myMonster_HP.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource,
                nameof(MonsterClass.HealthPoints));
            progressBar_myMonster_ST.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource,
                nameof(MonsterClass.HealthPoints));

            pictureBox_myMonster.DataBindings.Add(nameof(PictureBox.Image), bsDataSource, nameof(MonsterClass.MonsterImage), true, DataSourceUpdateMode.OnPropertyChanged);

            levelMyMonster.DataBindings.Add(nameof(Label.Text), bsDataSource, nameof(MonsterClass.Level));
            nameMyMonsterLabel.DataBindings.Add(nameof(Label.Text), bsDataSource, nameof(MonsterClass.Name));
            //Eliminei o label a dizer CurrentMonster mas deverei voltar a adicionar
            //label_myMonster_CurrentMonsterName.DataBindings.Add(nameof(Label.Text), bsDataSource,
            //nameof(MonsterClass.Name));
            System.Diagnostics.Debug.WriteLine(@"HookBindings exiting.");
        }

        

       

        private void button_myMonster_ReturnToMainMenu_Click(object sender, EventArgs e)
        {
            
            if (ParentForm != null)
            {
                ParentForm.NavigateTo("MainMenu");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG-myMonster] Parent form is null.");
            }
        }

        private void button_myMonster_Player_Click(object sender, EventArgs e)
        {

            if (ParentForm != null)
            {
                ParentForm.NavigateTo("Player");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG-myMonster] Parent form is null.");
            }
        }

        private void button_myMonster_Inventory_Click(object sender, EventArgs e)
        {

            if (ParentForm != null)
            {
                ParentForm.NavigateTo("Inventory");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("[DEBUG-myMonster] Parent form is null.");
            }
        }

        private void button_myMonster_Save_Click(object sender, EventArgs e)
        {

            ParentForm.SaveGame();
        }

        private void button_myMonster_MiniGames_Click(object sender, EventArgs e)
        {

            ParentForm.NavigateTo("MiniGames");

        }

       
        private void button_myMonster_Battle_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("BattleMenu");
        }

        private void button_myMonster_Food_Click(object sender, EventArgs e)
        {
            ParentForm.AddExperience(50);
        }

     
    }
}
