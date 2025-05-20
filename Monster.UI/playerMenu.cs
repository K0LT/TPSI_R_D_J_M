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
        private BindingSource _bsUser = new BindingSource();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsUser
        {
            get => _bsUser.DataSource;
            set => _bsUser.DataSource = value;
        }

        private Form1 ParentForm => this.FindForm() as Form1;

        private BindingSource _bsFirstMonster = new BindingSource();
        private BindingSource _bsSecondMonster = new BindingSource();
        private BindingSource _bsThirdMonster = new BindingSource();
        private BindingSource _bsFourthMonster = new BindingSource();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsFirstMonster
        {
            get => _bsFirstMonster.DataSource;
            set => _bsFirstMonster.DataSource = value ?? _bsFirstMonster;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsSecondMonster
        {
            get => _bsSecondMonster.DataSource;
            set => _bsSecondMonster.DataSource = value ?? _bsSecondMonster;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsThirdMonster
        {
            get => _bsThirdMonster.DataSource;
            set => _bsThirdMonster.DataSource = value ?? _bsThirdMonster;
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object bsFourthMonster
        {
            get => _bsFourthMonster.DataSource;
            set => _bsFourthMonster.DataSource = value ?? _bsFourthMonster;
        }

        public playerMenu(string userType)
        {
            InitializeComponent();
            HideControls();
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

            if (bsFirstMonster != null)
            {
                pictureBox_playerMenu_Slot1.DataBindings.Clear();
                pictureBox_playerMenu_Slot1.DataBindings.Add(nameof(PictureBox.Image), bsFirstMonster, nameof(MonsterClass.MonsterIcon));

            }
            if (bsSecondMonster != null)
            {
                pictureBox_playerMenu_Slot2.DataBindings.Clear();

                pictureBox_playerMenu_Slot2.DataBindings.Add(nameof(PictureBox.Image), bsSecondMonster, nameof(MonsterClass.MonsterIcon));

                label_playerMenu_Slot2.Show();
                progressBar_playerMenu_Slot2.Show();
                button_playerMenu_ChangeSlot2.Show();
                pictureBox_playerMenu_Slot2.Show();

            }
            if (bsThirdMonster != null)
            {
                pictureBox_playerMenu_Slot3.DataBindings.Clear();

                pictureBox_playerMenu_Slot3.DataBindings.Add(nameof(PictureBox.Image), bsThirdMonster, nameof(MonsterClass.MonsterIcon));

                label_playerMenu_Slot3.Show();
                progressBar_playerMenu_Slot3.Show();
                button_playerMenu_ChangeSlot3.Show();
                pictureBox_playerMenu_Slot3.Show();

            }
            if (bsFourthMonster != null)
            {
                pictureBox_playerMenu_Slot4.DataBindings.Clear();

                pictureBox_playerMenu_Slot4.DataBindings.Add(nameof(PictureBox.Image), bsFourthMonster, nameof(MonsterClass.MonsterIcon));

                label_playerMenu_Slot4.Show();
                progressBar_playerMenu_Slot4.Show();
                button_playerMenu_ChangeSlot4.Show();
                pictureBox_playerMenu_Slot4.Show();

            }
            usernamePlayerMenuLabel.DataBindings.Clear();
            usernamePlayerMenuLabel.DataBindings.Add(nameof(Label.Text), bsUser, nameof(User.Username));

            ApplyUserTypeImage();
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

            //ParentForm.SetActiveMonster(0);
        }

        private void button_playerMenu_ChangeSlot4_Click(object sender, EventArgs e)
        {

            //ParentForm.SetActiveMonster(3);
        }

        private void button_playerMenu_ReturnToMyMonster_Click(object sender, EventArgs e)
        {

            ParentForm.NavigateTo("Monster");
        }

        private void button_PlayerMenu_Exit_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("Monster");
        }

        
    }
}
