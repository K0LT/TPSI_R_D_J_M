using Monster.Core.Models;
using Monster.Game.GameState;
using Monster.UI.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Monster.Game.GameState;
using static System.Windows.Forms.AxHost;

namespace Monster.UI
{
    /// <summary>
    /// Provides a quick and easy pop-up window displaying a timer.
    /// </summary>
    public partial class countdownForm : Form
    {
        // BindingSource to manage data binding with the MonsterClass instance.
        private BindingSource _bsMonster = new BindingSource();
                private BindingSource _state = new BindingSource();



        // Timer for countdown
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer zzSwapTimer;



        // Countdown and monster-related variables
        private int _countdown = 15;
        private int _missingHealth;
        private int _missingStamina;
        private MonsterClass _monster;
        public MonsterClass Monster => _bsMonster.Current as MonsterClass;


        /// <summary>
        /// Exposes the data source for binding, linked to the internal BindingSource.
        /// </summary>
    

      
       

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

        public countdownForm()
        {
            InitializeComponent(); // In case designer is used
        }

        public countdownForm(MonsterClass monster) : this()
        {
            if (monster == null) throw new ArgumentNullException(nameof(monster));

            _monster = monster;
            _missingHealth = 100 - _monster.HealthPoints;
            _missingStamina = 100 - _monster.Stamina;

            SetupUI();
            StartCountdown();
            StartZzSwap();
        }


        private void SetupUI()
        {
            Width = 320;
            Height = 250;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            ControlBox = false;
            MinimizeBox = false;
            MaximizeBox = false;
            BackColor = Color.Black;            
            GetMonsterBack();

        }

        private void StartCountdown()
        {
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _countdown--;
            this.Text = $"Sleeping... {_countdown} seconds remaining...";
            if (_countdown > 0)
            {
                _monster.HealthPoints += _missingHealth / 15;
                _monster.Stamina += _missingStamina / 15;
            }
            else
            {
                timer.Stop();
                _monster.HealthPoints = 100;
                _monster.Stamina = 100;
                GameState.Current.ActiveMonster.HealthPoints = _monster.HealthPoints;
                GameState.Current.ActiveMonster.Stamina = _monster.Stamina;
                DialogResult = DialogResult.OK;
                Close();
            }
        }


        private int tickCount = 0;
        private void StartZzSwap()
        {
            zzSwapTimer = new System.Windows.Forms.Timer();
            zzSwapTimer.Interval = 500;
            zzSwapTimer.Tick += (s, e) =>
            {

                if (tickCount % 2 == 0)
                {
                    label_Zz.Visible = true;
                    label_Zz1.Visible = false;
                }
                else
                {
                    label_Zz.Visible = false;
                    label_Zz1.Visible = true;
                }
                tickCount++;
            };
            zzSwapTimer.Start();
        }


        public void GetMonsterBack()
        {
            

            if (_monster is MonsterClass monster)
            {
                int stage = monster.Level < 5 ? 1 : monster.Level < 10 ? 2 : 3;
                string type = monster.Type?.ToLower() ?? "";

                string resourceName = $"{type}_stage{stage}_sleeping";
                var imageObj = Resources.ResourceManager.GetObject(resourceName);

                if (imageObj is byte[] imageBytes)
                {
                    var image = ConvertByteArrayToImage(imageBytes);
                    this.BackgroundImage = image;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Image not found for resource: {resourceName}");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("No active monster found in GameState.");
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
