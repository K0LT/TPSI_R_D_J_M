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
        /// 
        public event EventHandler MonsterSlept;

        private void button_myMonster_Sleep_Click(object sender, EventArgs e)
        {
            if(!(_bsMonster.DataSource is MonsterClass monster))
    {
                MessageBox.Show("Monster data not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var sleepForm = new countdownForm(monster))
            {
                if (sleepForm.ShowDialog() == DialogResult.OK)
                {
                    _bsMonster.ResetBindings(true);

                    MonsterSlept?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
