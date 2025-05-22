using Monster.Core.Models;
using Monster.Game.GameState;

namespace Monster.UI
{
    /// <summary>
    /// Main application form. Handles navigation, game state, and user controls.
    /// </summary>
    public partial class Form1 : Form
    {
        #region Private Fields

        // Data binding infrastructure
        private BindingSource _bsMonster = new BindingSource();
        private BindingSource _bsUser = new BindingSource();
        private GameState _gameState = new GameState();
        private GameDataService _gameDataService = new GameDataService();

        // Navigation system - all screens stored in dictionary for dynamic loading
        private Dictionary<string, UserControl> _userControls = new Dictionary<string, UserControl>();

        // Battle system state
        private string _selectedBossType = "red"; // Default boss for battle initialization

        #endregion

        #region Constructor and Initialization

        public Form1()
        {
            System.Diagnostics.Debug.WriteLine(@"[DEBUG-Form1] Constructor Call");

            InitializeComponent();
            System.Diagnostics.Debug.WriteLine(@"Form 1 Component Init Passed.");

            InitializeUserControls();
            System.Diagnostics.Debug.WriteLine(@"Initialize User Controlls Call Passed.");

            InitState();
            SetupBindings(_gameState, _bsMonster, _bsUser);
            NavigateTo("MainMenu");
        }


        private Dictionary<string, Form> _forms = new Dictionary<string, Form>();


        /// <summary>
        /// Initialize game state flags that control UI behavior
        /// </summary>
        public void InitState()
        {
            // Track whether player has visited inventory (affects tutorial flow)
            _gameState.InventoryVisited = false;
        }

        /// <summary>
        /// Pre-instantiate all user controls to avoid creation delays during navigation
        /// </summary>
        private void InitializeUserControls()
        {
            // Create all controls upfront to ensure smooth navigation
            myMonster monsterControl = new myMonster();
            inventory inventoryControl = new inventory();
            playerMenu playerMenuControl = new playerMenu(_gameState.CurrentUser.UserType);
            newGamePlayer newUserControl = new newGamePlayer();
            newGameMonster newMonsterControl = new newGameMonster();
            mainMenu mainMenu = new mainMenu();
            loadGame loadGame = new loadGame();
            miniGamesMenu miniGames = new miniGamesMenu();
            credits credits = new credits();
            BattleMenu battleMenu = new BattleMenu();
            battleGame battleGame = new battleGame();
            tutorialfirstPage tutorial1 = new tutorialfirstPage();
            TutorialSecondPage tutorial2 = new TutorialSecondPage();
            tutorialThirdPage tutorial3 = new tutorialThirdPage();
            memoryGame memoryGame = new memoryGame();
            PatternGame patternGame = new PatternGame();
            countdownForm sleepCountdownForm = new countdownForm(); //sleep
            
            // Store controls with string keys for easy navigation system
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
            _userControls.Add("Credits", credits);
            _userControls.Add("BattleMenu", battleMenu);
            _userControls.Add("BattleGame", battleGame);
            _userControls.Add("Tutorial1", tutorial1);
            _userControls.Add("Tutorial2", tutorial2);
            _userControls.Add("Tutorial3", tutorial3);
            _forms.Add("SleepCountdown", sleepCountdownForm);
        }

        #endregion

        #region Navigation System

        /// <summary>
        /// Navigate to different screens using string-based routing
        /// </summary>
        public void NavigateTo(string controlKey)
        {
            MainPanel.Controls.Clear();

            if (_userControls.TryGetValue(controlKey, out UserControl control))
            {
                // Dynamic sizing - form adapts to content size
                control.Dock = DockStyle.None;
                MainPanel.Size = control.Size;
                this.ClientSize = MainPanel.Size;

                // Refresh data before showing control
                RefreshControlData(controlKey, control);
                MainPanel.Controls.Add(control);

                System.Diagnostics.Debug.WriteLine($"[DEBUG-Form1] Navigated to {controlKey}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG-Form1] Control not found: {controlKey}");
            }
        }

        /// <summary>
        /// Prepare control-specific data and state before display
        /// Each control needs different initialization logic
        /// </summary>
        private void RefreshControlData(string controlKey, UserControl control)
        {
            switch (controlKey)
            {
                case "MainMenu":
                    // Main menu requires no special setup
                    break;

                case "NewUser":
                    // Starting new game - reset state completely
                    var newUser = control as newGamePlayer;
                    if (newUser != null)
                    {
                        _gameState = new GameState();
                    }
                    break;

                case "Monster":
                    var monsterControl = control as myMonster;
                    if (monsterControl != null)
                    {
                        // Auto-save when viewing monster (prevent data loss)
                        this.SaveGame(true);

                        // Safety check for corrupted state
                        if (_gameState == null)
                        {
                            MessageBox.Show("User not found", "Load Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            NavigateTo("LoadGame");
                            return;
                        }

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

                        // Initialize inventory on first visit
                        if (_gameState.Inventory == null || _gameState.Inventory.Count == 0)
                        {
                            _gameState.Inventory = inventoryControl.InitializeInventory();
                        }

                        inventoryControl.bsInventory = _gameState.Inventory;
                        inventoryControl.HookBindings();

                        // Track inventory visit for tutorial/progression
                        _gameState.InventoryVisited = true;
                        inventoryControl.bsMonster = _gameState.ActiveMonster;
                    }
                    break;

                case "Player":
                    var playerMenu = control as playerMenu;
                    if (playerMenu != null)
                    {
                        playerMenu.bsUser = _gameState.CurrentUser;
                        playerMenu.OwnedMonstersRef = _gameState.OwnedMonsters;
                        playerMenu.HookBindings();
                    }
                    break;

                case "NewMonster":
                    // No special setup needed for new monster creation
                    break;

                case "MemoryGame":
                    var memoryGame = control as memoryGame;
                    // Stamina cost for playing mini-games
                    _gameState.ActiveMonster.Stamina -= 25;
                    memoryGame.StartGame();
                    break;

                case "PatternGame":
                    var patternGame = control as PatternGame;
                    // Stamina cost for playing mini-games
                    _gameState.ActiveMonster.Stamina -= 25;
                    patternGame.StartGame();
                    break;

                case "BattleMenu":
                    var battleMenu = control as BattleMenu;
                    battleMenu.bsMonster = _gameState.ActiveMonster;

                
                    break;

                case "BattleGame":
                    var battleGame = control as battleGame;
                    battleGame.bsMonster = _gameState.ActiveMonster;
                    battleGame.HookBindings();
                    battleGame.InitializeBoss(_selectedBossType);
                    break;
                                   


            }
        }

        #endregion

        #region Game State Management

        public void SetSelectedBossType(string bossType)
        {
            
            _selectedBossType = bossType.ToLower(); // Normalize input for battle system

            switch (_selectedBossType)                    // Higher stamina cost for battles
            {
                case "red":
                    _gameState.ActiveMonster.Stamina -= 20;
                    break;
                case "skull":
                    _gameState.ActiveMonster.Stamina -= 30;
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
            _gameState = state;
        }

        public void SetupUserControlBindings(BindingSource bSource, myMonster myMonsterControl, GameState state)
        {
            myMonsterControl.bsDataSource = state.ActiveMonster;
            myMonsterControl.HookBindings();
        }

        public void SetActiveMonster(int index)
        {
            _gameState.ActiveMonster = _gameState.OwnedMonsters.ElementAt(index);
        }

        public List<MonsterClass> GetOwnedMonsters()
        {
            return _gameState.OwnedMonsters;
        }

        public void AddMonster(MonsterClass monster)
        {
            System.Diagnostics.Debug.WriteLine($"[DEBUG - Form1]: AddMonster() call.");

            if (_gameState.OwnedMonsters == null)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG - Form1]: AddMonster(): _gameState.OwnedMonsters is NULL.");
            }

            _gameState.OwnedMonsters.Add(monster);

            // Update player menu reference to maintain UI sync
            if (_userControls["Player"] is playerMenu playMenu)
            {
                playMenu.OwnedMonstersRef = _gameState.OwnedMonsters;
            }

            // Newly added monster becomes active
            _gameState.ActiveMonster = monster;
        }

        public bool GetInventoryVisited()
        {
            return _gameState.InventoryVisited;
        }

        #endregion

        #region Save/Load System

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
            var loadedState = _gameDataService.LoadGame(username);

            // Validate loaded data before proceeding
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

        #endregion

        #region Reward Systems

        /// <summary>
        /// Generate random rewards for mini-game completion
        /// Uses weighted probability system for different item rarities
        /// </summary>
        public void GameReward()
        {
            Random rand = new Random();

            // Probability weights for different items (higher = more common)
            var itemProbabilities = new Dictionary<string, int>
            {
                { "Water", 80 },
                { "Ramen", 80 },
                { "Soda", 50 },
                { "Burguer", 50 },
                { "Beer", 30 },
                { "Nachos", 30 },
                { "Energy Drink", 10 }
            };

            var inventoryItems = _gameState.Inventory.Where(i => itemProbabilities.ContainsKey(i.Name)).ToList();
            inventoryItems = inventoryItems.OrderBy(x => rand.Next()).ToList(); // Randomize order

            int maxTotalItems = rand.Next(1, 5);
            int totalRewardQuantity = 0;
            var rewards = new List<(string Name, int Quantity)>();

            // Award items based on probability rolls
            foreach (var item in inventoryItems)
            {
                if (totalRewardQuantity >= maxTotalItems)
                    break;

                int probability = itemProbabilities[item.Name];
                int roll = rand.Next(1, 101);

                if (roll <= probability)
                {
                    int maxQuantityForItem = maxTotalItems - totalRewardQuantity;
                    int rewardQuantity = rand.Next(1, maxQuantityForItem + 1);

                    item.Quantity += rewardQuantity;
                    rewards.Add((item.Name, rewardQuantity));
                    totalRewardQuantity += rewardQuantity;
                }
            }

            // Guarantee at least one reward
            if (rewards.Count == 0)
            {
                var randomItem = inventoryItems[rand.Next(inventoryItems.Count)];
                int rewardQuantity = rand.Next(1, maxTotalItems + 1);

                randomItem.Quantity += rewardQuantity;
                rewards.Add((randomItem.Name, rewardQuantity));
            }

            // Display reward message
            var rewardMessage = new System.Text.StringBuilder($"Congratulations! You won:\n");
            foreach (var reward in rewards)
            {
                rewardMessage.AppendLine($"{reward.Quantity}x {reward.Name}");
            }

            MessageBox.Show(rewardMessage.ToString(), "Reward", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Generate rewards for battle victories with scaling based on boss difficulty
        /// Includes both items and experience points
        /// </summary>
        public void BattleReward(MonsterClass monster, string bossType)
        {
            Random rand = new Random();

            var itemProbabilities = new Dictionary<string, int>
            {
                { "Water", 80 },
                { "Ramen", 80 },
                { "Soda", 50 },
                { "Burguer", 50 },
                { "Beer", 30 },
                { "Nachos", 30 },
                { "Energy Drink", 10 }
            };

            var inventoryItems = _gameState.Inventory.Where(i => itemProbabilities.ContainsKey(i.Name)).ToList();
            inventoryItems = inventoryItems.OrderBy(x => rand.Next()).ToList();

            int maxTotalItems;
            int minExperiencePoints;
            int maxExperiencePoints;

            // Scale rewards based on boss difficulty
            if (bossType == "red")
            {
                maxTotalItems = rand.Next(1, 5);
                minExperiencePoints = 10;
                maxExperiencePoints = 50;
            }
            else if (bossType == "skull")
            {
                maxTotalItems = 10; // Much better item rewards
                minExperiencePoints = 90;
                maxExperiencePoints = 150;
            }
            else
            {
                throw new ArgumentException("Invalid boss type");
            }

            int totalRewardQuantity = 0;
            var rewards = new List<(string Name, int Quantity)>();

            // Award items using same probability system as mini-games
            foreach (var item in inventoryItems)
            {
                if (totalRewardQuantity >= maxTotalItems)
                    break;

                int probability = itemProbabilities[item.Name];
                int roll = rand.Next(1, 101);

                if (roll <= probability)
                {
                    int maxQuantityForItem = maxTotalItems - totalRewardQuantity;
                    int rewardQuantity = rand.Next(1, maxQuantityForItem + 1);

                    item.Quantity += rewardQuantity;
                    rewards.Add((item.Name, rewardQuantity));
                    totalRewardQuantity += rewardQuantity;
                }
            }

            // Guarantee at least one item reward
            if (rewards.Count == 0)
            {
                var randomItem = inventoryItems[rand.Next(inventoryItems.Count)];
                int rewardQuantity = rand.Next(1, maxTotalItems + 1);

                randomItem.Quantity += rewardQuantity;
                rewards.Add((randomItem.Name, rewardQuantity));
            }

            // Award experience points
            int experiencePoints = rand.Next(minExperiencePoints, maxExperiencePoints + 1);
            monster.AddExperience(experiencePoints);

            // Display comprehensive reward message
            var rewardMessage = new System.Text.StringBuilder($"Congratulations! You won:\n");
            foreach (var reward in rewards)
            {
                rewardMessage.AppendLine($"{reward.Quantity}x {reward.Name}");
            }
            rewardMessage.AppendLine($"And gained {experiencePoints} experience points!");

            MessageBox.Show(rewardMessage.ToString(), "Battle Reward", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Windows Forms Overrides

        /// <summary>
        /// Enable double buffering to reduce flicker during navigation
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        #endregion
    }
}