using System;
using System.ComponentModel;
using System.Windows.Forms;
using Monster.Core;

namespace Monster
{
    public partial class StartupForm : Form
    {
        // Consts we can use in more than one try-catch block consistently
        private const string ErrorTitle = "Error";
        private const string SuccessTitle = "Registration Successful";
        private const string ValidationErrorMessage = "Please provide a monster name and select a monster type.";

        private readonly MonsterCreationState _monsterCreationState;
        private readonly MonsterProgress _monsterProgress;

        private readonly BindingSource _monsterTypeBindingSource;

        private readonly BindingSource _userBindingSource;

        public StartupForm()
        {
            InitializeComponent();

            _userBindingSource = new BindingSource();

            _monsterTypeBindingSource = new BindingSource();

            _monsterProgress = new MonsterProgress();

            _monsterCreationState = new MonsterCreationState();

            _monsterTypeBindingSource.DataSource = _monsterCreationState;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize UI components
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            MonsterBarProgressManager.InitializeMonsterProgressBar(expBar);
            FormUIInitializer.InitMainMenuButtons(newgame, loadgame, settings, exit, credit);

            // Bind monster progress to the progress bar
            MonsterBarProgressManager.UpdateMonsterProgressBar(expBar, _monsterProgress);


            //TODO: Colocar estas pre-definiçoes no form initializer 


            panelFirstRegister.Visible = false; // registo player escondido
            nextRegister.Visible = false; // botao de next em registo de player
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

        //TODO: colocar messageBox em vez de textBox nas mensagens de erro/sucesso

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
            var username = usernameRegister.Text.Trim();
            var playerType = GetSelectedPlayerType();

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
            var newUser = UserManager.RegisterUserAndReturn(username, playerType);
            if (newUser != null)
            {
                BindUserToUI(newUser);
                HandleSuccessfulRegistration(newUser);
            }
            else
            {
                usernameRegisterMessage.Text = "[ERROR] This username already exists or is invalid.";
            }
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
            // TODO: tabs myMonster (gender) | playerMenu bindings 
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
                var monsterType = button.Text.Trim().ToLower();

                _monsterTypeBindingSource.DataSource = monsterType;

                panelMonsterName.Visible = true;
            }
        }

        // Monster selection handlers
        // TODO: Não esta a dar para selecionar e registar o nome do monster.
        //TODO: colocar messageBox em vez de textBox nas mensagens de erro/sucesso

        private void dracoselect_Click(object sender, EventArgs e)
        {
            monsterTypeSelect(sender, EventArgs.Empty);
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
            if (string.IsNullOrEmpty(monsterType))
                throw new ArgumentNullException(nameof(monsterType));

            _monsterCreationState.SelectedType = monsterType;
            panelMonsterName.Visible = true;
        }


        private void MonsterRegister_Click(object sender, EventArgs e)
        {
            var monsterName = monsterNameBox.Text.Trim();
            var selectedMonsterType = _monsterTypeBindingSource.Current as string;
            var currentUser = Session.CurrentUser;

            if (!IsValidMonsterInput(monsterName, selectedMonsterType))
            {
                ShowValidationError();
                return;
            }

            MonsterManager.RegisterMonster(currentUser, selectedMonsterType, monsterName);
            ShowRegistrationSuccess(monsterName, selectedMonsterType);
        }

        private bool IsValidMonsterInput(string monsterName, string monsterType)
        {
            return !string.IsNullOrWhiteSpace(monsterName) && !string.IsNullOrWhiteSpace(monsterType);
        }

        private void ShowValidationError()
        {
            MessageBox.Show(ValidationErrorMessage, ErrorTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowRegistrationSuccess(string monsterName, string monsterType)
        {
            var successMessage = $"Monster '{monsterName}' of type '{monsterType}' has been successfully registered!";
            MessageBox.Show(successMessage, SuccessTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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


        // Tutorial handlers
        // TODO: fazer todo o tutorial


        private void exitButtonTutorial_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);
        }

        private void letsPlay_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, myMonster);
        }


        // Monster page handlers
        //TODO: Colocar o icon de noodles e sleep a cumprir as suas funçoes;
        //TODO: Atualizar as progress bars, tanto a nivel de status como a nivel de design;
        //TODO: Atualizar a imagem e nome do monster que foi selecionado e que esta a jogar atualmente;


        private void exitButtonMyMonster_Click(object sender, EventArgs e)
        {
            // TODO: Colocar pop up de confirmaçao que quer sair pois irá sair do jogo por completo
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
        // TODO: Editar melhor esteticamente, colocar o botão a funcionar para ir buscar ao ficheiro json o user ja existente
        private void usernameEnterLoad_TextChanged(object sender, EventArgs e)
        {
            // TODO: Implement logic for loading game based on username input
        }

        private void exitButtonLoadGame_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, Home);
        }


        //Player Menu Handlers
        //TODO: Atualizar os achievements e ao selecionar o monstro, confirmar se aparece com os status / Nome /imagem atualizados

        private void exitPlayerMenuPicture_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, myMonster);
        }


        // Player menu handlers


        // Mini Games handlers
        // TODO: Inserir mini jogos

        private void exitButtonMiniGames_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, myMonster);
        }


        // Iventory handlers
        //TODO: Criar inventario / imagens 
        private void exitButtonIventory_Click_1(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, myMonster);
        }

        private void Shop1_Click(object sender, EventArgs e)
        {
            // TODO: Implement shop logic
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            // TODO: Implement save logic
        }

        // Battle Mode Handlers
        //TODO: Criar battle mode / imagens 
        private void exitButtonBattleMode_Click(object sender, EventArgs e)
        {
            TabNavigator.SwitchTo(Monsters, myMonster);
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

        public class MonsterCreationState : INotifyPropertyChanged
        {
            private string _selectedType;

            public string SelectedType
            {
                get => _selectedType;
                set
                {
                    if (_selectedType != value)
                    {
                        _selectedType = value;
                        OnPropertyChanged(nameof(SelectedType));
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}