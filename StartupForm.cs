using System;
using System.Drawing;
using System.Windows.Forms;

// We MUST include our class library
using Monster.Core;
using static System.Collections.Specialized.BitVector32;

namespace Monster
{
    public partial class StartupForm : Form
    {
        MonsterProgress monsterProgress;
        public StartupForm()
        {
            InitializeComponent();

            monsterProgress = new MonsterProgress();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MonsterBarProgressManager.InitializeMonsterProgressBar(expBar);

            FormUIInitializer.InitMainMenuButtons(newgame, loadgame, settings, exit, credit);
            //FormUIInitializer.InitMonsterMenuButtons(changeName2, feed2, play2, sleep1, inventory2, save2, exitbutton2, evolve, status, MyMonsters2, MyBackpack1, Games1, Shop1, Achievements, Save1, Exit2);
            MonsterBarProgressManager.UpdateMonsterProgressBar(expBar, monsterProgress);
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

        /*private void registerplayer_Click(object sender, EventArgs e)
        {
            string user = usernameRegisterMessage.Text.Trim();
            string playerType = "";

            if (PlayerBoy.Checked)
            {
                playerType = "boy";
            }
            else if (PlayerGirl.Checked)
            {
                playerType = "girl";
            }

            if (UserManager.RegisterUser(user, playerType))
            {
                usernameRegisterMessage.Text = "User registered successfully!";

                nextRegister.Visible = true;
                registerplayer.Enabled = false;
                Session.CurrentUser = user;
            }
            else
            {
                usernameRegisterMessage.Text = "[ERROR] This username already exists or is invalid";
            }
        }*/

        private void registerplayer_Click(object sender, EventArgs e)
        {
            string user = usernameRegisterMessage.Text.Trim();
            string playerType = GetSelectedPlayerType();

            if (string.IsNullOrWhiteSpace(user))
            {
                usernameRegisterMessage.Text = "[ERROR] Username cannot be empty.";
                return;
            }

            if (string.IsNullOrWhiteSpace(playerType))
            {
                usernameRegisterMessage.Text = "[ERROR] Please select a player type.";
                return;
            }

            if (UserManager.RegisterUser(user, playerType))
            {
                HandleSuccessfulRegistration(user);
            }
            else
            {
                usernameRegisterMessage.Text = "[ERROR] This username already exists or is invalid.";
            }

            MessageBox.Show($"Player of type '{selectedMonsterType}' has been successfully registered!",
                "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetSelectedPlayerType()
        {
            if (PlayerBoy.Checked)
            {
                return "boy";
            }
            else if (PlayerGirl.Checked)
            {
                return "girl";
            }
            return string.Empty;
        }

        private void HandleSuccessfulRegistration(string user)
        {
            usernameRegisterMessage.Text = "User registered successfully!";
            nextRegister.Visible = true;
            registerplayer.Enabled = false;
            Session.CurrentUser = user;
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

        private string user;
        private void buttonRegisterMonster_Click(object sender, EventArgs e)
        {
            string monsterName = monsterNameBox.Text.Trim();
            string currentUser = Session.CurrentUser;

            if (string.IsNullOrWhiteSpace(monsterName) || string.IsNullOrWhiteSpace(selectedMonsterType))
            {
                return; 
            }

            
            MonsterManager.RegisterMonster(currentUser, selectedMonsterType, monsterName);
        }

        private void nextMonsterName_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, TutorialTab);
            buttonRegisterMonster_Click(this, EventArgs.Empty);
        }




        // void tutorial

        private void letsPlay_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, myMonster);

        }



        // void pagina load game

        private void usernameEnterLoad_TextChanged(object sender, EventArgs e)
        {

        }








        //voids botoes Load Game
        private void myMonsters1_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, monsterColection);
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
            TabNavigator.SwitchTo(Monsters, monsterColection);
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

        private void foodPicture_Click(object sender, EventArgs e)
        {
            // TODO: implement
        }

        private void MonsterRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedMonsterType))
            {
                MessageBox.Show("Please select a monster type before registering.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            string monsterName = monsterNameBox.Text.Trim();
            string currentUser = Session.CurrentUser;
            
            MonsterManager.RegisterMonster(currentUser, selectedMonsterType, monsterName);
            
            MessageBox.Show($"Monster of type '{selectedMonsterType}' has been successfully registered!",
                "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //voids botoes menu My Monster

        //voids para a imagem / descricao funcionarem




        // calcular o progresso



        //Atualiza os stats 
        /*private void UpdateAttributeLabels()
        {

            lblLevel.Text = "Lvl: " + monsterProgress.Level;
            lblStamina.Text = "Stamina: " + monsterProgress.Stamina;
            lblAttack.Text = "Attack: " + monsterProgress.Attack;
            lblExp.Text = "Exp: " + monsterProgress.Exp;
        }*/


    }
}
