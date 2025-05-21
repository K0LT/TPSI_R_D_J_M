using Monster.Core.Models;
using Monster.UI.Properties;
using System;
using System.Drawing;
using System.IO;
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
                int stage = monster.Level < 5 ? 1 : monster.Level < 10 ? 2 : 3;
                string type = monster.Type?.ToLower() ?? "";

                string resourceName = $"{type}_stage{stage}_battle";
                string iconName = $"{type}_icon";

                System.Diagnostics.Debug.WriteLine("GetMonsterImageInventory call! iconName: " + iconName + " | resourceName: " + resourceName);

                var imageObj = Monster.UI.Properties.Resources.ResourceManager.GetObject(resourceName);
                var iconObj = Monster.UI.Properties.Resources.ResourceManager.GetObject(iconName);

                pictureBox_battleGame_myMonster.Image = ConvertByteArrayToImage(imageObj as byte[]);
            }
        }

        private Image ConvertByteArrayToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

             
    }
}





































//using Monster.Core.Models;
//using Monster.UI.Properties;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Resources;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Monster.UI
//{
//    public partial class battleGame : UserControl
//    {
//        private BindingSource _bsMonster = new BindingSource();

//        public object bsMonster
//        {
//            get => _bsMonster.DataSource;
//            set => _bsMonster.DataSource = value;
//        }

//        public battleGame()
//        {
//            InitializeComponent();
//        }

//        public void HookBindings()
//        {
//            progressBar_battleGame_MyMonsterHp.DataBindings.Clear();
//            label_battle_Name.DataBindings.Clear();

//            progressBar_battleGame_MyMonsterHp.DataBindings.Add(nameof(ProgressBar.Value), bsMonster, nameof(MonsterClass.HealthPoints));

//            label_battle_Name.DataBindings.Add(nameof(Label.Text), bsMonster, nameof(MonsterClass.Name));

//            GetMonsterImage();
//        }



//        public void GetMonsterImage()
//        {
//            if (bsMonster is MonsterClass monster)
//            {
//                int stage = monster.Level < 5 ? 1 : monster.Level < 10 ? 2 : 3;
//                string type = monster.Type?.ToLower() ?? "";

//                string resourceName = $"{type}_stage{stage}_battle";
//                string iconName = $"{type}_icon";

//                System.Diagnostics.Debug.WriteLine("GetMonsterImageInventory call! iconName: " + iconName + " | resourceName: " + resourceName);

//                var imageObj = Monster.UI.Properties.Resources.ResourceManager.GetObject(resourceName);
//                var iconObj = Monster.UI.Properties.Resources.ResourceManager.GetObject(iconName);

//                pictureBox_battleGame_myMonster.Image = ConvertByteArrayToImage(imageObj as byte[]);

//            }
//        }


//        private Image ConvertByteArrayToImage(byte[] bytes)
//        {
//            using (var ms = new MemoryStream(bytes))
//            {
//                return Image.FromStream(ms);
//            }
//        }
//    }
//}
