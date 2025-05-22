using Monster.Core.Models;
using Monster.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    public partial class playerMenu : UserControl
    {
        // BindingSource to bind user data to UI elements
        private BindingSource _bsUser = new BindingSource();

        // Property exposing the DataSource of the BindingSource, hidden from designer serialization
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsUser
        {
            get => _bsUser.DataSource;
            set => _bsUser.DataSource = value;
        }

        // Reference to the list of monsters owned by the player
        private List<MonsterClass> _ownedMonstersRef;

        // Public property for setting/getting owned monsters list, hidden from designer serialization
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<MonsterClass> OwnedMonstersRef
        {
            get => _ownedMonstersRef;
            set => _ownedMonstersRef = value;
        }

        // Constructor - Initialize the user control
        public playerMenu(string userType)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hides the UI controls related to monster slots 2, 3, and 4.
        /// Used to reset the UI before showing only relevant controls.
        /// </summary>
        public void HideControls()
        {
            System.Diagnostics.Debug.WriteLine($"[DEBUG - playerMenu]: HideControls() call.");
            label_playerMenu_Slot2.Hide();
            label_playerMenu_Slot3.Hide();
            label_playerMenu_Slot4.Hide();
            progressBar_playerMenu_Slot2.Hide();
            progressBar_playerMenu_Slot3.Hide();
            progressBar_playerMenu_Slot4.Hide();
            button_playerMenu_ChangeSlot2.Hide();
            button_playerMenu_ChangeSlot3.Hide();
            button_playerMenu_ChangeSlot4.Hide();
            pictureBox_playerMenu_Slot2.Hide();
            pictureBox_playerMenu_Slot3.Hide();
            pictureBox_playerMenu_Slot4.Hide();
        }

        /// <summary>
        /// Binds the user data to the UI, hides unused controls, then shows and populates controls for owned monsters.
        /// Also applies the correct player image based on user type.
        /// </summary>
        public void HookBindings()
        {
            HideControls();

            // Clear existing bindings and bind username label to user's Username property
            usernamePlayerMenuLabel.DataBindings.Clear();
            usernamePlayerMenuLabel.DataBindings.Add(nameof(Label.Text), bsUser, nameof(User.Username));

            ShowControls();

            ApplyUserTypeImage();
        }

        /// <summary>
        /// Shows and updates the UI elements (labels, progress bars, images, buttons)
        /// corresponding to the player's owned monsters.
        /// Supports up to 4 monsters.
        /// </summary>
        private void ShowControls()
        {
            int tempCount = _ownedMonstersRef.Count();
            System.Diagnostics.Debug.WriteLine($"[DEBUG - playerMenu]: ShowControls() call, count: {tempCount}");

            // Depending on how many monsters the player owns, update UI elements accordingly
            switch (tempCount)
            {
                case 1:
                    // Show info for monster slot 1 only
                    progressBar_playerMenu_Slot1.Value = OwnedMonstersRef.ElementAt(0).HealthPoints;
                    pictureBox_playerMenu_Slot1.Image = OwnedMonstersRef.ElementAt(0).MonsterIcon;
                    label_playerMenu_Slot1.Text = OwnedMonstersRef.ElementAt(0).Name;
                    break;
                case 2:
                    // Show slot 1 and slot 2 monsters
                    progressBar_playerMenu_Slot1.Value = OwnedMonstersRef.ElementAt(0).HealthPoints;
                    pictureBox_playerMenu_Slot1.Image = OwnedMonstersRef.ElementAt(0).MonsterIcon;
                    label_playerMenu_Slot1.Text = OwnedMonstersRef.ElementAt(0).Name;

                    label_playerMenu_Slot2.Show();
                    label_playerMenu_Slot2.Text = OwnedMonstersRef.ElementAt(1).Name;
                    progressBar_playerMenu_Slot2.Show();
                    progressBar_playerMenu_Slot2.Value = OwnedMonstersRef.ElementAt(1).HealthPoints;
                    button_playerMenu_ChangeSlot2.Show();
                    pictureBox_playerMenu_Slot2.Show();
                    pictureBox_playerMenu_Slot2.Image = OwnedMonstersRef.ElementAt(1).MonsterIcon;
                    break;
                case 3:
                    // Show slots 1, 2, and 3 monsters
                    progressBar_playerMenu_Slot1.Value = OwnedMonstersRef.ElementAt(0).HealthPoints;
                    pictureBox_playerMenu_Slot1.Image = OwnedMonstersRef.ElementAt(0).MonsterIcon;
                    label_playerMenu_Slot1.Text = OwnedMonstersRef.ElementAt(0).Name;

                    label_playerMenu_Slot2.Show();
                    label_playerMenu_Slot2.Text = OwnedMonstersRef.ElementAt(1).Name;
                    progressBar_playerMenu_Slot2.Show();
                    progressBar_playerMenu_Slot2.Value = OwnedMonstersRef.ElementAt(1).HealthPoints;
                    button_playerMenu_ChangeSlot2.Show();
                    pictureBox_playerMenu_Slot2.Show();
                    pictureBox_playerMenu_Slot2.Image = OwnedMonstersRef.ElementAt(1).MonsterIcon;

                    label_playerMenu_Slot3.Show();
                    label_playerMenu_Slot3.Text = OwnedMonstersRef.ElementAt(2).Name;
                    progressBar_playerMenu_Slot3.Show();
                    progressBar_playerMenu_Slot3.Value = OwnedMonstersRef.ElementAt(2).HealthPoints;
                    button_playerMenu_ChangeSlot3.Show();
                    pictureBox_playerMenu_Slot3.Show();
                    pictureBox_playerMenu_Slot3.Image = OwnedMonstersRef.ElementAt(2).MonsterIcon;
                    break;
                case 4:
                    // Show all 4 monster slots
                    progressBar_playerMenu_Slot1.Value = OwnedMonstersRef.ElementAt(0).HealthPoints;
                    pictureBox_playerMenu_Slot1.Image = OwnedMonstersRef.ElementAt(0).MonsterIcon;
                    label_playerMenu_Slot1.Text = OwnedMonstersRef.ElementAt(0).Name;

                    label_playerMenu_Slot2.Show();
                    label_playerMenu_Slot2.Text = OwnedMonstersRef.ElementAt(1).Name;
                    progressBar_playerMenu_Slot2.Show();
                    progressBar_playerMenu_Slot2.Value = OwnedMonstersRef.ElementAt(1).HealthPoints;
                    button_playerMenu_ChangeSlot2.Show();
                    pictureBox_playerMenu_Slot2.Show();
                    pictureBox_playerMenu_Slot2.Image = OwnedMonstersRef.ElementAt(1).MonsterIcon;

                    label_playerMenu_Slot3.Show();
                    label_playerMenu_Slot3.Text = OwnedMonstersRef.ElementAt(2).Name;
                    progressBar_playerMenu_Slot3.Show();
                    progressBar_playerMenu_Slot3.Value = OwnedMonstersRef.ElementAt(2).HealthPoints;
                    button_playerMenu_ChangeSlot3.Show();
                    pictureBox_playerMenu_Slot3.Show();
                    pictureBox_playerMenu_Slot3.Image = OwnedMonstersRef.ElementAt(2).MonsterIcon;

                    label_playerMenu_Slot4.Show();
                    label_playerMenu_Slot4.Text = OwnedMonstersRef.ElementAt(3).Name;
                    progressBar_playerMenu_Slot4.Show();
                    progressBar_playerMenu_Slot4.Value = OwnedMonstersRef.ElementAt(3).HealthPoints;
                    button_playerMenu_ChangeSlot4.Show();
                    pictureBox_playerMenu_Slot4.Show();
                    pictureBox_playerMenu_Slot4.Image = OwnedMonstersRef.ElementAt(3).MonsterIcon;
                    break;
                default:
                    // If no monsters or more than 4, no UI update here (could add logic if needed)
                    break;
            }
        }

        /// <summary>
        /// Applies the appropriate player avatar image based on the UserType of the current user.
        /// </summary>
        private void ApplyUserTypeImage()
        {
            // Ensure bsUser is a User object before accessing UserType
            if (bsUser is User user)
            {
                switch (user.UserType.ToLower())
                {
                    case "boy":
                        pictureBox_playerMenu.Image = ConvertByteArrayToImage(Properties.Resources.boyPlayerPic);
                        break;
                    case "girl":
                        pictureBox_playerMenu.Image = ConvertByteArrayToImage(Properties.Resources.girlPlayerPic);
                        break;
                    default:
                        pictureBox_playerMenu.Image = ConvertByteArrayToImage(Properties.Resources.otherPlayerPic);
                        break;
                }
            }
        }

        /// <summary>
        /// Converts a byte array representing an image into an Image object.
        /// </summary>
        /// <param name="byteArray">Byte array containing image data</param>
        /// <returns>Image object</returns>
        private Image ConvertByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// Prompts the user to confirm changing the active monster to the one at the specified index,
        /// and if confirmed, notifies the parent form to update the active monster and navigate.
        /// </summary>
        /// <param name="index">Index of the monster to activate</param>
        private void ConfirmAndSetActiveMonster(int index)
        {
            Form1 ParentForm = this.FindForm() as Form1;
            if (ParentForm == null || OwnedMonstersRef == null || index >= OwnedMonstersRef.Count) return;

            string monsterName = OwnedMonstersRef[index].Name;

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to change to {monsterName}?",
                "Confirm Monster Change",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                ParentForm.SetActiveMonster(index);
                ParentForm.NavigateTo("Monster");
            }
        }

        // Event handlers for changing active monster from each slot's change button
        private void button_playerMenu_ChangeMonsterSlot1_Click(object sender, EventArgs e)
        {
            ConfirmAndSetActiveMonster(0);
        }

        private void button_playerMenu_ChangeSlot2_Click(object sender, EventArgs e)
        {
            ConfirmAndSetActiveMonster(1);
        }

        private void button_playerMenu_ChangeSlot3_Click(object sender, EventArgs e)
        {
            ConfirmAndSetActiveMonster(2);
        }

        private void button_playerMenu_ChangeSlot4_Click(object sender, EventArgs e)
        {
            ConfirmAndSetActiveMonster(3);
        }

        /// <summary>
        /// Navigates back to the Monster view in the parent form.
        /// Used by return and exit buttons.
        /// </summary>
        private void button_playerMenu_ReturnToMyMonster_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;
            ParentForm.NavigateTo("Monster");
        }

        private void button_PlayerMenu_Exit_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;
            ParentForm.NavigateTo("Monster");
        }
    }
}
