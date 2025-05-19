using Monster.Core.Models;
using Monster.UI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    public partial class battleGame : UserControl
    {
        private BindingSource _bsMonster = new BindingSource();

        public object bsMonster
        {
            get => _bsMonster.DataSource;
            set => _bsMonster.DataSource = value;
        }

        public battleGame()
        {
            InitializeComponent();
        }

        public void HookBindings()
        {
            progressBar_battleGame_MyMonsterHp.DataBindings.Clear();
            label_battle_Name.DataBindings.Clear();

            progressBar_battleGame_MyMonsterHp.DataBindings.Add(nameof(ProgressBar.Value), bsMonster, nameof(MonsterClass.HealthPoints));

            label_battle_Name.DataBindings.Add(nameof(Label.Text), bsMonster, nameof(MonsterClass.Name));

            GetMonsterImage();
        }

        public void GetMonsterImage()
        {
            if (bsMonster is MonsterClass monster)
            {
                switch (monster.Type)
                {
                    case "draco":
                        pictureBox_battleGame_Draco.Image = ConvertByteArrayToImage(Resources.dracoBackHeadSmall);
                        break;
                    case "siren":
                        pictureBox_battleGame_Draco.Image = ConvertByteArrayToImage(Resources.sirenBackHeadSmall);
                        break;
                    case "grifo":
                        pictureBox_battleGame_Draco.Image = ConvertByteArrayToImage(Resources.grifoBackHeadSmall);
                        break;
                    case "tauro":
                        pictureBox_battleGame_Draco.Image = ConvertByteArrayToImage(Resources.tauroBackHeadSmall);
                        break;
                    default:
                        throw new Exception();
                }
            }
        }

        private Image ConvertByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
