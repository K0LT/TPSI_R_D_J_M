using Monster.Core.Models;
using Monster.Game.GameState;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Monster.UI
{
    /// <summary>
    /// Provides a quick and easy pop-up window displaying a timer.
    /// </summary>
    public partial class countdownForm : Form
    {
        // BindingSource to manage data binding with the MonsterClass instance.
        private BindingSource _bsMonster = new BindingSource();

    

        // Timer for countdown
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer zzSwapTimer;



        // Countdown and monster-related variables
        private int _countdown = 15;
        private int _missingHealth;
        private int _missingStamina;
        private MonsterClass _monster;
       

        /// <summary>
        /// Exposes the data source for binding, linked to the internal BindingSource.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public object bsDataSource
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



    }
}
