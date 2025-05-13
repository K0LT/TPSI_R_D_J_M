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
        private string _userType;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserType
        {
            get => _userType;
            set
            {
                _userType = value;
                ApplyUserTypeImage();
            }
        }

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
            UserType = userType;
        }

        public void HookBindings()
        {
            if (bsFirstMonster != null)
            {
                pictureBox_playerMenu_Slot1.DataBindings.Clear();
                pictureBox_playerMenu_Slot1.DataBindings.Add(nameof(PictureBox.Image), bsFirstMonster, nameof(MonsterClass.MonsterIcon));

            }
            if (bsSecondMonster != null)
            {
                pictureBox_playerMenu_Slot2.DataBindings.Clear();

                pictureBox_playerMenu_Slot2.DataBindings.Add(nameof(PictureBox.Image), bsSecondMonster, nameof(MonsterClass.MonsterIcon));

            }
            if (bsThirdMonster != null)
            {
                pictureBox_playerMenu_Slot3.DataBindings.Clear();

                pictureBox_playerMenu_Slot3.DataBindings.Add(nameof(PictureBox.Image), bsThirdMonster, nameof(MonsterClass.MonsterIcon));

            }
            if (bsFourthMonster != null)
            {
                pictureBox_playerMenu_Slot4.DataBindings.Clear();

                pictureBox_playerMenu_Slot4.DataBindings.Add(nameof(PictureBox.Image), bsFourthMonster, nameof(MonsterClass.MonsterIcon));

            }
        }


        private void ApplyUserTypeImage()
        {
            switch (_userType?.ToLower())
            {
                case "boy":
                    pictureBox1.Image = ConvertByteArrayToImage(Properties.Resources.playergrandesemback); // Replace with your actual resource
                    break;
                case "girl":
                    pictureBox1.Image = ConvertByteArrayToImage(Properties.Resources.playergirlgrandesemback); // Replace with your actual resource
                    break;
                default:
                    pictureBox1.Image = ConvertByteArrayToImage(Properties.Resources.defaultUserImage); // Fallback image
                    break;
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
            Form1 parentForm = this.FindForm() as Form1;

            parentForm.SetActiveMonster(0);
        }

        private void button_playerMenu_ChangeSlot4_Click(object sender, EventArgs e)
        {
            Form1 parentForm = this.FindForm() as Form1;

            parentForm.SetActiveMonster(3);
        }

        private void button_playerMenu_ReturnToMyMonster_Click(object sender, EventArgs e)
        {
            Form1 parentForm = this.FindForm() as Form1;

            parentForm.NavigateTo("Monster");
        }

       
    }
}
