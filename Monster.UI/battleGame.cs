
// Assuming necessary using statements remain unchanged
using Monster.Core.Models;
using Monster.UI.Properties;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Monster.UI
{
    public partial class battleGame : UserControl
    {
        private BindingSource _bsMonster = new BindingSource();
        private Form1 ParentForm => this.FindForm() as Form1;

        public MonsterClass Monster => _bsMonster.Current as MonsterClass;

        public object bsMonster
        {
            get => _bsMonster.DataSource;
            set => _bsMonster.DataSource = value;
        }


        public battleGame()
        {
            InitializeComponent();
            InitializeBoss("red");
        }

        public void HookBindings()
        {
            progressBar_battleGame_MyMonsterHp.DataBindings.Clear();
            label_battle_Name.DataBindings.Clear();
            progressBar_battleGame_MyMonsterHp.DataBindings.Add(nameof(ProgressBar.Value), _bsMonster, nameof(MonsterClass.HealthPoints));
            label_battle_Name.DataBindings.Add(nameof(Label.Text), _bsMonster, nameof(MonsterClass.Name));
            GetMonsterImage();

            _battleStamina = 100;
            progressBar_battleGame_MyMonsterStamina.Maximum = 100;
            progressBar_battleGame_MyMonsterStamina.Value = _battleStamina;
        }

        public void GetMonsterImage()
        {
            if (Monster != null)
            {
                int stage = Monster.Level < 5 ? 1 : Monster.Level < 10 ? 2 : 3;
                string type = Monster.Type?.ToLower() ?? "";

                string resourceName = $"{type}_stage{stage}_battle";
                var imageObj = Resources.ResourceManager.GetObject(resourceName);

                var image = ConvertByteArrayToImage(imageObj as byte[]);
                pictureBox_battleGame_myMonster.Image = image;  // sem fallback para default_monster
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





        // Boss definitions
        public class BossMonster
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public int HealthPoints { get; set; }
            public int MaxHealthPoints { get; set; } = 100;

            public BossMonster(string type)
            {
                Type = type.ToLower();
                Name = Type == "red" ? "red" : "skull";
                MaxHealthPoints = Type == "red" ? 100 : 300;
                HealthPoints = MaxHealthPoints;
            }

            public void TakeDamage(int damage)
            {
                HealthPoints -= damage;
                if (HealthPoints < 0) HealthPoints = 0;
            }
        }



        private BossMonster boss;
        public void InitializeBoss(string type)
        {
            boss = new BossMonster(type);
            progressBar_battleGame_BossHP.Maximum = boss.MaxHealthPoints;
            progressBar_battleGame_BossHP.Value = boss.HealthPoints;
            UpdateBossImage(false);
        }

        public async void FlashBossHurtImageBoss()
        {
            UpdateBossImage(true);
            await Task.Delay(1000);
            UpdateBossImage(false);
        }

        public void UpdateBossImage(bool isHurt)
        {
            string state = isHurt ? "hurt" : "normal";
            string resourceName = $"{boss.Type}_{state}";
            var imageObj = Resources.ResourceManager.GetObject(resourceName);
            pictureBox_battleGame_Boss.Image = ConvertByteArrayToImage(imageObj as byte[]);
        }

        private readonly Random _rng = new Random();
        private int _battleStamina = 100;

        private void button_Battle_Attack1_Click(object sender, EventArgs e)
        {
            const int staminaCost = 10;
            if (_battleStamina < staminaCost)
            {
                DoBossCounterAttack();
                IncreasePlayerStamina(50);
                ShowMessage("Not enough stamina! The boss attacks you for 10 HP.", "Warning");
                return;
            }
            _battleStamina -= staminaCost;
            progressBar_battleGame_MyMonsterStamina.Value = _battleStamina;

            if (_rng.NextDouble() <= 0.80)
            {
                int damage = GetAttackDamage(10);
                boss.HealthPoints -= damage;
                if (boss.HealthPoints < 0) boss.HealthPoints = 0;
                progressBar_battleGame_BossHP.Value = boss.HealthPoints;

                if (boss.HealthPoints == 0 && Monster != null)
                {
                    ParentForm.BattleReward(Monster, boss.Type);
                    ParentForm.NavigateTo("Monster");
                }

                FlashBossHurtImageBoss();
                if (_rng.NextDouble() <= 1)
                    DoBossCounterAttack();
            }
            else
            {
                ShowMessage("Your attack missed!", "Miss");
            }
        }

        private void button_Battle_Attack2_Click(object sender, EventArgs e)
        {
            const int staminaCost = 25;
            if (_battleStamina < staminaCost)
            {
                DoBossCounterAttack();
                IncreasePlayerStamina(50);
                ShowMessage("Not enough stamina! The boss attacks you for 10 HP.", "Warning");
                return;
            }
            _battleStamina -= staminaCost;
            progressBar_battleGame_MyMonsterStamina.Value = _battleStamina;

            if (_rng.NextDouble() <= 0.80)
            {
                int damage = GetAttackDamage(25);
                boss.HealthPoints -= damage;
                if (boss.HealthPoints < 0) boss.HealthPoints = 0;
                progressBar_battleGame_BossHP.Value = boss.HealthPoints;

                if (boss.HealthPoints == 0 && Monster != null)
                {
                    ParentForm.BattleReward(Monster, boss.Type);
                    ParentForm.NavigateTo("Monster");
                }

                FlashBossHurtImageBoss();
                if (_rng.NextDouble() <= 1)
                    DoBossCounterAttackStrong();
            }
            else
            {
                ShowMessage("Your attack missed!", "Miss");
            }
        }

        private void IncreasePlayerStamina(int amount)
        {
            _battleStamina += amount;
            if (_battleStamina > 100) _battleStamina = 100;
            progressBar_battleGame_MyMonsterStamina.Value = _battleStamina;
        }

        private int GetAttackDamage(int baseDamage)
        {
            if (Monster != null)
            {
                int level = Monster.Level;
                if (level <= 4) return baseDamage;
                if (level <= 9) return baseDamage + 5;
                if (level <= 15) return baseDamage + 10;
                if (level <= 20) return baseDamage + 15;
            }
            return baseDamage;
        }

        private void DoBossCounterAttack()
        {
            int roll = _rng.Next(100);

            if (roll < 70 && _rng.NextDouble() <= 0.70)
                DealDamageToPlayer(10, true);
            else if (roll < 90 && _rng.NextDouble() <= 0.40)
                DealDamageToPlayer(20, true);
            else if (_rng.NextDouble() <= 0.10)
                DealDamageToPlayer(30, true);
        }

        private void DoBossCounterAttackStrong()
        {
            int roll = _rng.Next(100);

            if (roll < 60 && _rng.NextDouble() <= 0.50)
                DealDamageToPlayer(20, true);
            else if (roll < 90 && _rng.NextDouble() <= 0.30)
                DealDamageToPlayer(35, true);
            else if (_rng.NextDouble() <= 0.15)
                DealDamageToPlayer(50, true);
        }

        private void DealDamageToPlayer(int damage, bool showMessage = false)
        {
            if (Monster != null)
            {
                Monster.HealthPoints -= damage;
                if (Monster.HealthPoints < 0) Monster.HealthPoints = 0;

                if (Monster.HealthPoints == 0)
                {
                    ShowMessageAndNavigate("Your monster has been defeated!", "Defeat");
                }
                else if (showMessage)
                {
                    ShowMessage($"The boss counterattacked and dealt {damage} damage to your monster!", "Counterattack");
                }
            }
        }

        private void ShowMessageAndNavigate(string text, string caption)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ParentForm.NavigateTo("Monster");
                }));
            }
            else
            {
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ParentForm.NavigateTo("Monster");
            }
        }


        private void ShowMessage(string text, string caption)
        {
            if (InvokeRequired)
                Invoke(new Action(() => MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information)));
            else
                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

