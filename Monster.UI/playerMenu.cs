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
                    progressBar_playerMenu_Slot1.Value = OwnedMonstersRef.ElementAt(0).HealthPoints;
                    pictureBox_playerMenu_Slot1.Image = OwnedMonstersRef.ElementAt(0).MonsterIcon;
                    label_playerMenu_Slot1.Text = OwnedMonstersRef.ElementAt(0).Name;
                    break;
                case 2:
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
                    label_playerMenu_Slot4.Text = OwnedMonstersRef.ElementAt(2).Name;
                    progressBar_playerMenu_Slot4.Show();
                    progressBar_playerMenu_Slot4.Value = OwnedMonstersRef.ElementAt(3).HealthPoints;
                    button_playerMenu_ChangeSlot4.Show();
                    pictureBox_playerMenu_Slot4.Show();
                    pictureBox_playerMenu_Slot4.Image = OwnedMonstersRef.ElementAt(3).MonsterIcon;
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
                        pictureBox_playerMenu.Image = ConvertByteArrayToImage(Properties.Resources.boyPlayerPic);
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

        private void button_playerMenu_ChangeSlot3_Click(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;
            ParentForm.SetActiveMonster(2);
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

        private void button_playerMenu_ChangeSlot2_Click_1(object sender, EventArgs e)
        {
            Form1 ParentForm = this.FindForm() as Form1;
            ParentForm.SetActiveMonster(1);
        }

    }
}
