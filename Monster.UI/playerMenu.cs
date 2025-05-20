using Monster.Core.Models;
using Monster.UI.Properties;
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
        private BindingSource _bsUser = new BindingSource();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsUser
        {
            get => _bsUser.DataSource;
            set => _bsUser.DataSource = value;
        }

        public List<MonsterClass> OwnedMonstersRef
        {
            get;
            set;
        }

        public playerMenu(string userType)
        {
            InitializeComponent();
        }

        public void HideControls()
        {
            Slot2Label.Hide();
            Slot3Label.Hide();
            Slot4Label.Hide();
            Slot3ProgressBar.Hide();
            Slot2ProgressBar.Hide();
            Slot4ProgressBar.Hide();
            Slot2Button.Hide();
            Slot3Button.Hide();
            Slot4Button.Hide();
            Slot3PictureBox.Hide();
            Slot2PictureBox.Hide();
            Slot4PictureBox.Hide();
        }

        public void HookBindings()
        {
            HideControls();

            usernamePlayerMenuLabel.DataBindings.Clear();
            usernamePlayerMenuLabel.DataBindings.Add(nameof(Label.Text), bsUser, nameof(User.Username));

            ShowControls();

            ApplyUserTypeImage();
        }

        private void ShowControls()
        {
            switch (OwnedMonstersRef.Count())
            {
                case 1:
                    Slot1ProgressBar.Value = OwnedMonstersRef.ElementAt(0).HealthPoints;
                    Slot1PictureBox.Image = OwnedMonstersRef.ElementAt(0).MonsterIcon;
                    Slot1Label.Text = OwnedMonstersRef.ElementAt(0).Name;
                    break;
                case 2:
                    Slot1ProgressBar.Value = OwnedMonstersRef.ElementAt(0).HealthPoints;
                    Slot1PictureBox.Image = OwnedMonstersRef.ElementAt(0).MonsterIcon;
                    Slot1Label.Text = OwnedMonstersRef.ElementAt(0).Name;
                    Slot2Label.Show();
                    Slot2Label.Text = OwnedMonstersRef.ElementAt(1).Name;
                    Slot2ProgressBar.Show();
                    Slot2ProgressBar.Value = OwnedMonstersRef.ElementAt(1).HealthPoints;
                    Slot2Button.Show();
                    Slot2PictureBox.Show();
                    Slot2PictureBox.Image = OwnedMonstersRef.ElementAt(1).MonsterIcon;
                    break;
                case 3:
                    Slot1ProgressBar.Value = OwnedMonstersRef.ElementAt(0).HealthPoints;
                    Slot1PictureBox.Image = OwnedMonstersRef.ElementAt(0).MonsterIcon;
                    Slot1Label.Text = OwnedMonstersRef.ElementAt(0).Name;
                    Slot2Label.Show();
                    Slot2Label.Text = OwnedMonstersRef.ElementAt(1).Name;
                    Slot2ProgressBar.Show();
                    Slot2ProgressBar.Value = OwnedMonstersRef.ElementAt(1).HealthPoints;
                    Slot2Button.Show();
                    Slot2PictureBox.Show();
                    Slot2PictureBox.Image = OwnedMonstersRef.ElementAt(1).MonsterIcon;
                    Slot3Label.Show();
                    Slot3Label.Text = OwnedMonstersRef.ElementAt(2).Name;
                    Slot3ProgressBar.Show();
                    Slot3ProgressBar.Value = OwnedMonstersRef.ElementAt(2).HealthPoints;
                    Slot3Button.Show();
                    Slot3PictureBox.Show();
                    Slot3PictureBox.Image = OwnedMonstersRef.ElementAt(2).MonsterIcon;
                    break;
                case 4:
                    Slot1ProgressBar.Value = OwnedMonstersRef.ElementAt(0).HealthPoints;
                    Slot1PictureBox.Image = OwnedMonstersRef.ElementAt(0).MonsterIcon;
                    Slot1Label.Text = OwnedMonstersRef.ElementAt(0).Name;
                    Slot2Label.Show();
                    Slot2Label.Text = OwnedMonstersRef.ElementAt(1).Name;
                    Slot2ProgressBar.Show();
                    Slot2ProgressBar.Value = OwnedMonstersRef.ElementAt(1).HealthPoints;
                    Slot2Button.Show();
                    Slot2PictureBox.Show();
                    Slot2PictureBox.Image = OwnedMonstersRef.ElementAt(1).MonsterIcon;
                    Slot3Label.Show();
                    Slot3Label.Text = OwnedMonstersRef.ElementAt(2).Name;
                    Slot3ProgressBar.Show();
                    Slot3ProgressBar.Value = OwnedMonstersRef.ElementAt(2).HealthPoints;
                    Slot3Button.Show();
                    Slot3PictureBox.Show();
                    Slot3PictureBox.Image = OwnedMonstersRef.ElementAt(2).MonsterIcon;
                    Slot4Label.Show();
                    Slot4Label.Text = OwnedMonstersRef.ElementAt(2).Name;
                    Slot4ProgressBar.Show();
                    Slot4ProgressBar.Value = OwnedMonstersRef.ElementAt(3).HealthPoints;
                    Slot4Button.Show();
                    Slot4PictureBox.Show();
                    Slot4PictureBox.Image = OwnedMonstersRef.ElementAt(3).MonsterIcon;
                    break;
                default:
                    break;
            }
        }


        private void ApplyUserTypeImage()
        {
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
        private Image ConvertByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void button_playerMenu_ChangeMonsterSlot1_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;
            ParentForm.SetActiveMonster(0);
        }

        private void button_playerMenu_ChangeSlot2_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;
            ParentForm.SetActiveMonster(1);
        }

        private void button_playerMenu_ChangeSlot4_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;
            ParentForm.SetActiveMonster(3);
        }

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
