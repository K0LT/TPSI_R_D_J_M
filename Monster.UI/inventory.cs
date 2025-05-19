using Monster.Core.Models;
using Monster.Game.GameState;
using Monster.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    public partial class inventory : UserControl
    {
        private bool firstHook = false;

        private BindingSource _bsMonster = new BindingSource();

        private BindingSource _state = new BindingSource();

        public object State
        {
            get => _state.DataSource;
            set => _state.DataSource = value;
        }
        private BindingSource _bsInventory = new BindingSource();
        public object bsInventory
        {
            get => _bsInventory.DataSource;
            set => _bsInventory.DataSource = value;
        }

        private Form1 ParentForm => this.FindForm() as Form1;
        public object bsDataSource
        {
            get => _bsMonster.DataSource;
            set => _bsMonster.DataSource = value;
        }

        public inventory()
        {
            InitializeComponent();
        }

        public void HookBindings()
        {
            if (!firstHook)
            {
                pictureBox_inventory_CurrentMonster.DataBindings.Add(nameof(PictureBox.Image), bsDataSource, nameof(MonsterClass.MonsterImage));
                progressBar_inventory_HP.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource, nameof(MonsterClass.HealthPoints));
                progressBar_inventory_Stamina.DataBindings.Add(nameof(ProgressBar.Value), bsDataSource, nameof(MonsterClass.Stamina));

                firstHook = true;
            }
            UpdateInventory();
            return;
        }

        public List<Item> InitializeInventory()
        {

            var waterIcon = pictureBox_inventory_waterIcon.Image;
            var sodaIcon = pictureBox_inventory_SodaIcon.Image;
            var beerIcon = pictureBox_inventory_BeerIcon.Image;
            var energyDrinkIcon = pictureBox_inventory_MonsterIcon.Image;
            var nachosIcon = pictureBox_inventory_NachosIcon.Image;
            var burguerIcon = pictureBox_inventory_BurguerIcon.Image;
            var ramenIcon = pictureBox_inventory_Ramen.Image;

            var inventory = new List<Item>
            {
            new StaminaItem("Water", waterIcon, 10, 3),
            new ExperienceItem("Soda", sodaIcon, 10, 2),
            new ExperienceItem("Beer", beerIcon, 20, 2),
            new StaminaItem("Energy Drink", energyDrinkIcon, 20, 2),
            new HealthItem("Nachos", nachosIcon, 10, 2),
            new HealthItem("Burguer", burguerIcon, 20, 2),
            new FullRestoreItem("Ramen", ramenIcon, 20, 20, 20, 2)
            };
            return inventory;
        }

        private void UpdateInventory()
        {
            if (bsInventory is List<Item> list && list.Count >= 7)
            {
                label_inventory_water.Text = list[0].Quantity.ToString();
                label_inventory_Soda.Text = list[1].Quantity.ToString();
                label_inventory_Beer.Text = list[2].Quantity.ToString();
                label_inventory_Monster.Text = list[3].Quantity.ToString();
                label_inventory_Nachos.Text = list[4].Quantity.ToString();
                label_inventory_Burguer.Text = list[5].Quantity.ToString();
                label_inventory_Ramen.Text = list[6].Quantity.ToString();
            }
        }

        private void button_inventory_ReturnToMyMonster_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;

            ParentForm.NavigateTo("Monster");
        }

        private void pictureBox_inventory_waterIcon_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(0);
                UpdateInventory();
            }
        }

        private void pictureBox_inventory_SodaIcon_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(1);
                UpdateInventory();
            }
        }

        private void pictureBox_inventory_BeerIcon_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(2);
                UpdateInventory();
            }
        }

        private void pictureBox_inventory_MonsterIcon_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(3);
                UpdateInventory();
            }
        }

        private void pictureBox_inventory_NachosIcon_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(4);
                UpdateInventory();
            }
        }

        private void pictureBox_inventory_BurguerIcon_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(5);
                UpdateInventory();
            }
        }

        private void pictureBox_inventory_Ramen_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(6);
                UpdateInventory();
            }
        }
    }
}
