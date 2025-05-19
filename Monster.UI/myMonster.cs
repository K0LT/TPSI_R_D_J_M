using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
                nameof(MonsterClass.Stamina));

            pictureBox_myMonster.DataBindings.Add(nameof(PictureBox.Image), bsDataSource, nameof(MonsterClass.MonsterImage), true, DataSourceUpdateMode.OnPropertyChanged);

            levelMyMonster.DataBindings.Add(nameof(Label.Text), bsDataSource, nameof(MonsterClass.Level));
            nameMyMonsterLabel.DataBindings.Add(nameof(Label.Text), bsDataSource, nameof(MonsterClass.Name));
            System.Diagnostics.Debug.WriteLine(@"HookBindings exiting.");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            if(bsDataSource is MonsterClass monster)
            {
                if(monster.Stamina < 25)
                {
                    MessageBox.Show("Not enough stamina!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else ParentForm.NavigateTo("MiniGames");
            }
        }


        private void button_myMonster_Battle_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("BattleMenu");
        }

        private void button_myMonster_Food_Click(object sender, EventArgs e)
        {
            ParentForm.AddExperience(50);
        }

        private void button_myMonster_Sleep_Click(object sender, EventArgs e)
        {
            if (!(_bsMonster.DataSource is MonsterClass monster))
            {
                MessageBox.Show("Monster data not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form countdownForm = new Form()
            {
                Width = 320,
                Height = 140,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                Text = "Sleeping...",
                ControlBox = false,
                MinimizeBox = false,
                MaximizeBox = false,
                BackColor = System.Drawing.Color.Black 
            };

            Label labelCountdown = new Label()
            {
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Font = new System.Drawing.Font("VCR OSD Mono", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
                ForeColor = System.Drawing.Color.Goldenrod,
                BackColor = System.Drawing.Color.Black,
                Text = "15 seconds remaining..."
            };


            countdownForm.Controls.Add(labelCountdown);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            int countdown = 15;
            int missingHealth = 100 - monster.HealthPoints;

            timer.Interval = 1000;
            timer.Tick += (s, args) =>
            {
                countdown--;
                if (countdown > 0)
                {
                    labelCountdown.Text = $"{countdown} seconds remaining...";
                    monster.HealthPoints += missingHealth / 15;
                }
                else
                {
                    timer.Stop();


                    if (monster.HealthPoints < 100) monster.HealthPoints = 100;
                    if (monster.Stamina < 100) monster.Stamina = 100;


                    _bsMonster.ResetBindings(false);

                    countdownForm.Close();
                }
            };

            timer.Start();
            countdownForm.ShowDialog();
        }



    }
}

