using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Monster.Core.Models;
using Monster.Game.GameState;
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

        public Form1()
        {
            System.Diagnostics.Debug.WriteLine(@"[DEBUG-Form1] Constructor Call");
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine(@"Form 1 Component Init Call.");

            // Initialize all UserControls
            InitializeUserControls();

            // Set up global binding sources
            SetupBindings(_gameState, _bsMonster, _bsUser);

            _gameState.OwnedMonsters.Add(_gameState.ActiveMonster);

            // Show initial UserControl
            NavigateTo("MainMenu");

            System.Diagnostics.Debug.WriteLine(@"[DEBUG-Form1] Bindings Setup.");
        }

        private void InitializeUserControls()
        {
            // Create and initialize each UserControl
            myMonster monsterControl = new myMonster();
            inventory inventoryControl = new inventory();
            ticTacToeGame ticTacToeControl = new ticTacToeGame();
            memoryGame memoryGameControl = new memoryGame();
            playerMenu playerMenuControl = new playerMenu(_gameState.CurrentUser.UserType);
            newGamePlayer newUserControl = new newGamePlayer();
            newGameMonster newMonsterControl = new newGameMonster();
            mainMenu mainMenu = new mainMenu();
            loadGame loadGame = new loadGame();

            // Add controls to dictionary with unique keys
            _userControls.Add("Monster", monsterControl);
            _userControls.Add("Inventory", inventoryControl);
            _userControls.Add("TicTacToe", ticTacToeControl);
            _userControls.Add("MemoryGame", memoryGameControl);
            _userControls.Add("Player", playerMenuControl);
            _userControls.Add("NewUser", newUserControl);
            _userControls.Add("NewMonster", newMonsterControl);
            _userControls.Add("MainMenu", mainMenu);
            _userControls.Add("LoadGame", mainMenu);
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
                    if(newUser != null)
                    {
                        // Nothing so far
                    }
                    break;
                case "Monster":
                    var monsterControl = control as myMonster;
                    if (monsterControl != null)
                    {
                        // Update with latest monster data
                        monsterControl.bsDataSource = _bsMonster;
                        monsterControl.HookBindings();
                    }
                    break;
                case "Inventory":
                    var inventoryControl = control as inventory;
                    if (inventoryControl != null)
                    {
                        // Update inventory data
                        //inventoryControl.InventoryData = _gameState.Inventory;
                    }
                    break;
                case "Player":
                    var playerControl = control as playerMenu;
                    if (playerControl != null)
                    {
                        // Ensure the OwnedMonsters list has at least 4 entries
                        while (_gameState.OwnedMonsters.Count < 4)
                        {
                            _gameState.OwnedMonsters.Add(new MonsterClass());
                        }

                        // Bind the first four monsters to the player control
                        playerControl.bsFirstMonster = _gameState.OwnedMonsters.ElementAt(0);
                        playerControl.bsSecondMonster = _gameState.OwnedMonsters.ElementAt(1);
                        playerControl.bsThirdMonster = _gameState.OwnedMonsters.ElementAt(2);
                        playerControl.bsFourthMonster = _gameState.OwnedMonsters.ElementAt(3);

                        // Set the user type and hook up bindings
                        playerControl.UserType = _gameState.CurrentUser.UserType;
                        playerControl.HookBindings();
                    }
                    break;
                case "NewMonster":
                    var newGameMonster = control as newGameMonster;
                    if(newGameMonster != null)
                    {
                        var newMonster = new Core.Models.MonsterClass();
                        _gameState.OwnedMonsters.Add(newMonster);
                        _gameState.ActiveMonster = _gameState.OwnedMonsters.ElementAt(_gameState.OwnedMonsters.Count - 1);
                        newGameMonster.bsMonster = _bsMonster.DataSource;

                        newGameMonster.HookBindings();
                    }
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
        public void SaveGame()
        {
            try
            {
                _gameDataService.SaveGame(_gameState);
                MessageBox.Show("Game saved successfully!", "Save Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving game: {ex.Message}", "Save Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for Load button
        public void LoadGame(string username)
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
    }
}