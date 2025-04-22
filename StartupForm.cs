using System;
using System.Windows.Forms;

// We MUST include our class library
using Monster.Core;

namespace Monster
{
    public partial class StartupForm : Form
    {
        MonsterProgress monsterProgress;
        public StartupForm()
        {
            InitializeComponent();

            // Including our class model, where we will gather and store data from
            monsterProgress = new MonsterProgress();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MonsterBarProgressManager.InitializeMonsterProgressBar(progressBarDraco);

            FormUIInitializer.InitMainMenuButtons(newgame, loadgame, settings, exit, credit);
            FormUIInitializer.InitMonsterMenuButtons(changeName2, feed2, play2, sleep1, inventory2, save2, exitbutton2, evolve, status, MyMonsters2, MyBackpack1, Games1, Shop1, Achievements, Save1, Exit2);

            UIStyler.InitializeUI(this, Monsters);

            UIStyler.InitializeVisibilityAndSecurity(descricao1, panelFirstRegister, nextRegister, panelNextMonsterName, textBoxPassword);

            ImageDescriptionBinder.Bind(draco, descricao1);
            ImageDescriptionBinder.Bind(grifo, descricao2);
            ImageDescriptionBinder.Bind(tauro, descricao3);
            ImageDescriptionBinder.Bind(siren, descricao4);

            // Example of how we can generalize the progress bar logic to fit any monster object/ progress bar
            MonsterBarProgressManager.UpdateMonsterProgressBar(progressBarDraco, monsterProgress);
        }

        //voids botoes de menu principal
        private void newgame_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, NewGamePlayer);
        }

        private void loadgame_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, LoadGamePage);
        }

        private void settings_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, SettingsPage);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void credit_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Credits);
        }

        //voids botoes de menu new game player

        private void PlayerBoy_CheckedChanged(object sender, EventArgs e)
        {
            panelFirstRegister.Visible = PlayerBoy.Checked;

        }

        private void PlayerGirl_CheckedChanged(object sender, EventArgs e)
        {
            panelFirstRegister.Visible = PlayerGirl.Checked;

        }

        private void nextRegister_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, NewGameMonster);
        }

        private string selectedMonsterType;

        private void dracoselect_Click(object sender, EventArgs e)
        {
            selectedMonsterType = "draco";
            panelMonsterName.Visible = true;
        }

        private void grifoselect_Click(object sender, EventArgs e)
        {
            selectedMonsterType = "grifo";
            panelMonsterName.Visible = true;
        }

        private void tauroselect_Click(object sender, EventArgs e)
        {
            selectedMonsterType = "tauro";
            panelMonsterName.Visible = true;
        }

        private void sirenselect_Click(object sender, EventArgs e)
        {
            selectedMonsterType = "siren";
            panelMonsterName.Visible = true;
        }

        private void nextMonsterName_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Beginning);


        }

        private void Next_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Beginning);

        }

        // voids menu First Monster

        //voids botoes Load Game
        private void myMonsters1_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, MyMonsters);
        }

        private void Player1_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Player);
        }

        private void Exit1_Click(object sender, EventArgs e)
        {
            // Fazer confirmaçao se quer sair e se sim, se quer salvar o jogo
            TabNavigator.SwitchTo(Monsters, Home);
        }

        //voids botoes menu Player
        private void MyMonsters2_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, MyMonsters);
        }

        private void Inventory1_Click(object sender, EventArgs e)
        {

        }

        private void Games1_Click(object sender, EventArgs e)
        {

        }

        private void Shop1_Click(object sender, EventArgs e)
        {

        }

        private void Save1_Click(object sender, EventArgs e)
        {

        }

        private void Exit2_Click(object sender, EventArgs e)
        {
            // Fazer confirmaçao se quer sair e se sim, se quer salvar o jogo
            TabNavigator.SwitchTo(Monsters, Home);
        }


        //voids botoes menu My Monster

        //voids para a imagem / descricao funcionarem

        private void UpdateTextBoxVisibility(bool isVisible)
        {
            descricao1.Visible = isVisible;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateTextBoxVisibility(false);
        }
        private void draco_MouseEnter(object sender, EventArgs e)
        {
            UpdateTextBoxVisibility(true);
        }
        private void draco_MouseLeave(object sender, EventArgs e)
        {
            UpdateTextBoxVisibility(false);
        }
        private void tabPage1_Click_1(object sender, EventArgs e)
        {


        }

        // calcular o progresso
        


        //Atualiza os stats 
        private void UpdateAttributeLabels()
        {

            lblLevel.Text = "Lvl: " + monsterProgress.Level;
            lblStamina.Text = "Stamina: " + monsterProgress.Stamina;
            lblAttack.Text = "Attack: " + monsterProgress.Attack;
            lblExp.Text = "Exp: " + monsterProgress.Exp;
        }  
    }
}
