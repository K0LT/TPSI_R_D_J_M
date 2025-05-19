using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Monster.Core.Models;
using Monster.Game.GameState;
using static System.Windows.Forms.AxHost;
namespace Monster.UI
{
    public partial class Form1 : Form
    {
        // Binding Sources
        private BindingSource _bsMonster = new BindingSource();
        private BindingSource _bsUser = new BindingSource();

        // Game State / Game Data
        private GameState _gameState = new GameState();
        private GameDataService _gameDataService = new GameDataService();

        // Dictionary to track all our UserControls
        private Dictionary<string, UserControl> _userControls = new Dictionary<string, UserControl>();
        private bool _isNewUser = true;

        public Form1()
        {
            System.Diagnostics.Debug.WriteLine(@"[DEBUG-Form1] Constructor Call");

            InitializeComponent();
            System.Diagnostics.Debug.WriteLine(@"Form 1 Component Init Passed.");

            // Initialize all UserControls
            InitializeUserControls();
            System.Diagnostics.Debug.WriteLine(@"Initialize User Controlls Call Passed.");

            _gameState.OwnedMonsters.Add(_gameState.ActiveMonster);

            // Set up global binding sources
            SetupBindings(_gameState, _bsMonster, _bsUser);



            // Show initial UserControl
            NavigateTo("MainMenu");

        }

        private void InitializeUserControls()
        {
            // Create and initialize each UserControl
            myMonster monsterControl = new myMonster();
            inventory inventoryControl = new inventory();
            ticTacToeGame ticTacToeControl = new ticTacToeGame();
            playerMenu playerMenuControl = new playerMenu(_gameState.CurrentUser.UserType);
            newGamePlayer newUserControl = new newGamePlayer();
            newGameMonster newMonsterControl = new newGameMonster();
            mainMenu mainMenu = new mainMenu();
            loadGame loadGame = new loadGame();
            miniGamesMenu miniGames = new miniGamesMenu();
            settings settings = new settings();
            credits credits = new credits();
            BattleMenu battleMenu = new BattleMenu();
            battleGame battleGame = new battleGame();
            tutorialfirstPage tutorial1 = new tutorialfirstPage();
            TutorialSecondPage tutorial2 = new TutorialSecondPage();
            tutorialThirdPage tutorial3 = new tutorialThirdPage();
            memoryGame memoryGame = new memoryGame();
            PatternGame patternGame = new PatternGame();


            // Add controls to dictionary with unique keys
            _userControls.Add("MemoryGame", memoryGame);
            _userControls.Add("Monster", monsterControl);
            _userControls.Add("Inventory", inventoryControl);
            _userControls.Add("PatternGame", patternGame);
            _userControls.Add("Player", playerMenuControl);
            _userControls.Add("NewUser", newUserControl);
            _userControls.Add("NewMonster", newMonsterControl);
            _userControls.Add("MainMenu", mainMenu);
            _userControls.Add("LoadGame", loadGame);
            _userControls.Add("MiniGames", miniGames);
            _userControls.Add("Settings", settings);
            _userControls.Add("Credits", credits);
            _userControls.Add("BattleMenu", battleMenu);
            _userControls.Add("BattleGame", battleGame);
            _userControls.Add("Tutorial1", tutorial1);
            _userControls.Add("Tutorial2", tutorial2);
            _userControls.Add("Tutorial3", tutorial3);

        }

        public void NavigateTo(string controlKey)
        {

            MainPanel.Controls.Clear();


            if (_userControls.TryGetValue(controlKey, out UserControl control))
            {
                control.Dock = DockStyle.None;

                MainPanel.Size = control.Size;

                this.ClientSize = MainPanel.Size;

                RefreshControlData(controlKey, control);

                MainPanel.Controls.Add(control);

                System.Diagnostics.Debug.WriteLine($"[DEBUG-Form1] Navigated to {controlKey}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG-Form1] Control not found: {controlKey}");
            }
        }

        private void RefreshControlData(string controlKey, UserControl control)
        {
            // Different controls might need different data refreshed
            switch (controlKey)
            {
                case "MainMenu":
                    var mainMenu = control as mainMenu;
                    if (mainMenu != null)
                    {
                        // Nothing so far
                    }
                    break;
                case "NewUser":
                    var newUser = control as newGamePlayer;
                    if (newUser != null)
                    {
                        // Nothing so far
                    }
                    break;
                case "Monster":
                    var monsterControl = control as myMonster;
                    if (monsterControl != null)
                    {
                        this.SaveGame(true);
                        if (_gameState == null)
                        {
                            MessageBox.Show("User not found", "Load Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            NavigateTo("LoadGame");
                            return;
                        }
                        // Update with latest monster data
                        monsterControl.bsDataSource = _gameState.ActiveMonster;
                        monsterControl.HookBindings();
                    }
                    break;
                case "Inventory":
                    var inventoryControl = control as inventory;
                    if (inventoryControl != null)
                    {
                        inventoryControl.bsDataSource = _gameState.ActiveMonster;
                        inventoryControl.State = _gameState;
                        if (_gameState.Inventory == null || _gameState.Inventory.Count == 0)
                        {
                            _gameState.Inventory = inventoryControl.InitializeInventory();
                        }
                        inventoryControl.bsInventory = _gameState.Inventory;
                        inventoryControl.HookBindings();
                        inventoryControl.HookBindings();
                    }
                    break;

                case "Player":
                    var playerControl = control as playerMenu;
                    if (playerControl != null)
                    {
                        int count = _gameState.OwnedMonsters.Count;
                        switch (count)
                        {
                            default:
                                // TODO: Add try-catch block
                                throw new Exception("EMPTY_MONSTER_COLLECTION");
                                break;
                            case 1:
                                playerControl.bsFirstMonster = _gameState.OwnedMonsters.ElementAt(0);
                                break;
                            case 2:
                                playerControl.bsFirstMonster = _gameState.OwnedMonsters.ElementAt(0);
                                playerControl.bsSecondMonster = _gameState.OwnedMonsters.ElementAt(1);
                                break;
                            case 3:
                                playerControl.bsFirstMonster = _gameState.OwnedMonsters.ElementAt(0);
                                playerControl.bsSecondMonster = _gameState.OwnedMonsters.ElementAt(1);
                                playerControl.bsThirdMonster = _gameState.OwnedMonsters.ElementAt(2);
                                break;
                            case 4:
                                playerControl.bsFirstMonster = _gameState.OwnedMonsters.ElementAt(0);
                                playerControl.bsSecondMonster = _gameState.OwnedMonsters.ElementAt(1);
                                playerControl.bsThirdMonster = _gameState.OwnedMonsters.ElementAt(2);
                                playerControl.bsFourthMonster = _gameState.OwnedMonsters.ElementAt(3);
                                break;
                        }

                        // Set the user type and hook up bindings
                        playerControl.UserType = _gameState.CurrentUser.UserType;
                        playerControl.HookBindings();
                    }
                    break;
                case "NewMonster":
                    var newGameMonster = control as newGameMonster;
                    if (newGameMonster != null)
                    {
                        _bsMonster.DataSource = _gameState.ActiveMonster;
                        newGameMonster.bsMonster = _bsMonster.DataSource;
                        newGameMonster.HookBindings();
                    }
                    break;

                case "MemoryGame":
                    var memoryGame = control as memoryGame;
                    _gameState.ActiveMonster.Stamina -= 25;
                    memoryGame.StartGame();
                    break;


                case "PatternGame":
                    var patternGame = control as PatternGame;
                    _gameState.ActiveMonster.Stamina -= 25;
                    patternGame.StartGame();
                    break;

                case "BattleGame":
                    var battleGame = control as battleGame;
                    battleGame.bsMonster = _gameState.ActiveMonster;
                    battleGame.HookBindings();
                    break;
            }
        }

        public void SetupUser(string newUsername, string newType)
        {
            _gameState.CurrentUser.Username = newUsername;
            _gameState.CurrentUser.UserType = newType;
        }

        public void SetupBindings(GameState state, BindingSource bsMonster, BindingSource bsUser)
        {
            bsMonster.DataSource = state.ActiveMonster;
            bsUser.DataSource = state.CurrentUser;
        }

        public void SetupUserControlBindings(BindingSource bSource, myMonster myMonsterControl, GameState state)
        {
            myMonsterControl.bsDataSource = state.ActiveMonster;
            myMonsterControl.HookBindings();
        }

        public void SetUpNewMonsterControlBindings(BindingSource bSource, newGameMonster control, GameState state)
        {
            control.bsUser = state.CurrentUser;
            control.HookBindings();
        }

        // Event handler for Save button
        public void SaveGame(bool silentSave = false)
        {
            try
            {
                _gameDataService.SaveGame(_gameState);
                if (!silentSave)
                {
                    MessageBox.Show("Game saved successfully!", "Save Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("[DEBUG-Form1]::SaveGame(): Game saved successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving game: {ex.Message}", "Save Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public bool LoadGame(string username)
        {
            //Get the username
            var loadedState = _gameDataService.LoadGame(username);

            //Check if the loadedStats are null, if they are I return false to go to the main menu.
            if (loadedState == null || loadedState.CurrentUser == null || loadedState.ActiveMonster == null)
            {
                MessageBox.Show("No save was found.", "Load Game", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            else
            {
                try
                {
                    _gameState = _gameDataService.LoadGame(username);
                    SetupBindings(_gameState, _bsMonster, _bsUser);
                    NavigateTo("Monster");
                    MessageBox.Show("Game loaded successfully!", "Load Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading game: {ex.Message}", "Load Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return true;
        }


        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        public void SetActiveMonster(int index)
        {
            _gameState.ActiveMonster = _gameState.OwnedMonsters.ElementAt(index);
        }

        public void AddExperience(int amount)
        {
            _gameState.AddExperience(amount);
        }

        public void GameReward()
        {
            if (_gameState.Inventory == null || _gameState.Inventory.Count == 0)
            {
                MessageBox.Show("No items in inventory to reward.", "Game Reward", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Random rand = new Random();
            int itemIndex = rand.Next(0, Math.Min(7, _gameState.Inventory.Count));
            var item = _gameState.Inventory[itemIndex];
            string itemName = item.Name;
            int rewardAmount = rand.Next(1, 4);

            item.Quantity += rewardAmount;

            MessageBox.Show($"Congratulations! You won {rewardAmount}x {itemName}!", "Reward", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}