using Monster.Core.Models;
using Monster.Game.GameState;
using Monster.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    /// <summary>
    /// Inventory user control for managing item use and displaying monster stats.
    /// </summary>
    public partial class inventory : UserControl
    {
        private bool firstHook = false;

        private BindingSource _bsMonster = new BindingSource();
        private BindingSource _state = new BindingSource();
        private BindingSource _bsInventory = new BindingSource();

        // Binds game state for interaction logic (e.g., UseItemAtIndex)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public object State
        {
            get => _state.DataSource;
            set => _state.DataSource = value;
        }

        // Binds inventory data (List<Item>)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public object bsInventory
        {
            get => _bsInventory.DataSource;
            set => _bsInventory.DataSource = value;
        }

        // Binds monster object (for HP/Stamina and image)
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public object bsDataSource
        {
            get => _bsMonster.DataSource;
            set => _bsMonster.DataSource = value;
        }

        // Binds monster object
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public object bsMonster
        {
            get => _bsMonster.DataSource;
            set => _bsMonster.DataSource = value;
        }

        public inventory()
        {
            InitializeComponent();

            // Set tooltip descriptions for each item icon
            DesignUI.SetToolTip(pictureBox_inventory_waterIcon, "+10 St.");
            DesignUI.SetToolTip(pictureBox_inventory_SodaIcon, "+30 St.");
            DesignUI.SetToolTip(pictureBox_inventory_BeerIcon, "+50 St.");
            DesignUI.SetToolTip(pictureBox_inventory_NachosIcon, "+10 HP");
            DesignUI.SetToolTip(pictureBox_inventory_BurguerIcon, "+30 HP");
            DesignUI.SetToolTip(pictureBox_inventory_Ramen, "+50 HP");
            DesignUI.SetToolTip(pictureBox_inventory_EnergyDrink, "+100 HP & St.");
        }

        /// <summary>
        /// Hooks data bindings for monster HP, stamina, and monster image.
        /// </summary>
        public void HookBindings()
        {
            progressBar_inventory_HP.DataBindings.Clear();
            progressBar_inventory_Stamina.DataBindings.Clear();
            pictureBox_inventory_Monster.DataBindings.Clear();

            // Bind progress bars to monster's HP and stamina
            progressBar_inventory_HP.DataBindings.Add(nameof(GoldProgressBar.Value), bsDataSource, nameof(MonsterClass.HealthPoints));
            progressBar_inventory_Stamina.DataBindings.Add(nameof(GoldProgressBar.Value), bsDataSource, nameof(MonsterClass.Stamina));

            GetMonsterImageInventory();
            UpdateInventory();
        }

        /// <summary>
        /// Initializes the inventory with preset items and icons.
        /// </summary>
        public List<Item> InitializeInventory()
        {
            // Retrieve item icons from the PictureBoxes
            var waterIcon = pictureBox_inventory_waterIcon.Image;
            var sodaIcon = pictureBox_inventory_SodaIcon.Image;
            var beerIcon = pictureBox_inventory_BeerIcon.Image;
            var nachosIcon = pictureBox_inventory_NachosIcon.Image;
            var burguerIcon = pictureBox_inventory_BurguerIcon.Image;
            var ramenIcon = pictureBox_inventory_Ramen.Image;
            var energyDrinkIcon = pictureBox_inventory_EnergyDrink.Image;

            // Create item list with base quantities
            var inventory = new List<Item>
            {
                new StaminaItem("Water", waterIcon, 10, 3),
                new StaminaItem("Soda", sodaIcon, 30, 2),
                new StaminaItem("Beer", beerIcon, 50, 2),
                new HealthItem("Nachos", nachosIcon, 10, 2),
                new HealthItem("Burguer", burguerIcon, 30, 2),
                new HealthItem("Ramen", ramenIcon, 50, 2),
                new FullRestoreItem("Energy Drink", energyDrinkIcon, 100, 100, 2)
            };

            return inventory;
        }

        /// <summary>
        /// Updates quantity labels based on inventory data.
        /// </summary>
        private void UpdateInventory()
        {
            if (bsInventory is List<Item> list && list.Count >= 7)
            {
                label_inventory_water.Text = list[0].Quantity.ToString();
                label_inventory_Soda.Text = list[1].Quantity.ToString();
                label_inventory_Beer.Text = list[2].Quantity.ToString();
                label_inventory_Nachos.Text = list[3].Quantity.ToString();
                label_inventory_Burguer.Text = list[4].Quantity.ToString();
                label_inventory_Ramen.Text = list[5].Quantity.ToString();
                label_inventory_EnergyDrink.Text = list[6].Quantity.ToString();
            }
        }

        /// <summary>
        /// Navigates back to the main monster view.
        /// </summary>
        private void button_inventory_ReturnToMyMonster_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;
            ParentForm.NavigateTo("Monster");
        }

        // Each item click method uses the item at its respective index, then refreshes inventory view

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

        private void pictureBox_inventory_NachosIcon_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(3);
                UpdateInventory();
            }
        }

        private void pictureBox_inventory_BurguerIcon_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(4);
                UpdateInventory();
            }
        }

        private void pictureBox_inventory_Ramen_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(5);
                UpdateInventory();
            }
        }

        private void pictureBox_inventory_MonsterIcon_Click(object sender, EventArgs e)
        {
            if (State is GameState game)
            {
                game.UseItemAtIndex(6);
                UpdateInventory();
            }
        }

        /// <summary>
        /// Loads and sets the appropriate monster image based on its type and level.
        /// </summary>
        public void GetMonsterImageInventory()
        {
            if (bsMonster is MonsterClass monster)
            {
                int stage = monster.Level < 5 ? 1 : monster.Level < 10 ? 2 : 3;
                string type = monster.Type?.ToLower() ?? "";

                string resourceName = $"{type}_stage{stage}_inventory";
                string iconName = $"{type}_icon";

                System.Diagnostics.Debug.WriteLine("GetMonsterBack call! iconName: " + iconName + " | resourceName: " + resourceName);

                var imageObj = Monster.UI.Properties.Resources.ResourceManager.GetObject(resourceName);
                var iconObj = Monster.UI.Properties.Resources.ResourceManager.GetObject(iconName);

                pictureBox_inventory_Monster.Image = ConvertByteArrayToImage(imageObj as byte[]);
            }
        }

        /// <summary>
        /// Converts an image stored as a byte array into an Image object.
        /// </summary>
        private Image ConvertByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
