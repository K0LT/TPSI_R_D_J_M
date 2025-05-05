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
        private MonsterProgress _monsterProgress;
        
        private BindingSource _userBindingSource;

        private BindingSource _monsterTypeBindingSource;

        public StartupForm()
        {
            InitializeComponent();
            
            _userBindingSource = new BindingSource();

            _monsterTypeBindingSource = new BindingSource();

            _monsterProgress = new MonsterProgress();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize UI components
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            MonsterBarProgressManager.InitializeMonsterProgressBar(expBar);
            FormUIInitializer.InitMainMenuButtons(newgame, loadgame, settings, exit, credit);

            // Bind monster progress to the progress bar
            MonsterBarProgressManager.UpdateMonsterProgressBar(expBar, _monsterProgress);


            panelFirstRegister.Visible = false;  // registo player escondido
            nextRegister.Visible = false;   // botao de next em registo de player
            panelNextMonsterName.Visible = false; // botao next depois de colocar nome do monstro
        }

        // Main menu button handlers
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



        // New game player menu handlers
        private void exitButtonNewGamePlayer_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);

        }
        private void PlayerBoy_CheckedChanged(object sender, EventArgs e)
        {
            panelFirstRegister.Visible = PlayerBoy.Checked;
        }

        private void PlayerGirl_CheckedChanged(object sender, EventArgs e)
        {
            panelFirstRegister.Visible = PlayerGirl.Checked;
        }

        private void registerplayer_Click(object sender, EventArgs e)
        {
            string username = usernameRegister.Text.Trim();
            string playerType = GetSelectedPlayerType();

            if (string.IsNullOrWhiteSpace(username))
            {
                usernameRegisterMessage.Text = "[ERROR] Username cannot be empty.";
                return;
            }

            if (string.IsNullOrWhiteSpace(playerType))
            {
                usernameRegisterMessage.Text = "[ERROR] Please select a player type.";
                return;
            }

            // Register the user and bind to the UI
            User newUser = UserManager.RegisterUserAndReturn(username, playerType);
            if (newUser != null)
            {
                BindUserToUI(newUser);
                HandleSuccessfulRegistration(newUser);
            }
            else
            {
                usernameRegisterMessage.Text = "[ERROR] This username already exists or is invalid.";
            }

            nextRegister.Visible = true;
            registerplayer.Enabled = false;
        }

        private string GetSelectedPlayerType()
        {
            if (PlayerBoy.Checked)
                return "boy";
            if (PlayerGirl.Checked)
                return "girl";
            return string.Empty;
        }

        private void HandleSuccessfulRegistration(User user)
        {
            usernameRegisterMessage.Text = "User registered successfully!";
            nextRegister.Visible = true;
            registerplayer.Enabled = false;

            // Store the current user in the session
            Session.CurrentUser = user.Username;
        }

        private void BindUserToUI(User user)
        {
            // Bind the user object to the BindingSource
            _userBindingSource.DataSource = user;

            // Bind UI controls to the user properties
            usernameRegister.DataBindings.Clear();
            usernameRegister.DataBindings.Add("Text", _userBindingSource, "Username");

            // Example: Bind other UI elements if needed
            // playerTypeLabel.DataBindings.Add("Text", _userBindingSource, "PlayerType");
        }

        private void nextRegister_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, NewGameMonster);
        }



        // General Purpose Type Selector
        private void monsterTypeSelect(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string monsterType = button.Text.Trim().ToLower();

                _monsterTypeBindingSource.DataSource = monsterType;

                panelMonsterName.Visible = true;
            }
        }

        // Monster selection handlers
        private void dracoselect_Click(object sender, EventArgs e)
        {
            monsterTypeSelect(sender,EventArgs.Empty);
        }

        private void grifoselect_Click(object sender, EventArgs e)
        {
            monsterTypeSelect(sender, EventArgs.Empty);
        }

        private void tauroselect_Click(object sender, EventArgs e)
        {
            monsterTypeSelect(sender, EventArgs.Empty);
        }

        private void sirenselect_Click(object sender, EventArgs e)
        {
            monsterTypeSelect(sender, EventArgs.Empty);
        }

        private void SelectMonsterType(string monsterType)
        {
            _monsterTypeBindingSource.DataSource = monsterType; // Update the BindingSource
            panelMonsterName.Visible = true; // Show the panel for entering the monster name
        }

        private void MonsterRegister_Click(object sender, EventArgs e)
        {
            string monsterName = monsterNameBox.Text.Trim();
            string selectedMonsterType = _monsterTypeBindingSource.Current as string;
            string currentUser = Session.CurrentUser;

            if (string.IsNullOrWhiteSpace(monsterName) || string.IsNullOrWhiteSpace(selectedMonsterType))
            {
                MessageBox.Show("Please provide a monster name and select a monster type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MonsterManager.RegisterMonster(currentUser, selectedMonsterType, monsterName);
            MessageBox.Show($"Monster '{monsterName}' of type '{selectedMonsterType}' has been successfully registered!",
                "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nextMonsterName_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, TutorialTab);
            MonsterRegister_Click(this, EventArgs.Empty);
        }
        private void exitButtonNewGameMonster_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);
        }


        // Tutorial navigation
        private void exitButtonTutorial_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);
        }
        private void letsPlay_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, myMonster);
        }



        // Monster page handlers

        private void exitButtonMyMonster_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);
        }

        private void saveButtonMyMonster_Click(object sender, EventArgs e)
        {
            
        }

        private void boyPicturemall_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Player);
        }

        private void girlPixelPic_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Player);
        }
        
        private void controllerPicture_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, miniGames);

        }
        private void backpackPic_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, inventory);
        }

        private void battleButtonPic_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, battleMode);
        }

        private void foodPicture_Click(object sender, EventArgs e)
        {
            // TODO: Implement food interaction logic
        }






        // Load game handlers
        private void usernameEnterLoad_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement logic for loading game based on username input
        }

        private void exitButtonLoadGame_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);
        }

        private void Player1_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Player);
        }

        private void Exit1_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);
        }

        
        
        
        // Player menu handlers



    

        private void Inventory1_Click(object sender, EventArgs e)
        {
            // TODO: Implement inventory logic
        }

        private void Games1_Click(object sender, EventArgs e)
        {
            // TODO: Implement games logic
        }

        private void Shop1_Click(object sender, EventArgs e)
        {
            // TODO: Implement shop logic
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            // TODO: Implement save logic
        }

        private void Exit2_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);
        }

      


        // Settings handles
        private void exitButtonSettings_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);
        }

        // Credit handles
        private void exitButtonCredits_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);
        }

        
    }
}
