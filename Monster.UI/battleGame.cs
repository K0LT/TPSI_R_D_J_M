
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
            UpdateAttackButtonLabels();
            _battleEnergy = 100;
            progressBar_battleGame_MyMonsterEnergy.Maximum = 100;
            progressBar_battleGame_MyMonsterEnergy.Value = _battleEnergy;
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
                pictureBox_battleGame_myMonster.Image = image;
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
        public void UpdateMonsterImage(bool isHurt)
        {
            if (Monster == null)
                return;

            int stage = Monster.Level < 5 ? 1 : Monster.Level < 10 ? 2 : 3;
            string type = Monster.Type?.ToLower() ?? "";
            string state = isHurt ? "hurt" : "battle";
            string resourceName = $"{type}_stage{stage}_{state}";

            var imageObj = Resources.ResourceManager.GetObject(resourceName);
            pictureBox_battleGame_myMonster.Image = ConvertByteArrayToImage(imageObj as byte[]);
        }




        public async void FlashHurtImageMonster()
        {
            UpdateMonsterImage(true);
            await Task.Delay(1000);

            UpdateMonsterImage(false);
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
        private int _battleEnergy = 100;

        private void button_Battle_Attack1_Click(object sender, EventArgs e)
        {
            const int energyCost = 10;
            if (_battleEnergy < energyCost)
            {
                DoBossCounterAttack();
                IncreasePlayerEnergy(20);
                ShowTemporaryMessage("Not enough energy! The boss attacks you for 10 HP!");
                return;
            }
            _battleEnergy -= energyCost;
            progressBar_battleGame_MyMonsterEnergy.Value = _battleEnergy;

            if (_rng.NextDouble() <= 0.80)
            {
                int damage = GetAttackDamage(10);
                boss.HealthPoints -= damage;
                if (boss.HealthPoints < 0) boss.HealthPoints = 0;
                progressBar_battleGame_BossHP.Value = boss.HealthPoints;

                if (boss.HealthPoints == 0 && Monster != null && Monster.HealthPoints!=0)
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
                ShowTemporaryMessage("Your attack missed!");
            }
        }

        private void button_Battle_Attack2_Click(object sender, EventArgs e)
        {
            const int energyCost = 25;
            if (_battleEnergy < energyCost)
            {
                DoBossCounterAttack();
                IncreasePlayerEnergy(50);
                ShowTemporaryMessage ("Not enough energy! The boss attacks you for 10 HP.");
                return;
            }
            _battleEnergy -= energyCost;
            progressBar_battleGame_MyMonsterEnergy.Value = _battleEnergy;

            if (_rng.NextDouble() <= 0.80)
            {
                int damage = GetAttackDamage(25);
                boss.HealthPoints -= damage;
                if (boss.HealthPoints < 0) boss.HealthPoints = 0;
                progressBar_battleGame_BossHP.Value = boss.HealthPoints;

                if (boss.HealthPoints == 0 && Monster != null && Monster.HealthPoints != 0)
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
                ShowTemporaryMessage ("Your attack missed!");
            }
        }

        private void IncreasePlayerEnergy(int amount)
        {
            _battleEnergy += amount;
            if (_battleEnergy > 100) _battleEnergy = 100;
            progressBar_battleGame_MyMonsterEnergy.Value = _battleEnergy;
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
            if (Monster != null && boss.HealthPoints!=0)
            {
                Monster.HealthPoints -= damage;
                if (Monster.HealthPoints < 0) Monster.HealthPoints = 0;
                FlashHurtImageMonster();


                if (Monster.HealthPoints == 0)
                {
                    ShowMessageAndNavigate("Your monster has been defeated!", "Defeat");
                }
                else if (showMessage)
                {
                    ShowTemporaryMessage(($"The boss counterattacked and dealt {damage} damage to your monster!"));
                }
            }
        }


        private void UpdateAttackButtonLabels()
        {
            if (Monster == null)
                return;

            int stage = Monster.Level < 5 ? 1 : Monster.Level < 10 ? 2 : 3;
            string type = Monster.Type?.ToLower() ?? "";
            string typeStage = $"{type}_stage{stage}";

            string attack1 = "Attack 1";
            string attack2 = "Attack 2";

            switch (typeStage)
            {
                case "draco_stage1":
                    attack1 = "Roar";
                    attack2 = "Flame Burst";
                    break;
                case "draco_stage2":
                    attack1 = "Fire Bitte";
                    attack2 = "Blaze";
                    break;
                case "draco_stage3":
                    attack1 = "Giga Flame";
                    attack2 = "Golden Flame";
                    break;
                case "grifo_stage1":
                    attack1 = "Peek";
                    attack2 = "Scratch";
                    break;
                case "grifo_stage2":
                    attack1 = "Fly";
                    attack2 = "Whip";
                    break;
                case "grifo_stage3":
                    attack1 = "Tornado";
                    attack2 = "Suicide Dive";
                    break;
                case "tauro_stage1":
                    attack1 = "Head Butt";
                    attack2 = "Moo";
                    break;
                case "tauro_stage2":
                    attack1 = "Iron Horn";
                    attack2 = "Stomp";
                    break;
                case "tauro_stage3":
                    attack1 = "Iron Tackle";
                    attack2 = "Meteor Spear";
                    break;
                case "siren_stage1":
                    attack1 = "Frost Bite";
                    attack2 = "Bubbles";
                    break;
                case "siren_stage2":
                    attack1 = "Surf";
                    attack2 = "Blizzard";
                    break;
                case "siren_stage3":
                    attack1 = "Tsunami";
                    attack2 = "Scream";
                    break;
                default:
                    attack1 = "Quick Strike";
                    attack2 = "Power Hit";
                    break;
            }

            button_Battle_Attack1.Text = attack1;
            button_Battle_Attack2.Text = attack2;
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


       
    

    private async void ShowTemporaryMessage(string text)
        {
            label_Message.Text = text;
            label_Message.Visible = true;

            await Task.Delay(2500); 

            label_Message.Visible = false;
        }
    }
}

