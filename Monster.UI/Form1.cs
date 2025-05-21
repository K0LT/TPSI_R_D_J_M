using System.Runtime.CompilerServices;
using System.Text;
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

            InitState();

            // Set up global binding sources
            SetupBindings(_gameState, _bsMonster, _bsUser);

            // Show initial UserControl
            NavigateTo("MainMenu");
        }

        public void InitState()
        {
            _gameState.InventoryVisited = false;
        }

        private void InitializeUserControls()
        {
            // Create and initialize each UserControl
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
                        _gameState = new GameState();
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
                    // Nothing for now
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
                    battleGame.InitializeBoss(_selectedBossType);
                    _gameState.ActiveMonster.Stamina -= 30;
                    break;
            }
        }


        private string _selectedBossType = "red"; // default
        public void SetSelectedBossType(string bossType)
        {
            _selectedBossType = bossType.ToLower(); // "red" or "skull"
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

        public void AddMonster(MonsterClass monster)
        {
            System.Diagnostics.Debug.WriteLine($"[DEBUG - Form1]: AddMonster() call.");
            if(_gameState.OwnedMonsters == null)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG - Form1]: AddMonster(): _gameState.OwnedMonsters is NULL.");
            }
            _gameState.OwnedMonsters.Add(monster);
            _gameState.ActiveMonster = monster;
        }

       




        public void GameReward()
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

            int maxTotalItems = rand.Next(1, 5);

            int totalRewardQuantity = 0;

            var rewards = new List<(string Name, int Quantity)>();

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

            if (rewards.Count == 0)
            {
                var randomItem = inventoryItems[rand.Next(inventoryItems.Count)];
                int rewardQuantity = rand.Next(1, maxTotalItems + 1);

                randomItem.Quantity += rewardQuantity;

                rewards.Add((randomItem.Name, rewardQuantity));
                totalRewardQuantity += rewardQuantity;
            }

            var rewardMessage = new System.Text.StringBuilder($"Congratulations! You won:\n");
            foreach (var reward in rewards)
            {
                rewardMessage.AppendLine($"{reward.Quantity}x {reward.Name}");
            }

            MessageBox.Show(rewardMessage.ToString(), "Reward", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }






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

          
            if (bossType == "red")
            {
                maxTotalItems = rand.Next(1, 5);
                minExperiencePoints = 10;
                maxExperiencePoints = 50;
            }
            else if (bossType == "skull")
            {
                maxTotalItems = 10; 
                minExperiencePoints = 90;
                maxExperiencePoints = 150;
            }
            else
            {
                throw new ArgumentException("Invalid boss type");
            }

            int totalRewardQuantity = 0;
            var rewards = new List<(string Name, int Quantity)>();

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

            if (rewards.Count == 0)
            {
                var randomItem = inventoryItems[rand.Next(inventoryItems.Count)];
                int rewardQuantity = rand.Next(1, maxTotalItems + 1);

                randomItem.Quantity += rewardQuantity;
                rewards.Add((randomItem.Name, rewardQuantity));
                totalRewardQuantity += rewardQuantity;
            }

            int experiencePoints = rand.Next(minExperiencePoints, maxExperiencePoints + 1);
            monster.AddExperience(experiencePoints);

            var rewardMessage = new System.Text.StringBuilder($"Congratulations! You won:\n");
            foreach (var reward in rewards)
            {
                rewardMessage.AppendLine($"{reward.Quantity}x {reward.Name}");
            }
            rewardMessage.AppendLine($"And gained {experiencePoints} experience points!");

            MessageBox.Show(rewardMessage.ToString(), "Battle Reward", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        public bool GetInventoryVisited() {
            return _gameState.InventoryVisited;
        }
    }

}