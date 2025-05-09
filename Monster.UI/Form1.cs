using System.Runtime.CompilerServices;
using Monster.Game.GameState;
namespace Monster.UI
{
    public partial class Form1 : Form
    {
        // Binding Sources
        private BindingSource _bsMonster = new BindingSource();
        
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
            SetupBindings(_gameState, _bsMonster);

            // Show initial UserControl
            NavigateTo("Monster");

            System.Diagnostics.Debug.WriteLine(@"[DEBUG-Form1] Bindings Setup.");
        }

        private void InitializeUserControls()
        {
            // Create and initialize each UserControl
            myMonster monsterControl = new myMonster();
            // Add other UserControls as needed
            // inventoryControl = new InventoryControl();
            // battleControl = new BattleControl();

            // Add controls to dictionary with unique keys
            _userControls.Add("Monster", monsterControl);
            // _userControls.Add("Inventory", inventoryControl);
            // _userControls.Add("Battle", battleControl);

            // Set up bindings for each control
            SetupUserControlBindings(_bsMonster, monsterControl, _gameState);
            // Set up bindings for other controls as needed
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
                    // Add cases for other controls as needed
            }
        }

        public void SetupBindings(GameState state, BindingSource bsMonster)
        {
            bsMonster.DataSource = state.ActiveMonster;
        }

        public void SetupUserControlBindings(BindingSource bSource, myMonster myMonsterControl, GameState state)
        {
            myMonsterControl.bsDataSource = state.ActiveMonster;
            myMonsterControl.HookBindings();
        }
    }
}