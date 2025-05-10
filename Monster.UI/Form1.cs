using System.Runtime.CompilerServices;
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

            // Show initial UserControl
            NavigateTo("Monster");

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

            // Add controls to dictionary with unique keys
            _userControls.Add("Monster", monsterControl);
            _userControls.Add("Inventory", inventoryControl);
            _userControls.Add("TicTacToe", ticTacToeControl);
            _userControls.Add("MemoryGame", memoryGameControl);
            _userControls.Add("Player", playerMenuControl);

            // Set up bindings for each control
            SetupUserControlBindings(_bsMonster, monsterControl, _gameState);
            // Additional bindings can be added for other controls if needed
        }

        public void NavigateTo(string controlKey)
        {
            // Clear the main panel
            MainPanel.Controls.Clear();

            // Get the requested UserControl
            if (_userControls.TryGetValue(controlKey, out UserControl control))
            {
                // Configure control to fill panel
                control.Dock = DockStyle.Fill;

                // Refresh the control's data before showing (if needed)
                RefreshControlData(controlKey, control);

                // Add the control to the panel
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
                case "Monster":
                    var monsterControl = control as myMonster;
                    if (monsterControl != null)
                    {
                        // Update with latest monster data
                        monsterControl.bsDataSource = _gameState.ActiveMonster;
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
                        // Update player data
                        //playerControl.userData = _gameState.currentUser;
                    }
                    break;
                    // Add cases for other controls as needed
            }
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

        // Event handler for Save button
        private void SaveGame(string username)
        {
            try
            {
                _gameDataService.SaveGame(_gameState, username);
                MessageBox.Show("Game saved successfully!", "Save Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving game: {ex.Message}", "Save Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for Load button
        private void LoadGame(string username)
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
    }
}