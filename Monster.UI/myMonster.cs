using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Monster.Core.Models;

namespace Monster.UI
{
    /// <summary>
    /// UserControl representing the player's current monster.
    /// Handles UI bindings, interactions, and navigation related to the monster.
    /// </summary>
    public partial class myMonster : UserControl
    {
        // BindingSource to manage data binding with the MonsterClass instance.
        private BindingSource _bsMonster;

        // Reference to the parent form hosting this control, cast to Form1.
        private Form1 ParentForm => this.FindForm() as Form1;

        /// <summary>
        /// Exposes the data source for binding, linked to the internal BindingSource.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public object bsDataSource
        {
            get => _bsMonster.DataSource;
            set => _bsMonster.DataSource = value;
        }

        /// <summary>
        /// Initializes a new instance of the myMonster UserControl.
        /// Sets up the BindingSource and initializes components.
        /// </summary>
        public myMonster()
        {
            System.Diagnostics.Debug.WriteLine(@"myMonster Constructor call.");
            _bsMonster = new BindingSource();
            System.Diagnostics.Debug.WriteLine(@"Created raw binding source.");
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine(@"myMonster InitializeComponent() called.");
        }

        /// <summary>
        /// Configures data bindings between UI controls and the MonsterClass properties.
        /// Should be called after setting bsDataSource.
        /// </summary>
        public void HookBindings()
        {
            // Clear existing bindings before setting new ones
            progressBar_myMonster_EXP.DataBindings.Clear();
            progressBar_myMonster_HP.DataBindings.Clear();
            progressBar_myMonster_ST.DataBindings.Clear();
            pictureBox_myMonster.DataBindings.Clear();
            levelMyMonster.DataBindings.Clear();
            nameMyMonsterLabel.DataBindings.Clear();

            // Bind progress bars to corresponding MonsterClass properties
            progressBar_myMonster_EXP.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource, nameof(MonsterClass.ExperiencePoints));
            progressBar_myMonster_HP.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource, nameof(MonsterClass.HealthPoints));
            progressBar_myMonster_ST.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource, nameof(MonsterClass.Stamina));

            // Bind monster image to PictureBox
            pictureBox_myMonster.DataBindings.Add(nameof(PictureBox.Image), bsDataSource, nameof(MonsterClass.MonsterImage), true, DataSourceUpdateMode.OnPropertyChanged);

            // Bind labels to display monster's level and name
            levelMyMonster.DataBindings.Add(nameof(Label.Text), bsDataSource, nameof(MonsterClass.Level));
            nameMyMonsterLabel.DataBindings.Add(nameof(Label.Text), bsDataSource, nameof(MonsterClass.Name));

            System.Diagnostics.Debug.WriteLine(@"HookBindings exiting.");
        }

        /// <summary>
        /// Event for notifying property changes, supporting data binding.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event for the specified property.
        /// </summary>
        /// <param name="propertyName">Name of the property that changed.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Navigates back to the Main Menu screen.
        /// </summary>
        private void button_myMonster_ReturnToMainMenu_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
                ParentForm.NavigateTo("MainMenu");
            else
                System.Diagnostics.Debug.WriteLine("[DEBUG-myMonster] Parent form is null.");
        }

        /// <summary>
        /// Navigates to the Player information screen.
        /// </summary>
        private void button_myMonster_Player_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
                ParentForm.NavigateTo("Player");
            else
                System.Diagnostics.Debug.WriteLine("[DEBUG-myMonster] Parent form is null.");
        }

        /// <summary>
        /// Navigates to the Inventory screen.
        /// </summary>
        private void button_myMonster_Inventory_Click(object sender, EventArgs e)
        {
            if (ParentForm != null)
                ParentForm.NavigateTo("Inventory");
            else
                System.Diagnostics.Debug.WriteLine("[DEBUG-myMonster] Parent form is null.");
        }

        /// <summary>
        /// Saves the current game state via the parent form.
        /// </summary>
        private void button_myMonster_Save_Click(object sender, EventArgs e)
        {
            ParentForm?.SaveGame();
        }

        /// <summary>
        /// Attempts to navigate to the MiniGames screen if conditions are met.
        /// Requires inventory to be visited and monster stamina to be sufficient.
        /// </summary>
        private void button_myMonster_MiniGames_Click(object sender, EventArgs e)
        {
            if (ParentForm.GetInventoryVisited())
            {
                if (bsDataSource is MonsterClass monster)
                {
                    if (monster.Stamina < 25)
                    {
                        MessageBox.Show("Not enough stamina!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ParentForm.NavigateTo("MiniGames");
                }
            }
            else
            {
                MessageBox.Show("Please visit your inventory first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Attempts to navigate to the BattleMenu screen if conditions are met.
        /// Requires inventory to be visited and monster to have health points > 0.
        /// </summary>
        private void button_myMonster_Battle_Click(object sender, EventArgs e)
        {
            if (ParentForm.GetInventoryVisited())
            {
                if (bsDataSource is MonsterClass monster)
                {
                    if (monster.HealthPoints == 0)
                    {
                        MessageBox.Show("You don't have enough HP!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                ParentForm.NavigateTo("BattleMenu");
            }
            else
            {
                MessageBox.Show("Please visit your inventory first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Allows adding a new monster if player owns fewer than 4 monsters
        /// and all owned monsters are at least level 10.
        /// </summary>
        private void button_myMonster_AddMonsters_Click(object sender, EventArgs e)
        {
            if (bsDataSource is MonsterClass monster)
            {
                List<MonsterClass> ownedMonsters = ParentForm.GetOwnedMonsters();

                // Enforce maximum limit of 4 monsters
                if (ownedMonsters.Count >= 4)
                {
                    MessageBox.Show("You already have 4 Monsters!", "Maximum Monsters Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if all monsters meet level requirement
                bool allMonstersMaxed = ownedMonsters.All(m => m.Level >= 10);

                if (allMonstersMaxed)
                {
                    ParentForm.NavigateTo("NewMonster");
                }
                else
                {
                    MessageBox.Show("All your current monsters must be at least level 10 before you can create a new one.",
                        "Level Requirement Not Met", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Implements a "sleep" mechanic that gradually restores health and stamina over 15 seconds,
        /// showing a countdown dialog during the process.
        /// </summary>
        private void button_myMonster_Sleep_Click(object sender, EventArgs e)
        {
            if (!(_bsMonster.DataSource is MonsterClass monster))
            {
                MessageBox.Show("Monster data not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a modal dialog showing the sleep countdown
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
                BackColor = Color.Black
            };

            Label labelCountdown = new Label()
            {
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("VCR OSD Mono", 16F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.Goldenrod,
                BackColor = Color.Black,
                Text = "15 seconds remaining..."
            };

            countdownForm.Controls.Add(labelCountdown);

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            int countdown = 15;
            int missingHealth = 100 - monster.HealthPoints;
            int missingStamina = 100 - monster.Stamina;

            // Timer tick updates the countdown and restores health/stamina incrementally
            timer.Interval = 1000;
            timer.Tick += (s, args) =>
            {
                countdown--;
                if (countdown > 0)
                {
                    labelCountdown.Text = $"{countdown} seconds remaining...";
                    monster.HealthPoints += missingHealth / 15;
                    monster.Stamina += missingStamina / 15;
                }
                else
                {
                    timer.Stop();

                    // Ensure health and stamina are fully restored at the end
                    if (monster.HealthPoints < 100) monster.HealthPoints = 100;
                    if (monster.Stamina < 100) monster.Stamina = 100;

                    // Refresh bindings to update UI
                    _bsMonster.ResetBindings(false);

                    countdownForm.Close();
                }
            };

            timer.Start();
            countdownForm.ShowDialog();
        }
    }
}
