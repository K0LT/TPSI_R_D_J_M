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

        public playerMenu(string userType)
        {
            InitializeComponent();
            UserType = userType;
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
    }
}
