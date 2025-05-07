using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;


namespace Monster.UI.Forms
{
    public partial class StartupForm : Form
    {
        private readonly GameNavigationManager _navigationManager;
        private readonly MonsterUIUpdater _monsterUIUpdater;
        private readonly GamePresenter _gamePresenter;
        private readonly GameDataService _gameDataService;

        // Constants
        private const string ErrorTitle = "Error";
        private const string SuccessTitle = "Registration Successful";
        private const string ValidationErrorMessage = "Please provide a monster name and select a monster type.";
        private const string ExitConfirmationMessage = "Are you sure you want to exit? Any unsaved progress will be lost.";

        public StartupForm()
        {
            Console.WriteLine("[DEBUG] StartUpForm Constructor call.");
            InitializeComponent();

            // Initialize services
            _gameDataService = new GameDataService();

            // Setup navigation
            _navigationManager = InitializeNavigationManager();

            // Setup UI updaters
            _monsterUIUpdater = new MonsterUIUpdater(
                expBar, hungerBar, energyBar, monsterPictureBox, monsterNameLabel);

            // Setup presenters
            _gamePresenter = new GamePresenter(this, _gameDataService);

            // Initialize data bindings
            InitializeBindings();
        }

        private GameNavigationManager InitializeNavigationManager()
        {
            var screenMap = new Dictionary<GameNavigationManager.GameScreen, TabPage>
            {
                { GameNavigationManager.GameScreen.Home, Home },
                { GameNavigationManager.GameScreen.NewGame, NewGamePlayer },
                { GameNavigationManager.GameScreen.LoadGame, LoadGamePage },
                { GameNavigationManager.GameScreen.Monster, myMonster },
                { GameNavigationManager.GameScreen.Inventory, inventory },
                { GameNavigationManager.GameScreen.Battle, battleMode },
                { GameNavigationManager.GameScreen.Settings, SettingsPage },
                { GameNavigationManager.GameScreen.Credits, Credits },
                { GameNavigationManager.GameScreen.Tutorial, TutorialTab }
            };

            return new GameNavigationManager(Monsters, screenMap);
        }

        private void InitializeBindings()
        {
            // Create binding sources
            userBindingSource = new BindingSource();
            monsterBindingSource = new BindingSource();
            monsterTypeBindingSource = new BindingSource();

            // Create and bind creation state objects
            var monsterCreationState = new MonsterCreationState();
            monsterTypeBindingSource.DataSource = monsterCreationState;

            // Bind text inputs
            monsterNameBox.DataBindings.Add("Text", monsterTypeBindingSource, "MonsterName");

            // Initialize game state
            _gamePresenter.InitializeNewGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Hide tab headers for navigation control
            Monsters.Appearance = TabAppearance.FlatButtons;
            Monsters.ItemSize = new System.Drawing.Size(0, 1);
            Monsters.SizeMode = TabSizeMode.Fixed;

            // Initialize UI elements
            InitializeUIElements();

            // Navigate to home screen
            _navigationManager.NavigateTo(GameNavigationManager.GameScreen.Home);
        }

        private void InitializeUIElements()
        {
            // Initialize progress bars
            _monsterUIUpdater.InitializeProgressBars();

            // Initialize buttons
            FormUIInitializer.InitMainMenuButtons(newgame, loadgame, settings, exit, credit);

            // Hide navigation buttons initially
            nextRegister.Visible = false;
            nextMonsterName.Visible = false;
            panelFirstRegister.Visible = false;
            panelMonsterName.Visible = false;
        }

        #region IGameView Implementation

        // Implementation of the view interface methods used by presenters
        public void ShowError(string message)
        {
            MessageService.ShowError(message);
        }

        public void ShowInfo(string message, string title)
        {
            MessageService.ShowInfo(message, title);
        }

        public bool ShowConfirmation(string message, string title)
        {
            return MessageService.ShowConfirmation(message, title);
        }

        public void UpdateMonsterUI(Monster monster)
        {
            _monsterUIUpdater.UpdateFromMonster(monster);
        }

        public void NavigateTo(GameNavigationManager.GameScreen screen)
        {
            _navigationManager.NavigateTo(screen);
        }

        #endregion

        #region Main Menu Event Handlers

        private void newgame_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.NewGame);
        }

        private void loadgame_Click(object sender, EventArgs e)
        {
            // Populate saved games list
            var savedGames = _gameDataService.GetSavedGames();
            savedGamesListBox.DataSource = savedGames;

            NavigateTo(GameNavigationManager.GameScreen.LoadGame);
        }

        private void settings_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Settings);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if (ShowConfirmation(ExitConfirmationMessage, "Exit Game"))
            {
                Application.Exit();
            }
        }

        private void credit_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Credits);
        }

        #endregion

        #region Player Creation Event Handlers

        private void exitButtonNewGamePlayer_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Home);
            ResetPlayerSelectionUI();
        }

        private void ResetPlayerSelectionUI()
        {
            PlayerBoy.Checked = false;
            PlayerGirl.Checked = false;
            panelFirstRegister.Visible = false;
            usernameRegister.Text = string.Empty;
            usernameRegisterMessage.Text = string.Empty;
            nextRegister.Visible = false;
            registerplayer.Enabled = true;
        }

        private void PlayerBoy_CheckedChanged(object sender, EventArgs e)
        {
            panelFirstRegister.Visible = PlayerBoy.Checked || PlayerGirl.Checked;

            if (PlayerBoy.Checked)
            {
                _gamePresenter.SetPlayerType("boy");
            }
        }

        private void PlayerGirl_CheckedChanged(object sender, EventArgs e)
        {
            panelFirstRegister.Visible = PlayerBoy.Checked || PlayerGirl.Checked;

            if (PlayerGirl.Checked)
            {
                _gamePresenter.SetPlayerType("girl");
            }
        }

        private void registerplayer_Click(object sender, EventArgs e)
        {
            var username = usernameRegister.Text.Trim();
            var playerType = PlayerBoy.Checked ? "boy" : (PlayerGirl.Checked ? "girl" : string.Empty);

            if (_gamePresenter.RegisterPlayer(username, playerType))
            {
                usernameRegisterMessage.Text = "User registered successfully!";
                nextRegister.Visible = true;
                registerplayer.Enabled = false;
            }
            else
            {
                // Error message will be shown by the presenter
            }
        }

        private void nextRegister_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.NewGame);
        }

        #endregion

        #region Monster Creation Event Handlers

        private void monsterTypeSelect(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                var monsterType = button.Text.Trim().ToLower();
                _gamePresenter.SetMonsterType(monsterType);
                panelMonsterName.Visible = true;
            }
        }

        private void dracoselect_Click(object sender, EventArgs e)
        {
            monsterTypeSelect(sender, e);
        }

        private void grifoselect_Click(object sender, EventArgs e)
        {
            monsterTypeSelect(sender, e);
        }

        private void tauroselect_Click(object sender, EventArgs e)
        {
            monsterTypeSelect(sender, e);
        }

        private void sirenselect_Click(object sender, EventArgs e)
        {
            monsterTypeSelect(sender, e);
        }

        private void MonsterRegister_Click(object sender, EventArgs e)
        {
            var monsterName = monsterNameBox.Text.Trim();

            if (_gamePresenter.RegisterMonster(monsterName))
            {
                nextMonsterName.Visible = true;
            }
        }

        private void nextMonsterName_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Tutorial);
        }

        private void exitButtonNewGameMonster_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Home);
        }

        #endregion

        #region Tutorial Event Handlers

        private void exitButtonTutorial_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Home);
        }

        private void letsPlay_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Monster);

            // Load the player's monster data
            _gamePresenter.LoadCurrentMonsterData();
        }

        #endregion

        #region Monster Management Event Handlers

        private void exitButtonMyMonster_Click(object sender, EventArgs e)
        {
            if (ShowConfirmation(ExitConfirmationMessage, "Exit Game"))
            {
                NavigateTo(GameNavigationManager.GameScreen.Home);
            }
        }

        private void saveButtonMyMonster_Click(object sender, EventArgs e)
        {
            _gamePresenter.SaveGame();
        }

        private void foodPicture_Click(object sender, EventArgs e)
        {
            _gamePresenter.FeedCurrentMonster();
        }

        private void sleepButton_Click(object sender, EventArgs e)
        {
            _gamePresenter.RestCurrentMonster();
        }

        #endregion

        #region Navigation Event Handlers

        private void boyPicturemall_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Player);
        }

        private void girlPixelPic_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Player);
        }

        private void controllerPicture_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.MiniGames);
        }

        private void backpackPic_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Inventory);
        }

        private void battleButtonPic_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Battle);
        }

        #endregion

        #region Load Game Event Handlers

        private void loadGameButton_Click(object sender, EventArgs e)
        {
            var selectedUsername = savedGamesListBox.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedUsername))
            {
                ShowError("Please select a saved game to load.");
                return;
            }

            if (_gamePresenter.LoadGame(selectedUsername))
            {
                NavigateTo(GameNavigationManager.GameScreen.Monster);
            }
        }

        private void exitButtonLoadGame_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Home);
        }

        #endregion

        #region Player Menu Event Handlers

        private void exitPlayerMenuPicture_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Monster);
        }

        #endregion

        #region Mini Games Event Handlers

        private void exitButtonMiniGames_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Monster);
        }

        #endregion

        #region Inventory Event Handlers

        private void exitButtonIventory_Click_1(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Monster);
        }

        private void Shop1_Click(object sender, EventArgs e)
        {
            _gamePresenter.OpenShop();
        }

        private void Save1_Click(object sender, EventArgs e)
        {
            _gamePresenter.SaveGame();
        }

        #endregion

        #region Battle Mode Event Handlers

        private void exitButtonBattleMode_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Monster);
        }

        #endregion

        #region Settings Event Handlers

        private void exitButtonSettings_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Home);
        }

        #endregion

        #region Credits Event Handlers

        private void exitButtonCredits_Click(object sender, EventArgs e)
        {
            NavigateTo(GameNavigationManager.GameScreen.Home);
        }

        #endregion
    }
}