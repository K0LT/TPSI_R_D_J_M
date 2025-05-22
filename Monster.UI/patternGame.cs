using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    /// <summary>
    /// A memory-based pattern matching game implemented as a UserControl.
    /// Displays a sequence of highlighted buttons which the player must repeat.
    /// </summary>
    public partial class PatternGame : UserControl
    {
        // Constants controlling timing behavior
        private const int SequenceShowDelay = 1200;    // Delay between showing each pattern button
        private const int PlayerResponseTime = 10000;  // Time allowed for player to respond each round (ms)
        private const int HighlightDuration = 300;     // Duration to highlight a button (ms)

        // Reference to the parent form for navigation and rewards
        private Form1 ParentForm => this.FindForm() as Form1;

        // Game state variables
        private int[] sequence;           // The full sequence of button indices
        private int currentRound;         // Current round (length of pattern to repeat)
        private int sequencePosition;     // Player's progress index in current sequence
        private bool waitingForPlayer;    // Whether input from player is expected
        private bool isShowingPattern;    // Whether the sequence is currently being displayed
        private DateTime lastInputTime;   // Timestamp of last player input (for timeout logic)

        // UI resources
        private Image[] patternImages;    // Images for each pattern button
        private Image[] highlightImages;  // Highlighted images for each pattern button
        private Image backImage;          // Default button back image
        private SoundPlayer[] sounds;     // Sound effects for each pattern button (currently unused)

        //private PictureBox[] patternButtons; // The clickable buttons on the UI

        /// <summary>
        /// Constructor initializes the control and sets up the game.
        /// </summary>
        public PatternGame()
        {
            InitializeComponent();
            SetupGame();
        }

        /// <summary>
        /// Configures UI layout, styles, and loads resources.
        /// </summary>
        private void SetupGame()
        {
            this.Size = new Size(600, 900);
            this.DoubleBuffered = true;               // Reduce flicker
            this.BackColor = Color.FromArgb(30, 30, 40);

            // Configure status label at top
            statusLabel.Dock = DockStyle.Top;
            statusLabel.Height = 30;
            statusLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            statusLabel.ForeColor = Color.Gold;
            statusLabel.BackColor = Color.Transparent;
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.Text = "PREPARING GAME...";

            // Configure countdown timer label (hidden initially)
            countdownLabel.Dock = DockStyle.Top;
            countdownLabel.Height = 30;
            countdownLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            countdownLabel.ForeColor = Color.WhiteSmoke;
            countdownLabel.BackColor = Color.Transparent;
            countdownLabel.TextAlign = ContentAlignment.MiddleCenter;
            countdownLabel.Visible = false;

            // Configure game panel to hold pattern buttons
            gamePanel.Dock = DockStyle.Fill;
            gamePanel.BackColor = Color.Transparent;
            gamePanel.Location = new Point(0, 150);

            LoadResources();
            InitializeGameLogic();
        }

        /// <summary>
        /// Loads image and sound resources from the embedded resource manager.
        /// </summary>
        private void LoadResources()
        {
            var res = new ComponentResourceManager(typeof(PatternGame));

            backImage = (Image)res.GetObject("cardback");

            patternImages = new Image[9];
            highlightImages = new Image[9];

            string[] patternKeys = {
                "pattern1", "pattern2", "pattern3", "pattern4",
                "pattern5", "pattern6", "pattern7", "pattern8"
            };

            for (int i = 0; i < 8; i++)
            {
                patternImages[i] = (Image)res.GetObject(patternKeys[i]);
                highlightImages[i] = (Image)res.GetObject(patternKeys[i] + "_highlight");
            }

            sounds = new SoundPlayer[8];
            // Sound initialization could be added here
        }

        /// <summary>
        /// Initializes the clickable pattern buttons and their event handlers.
        /// </summary>
        private void InitializeGameLogic()
        {
            patternButtons = new PictureBox[9];

            for (int i = 0; i < 9; i++)
            {
                patternButtons[i] = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = backImage,
                    Tag = i,
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.None,
                    Size = new Size(120, 120)
                };

                // Mouse hover effect when waiting for player input
                patternButtons[i].MouseEnter += (s, e) =>
                {
                    if (waitingForPlayer)
                        ((PictureBox)s).BackColor = Color.FromArgb(60, 60, 80);
                };

                patternButtons[i].MouseLeave += (s, e) =>
                {
                    ((PictureBox)s).BackColor = Color.Transparent;
                };

                // Click event to handle player input
                patternButtons[i].Click += PatternButton_Click;

                gamePanel.Controls.Add(patternButtons[i]);
            }

            PositionButtons();

            // Start game automatically shortly after control handle is created
            this.HandleCreated += (s, e) =>
            {
                Task.Delay(100).ContinueWith(_ =>
                {
                    if (!this.IsDisposed && this.IsHandleCreated)
                        this.Invoke((Action)StartGame);
                });
            };
        }

        /// <summary>
        /// Calculates and sets the position and size of the pattern buttons in a 3x3 grid.
        /// </summary>
        private void PositionButtons()
        {
            int columns = 3;
            int rows = 3;
            int margin = 10;
            int bottomMargin = margin * 2;

            int panelWidth = gamePanel.ClientSize.Width;
            int panelHeight = gamePanel.ClientSize.Height;

            int buttonSize = Math.Min(
                (panelWidth - (columns - 1) * margin) / columns,
                (panelHeight - (rows - 1) * margin - bottomMargin) / rows
            );

            buttonSize = (int)(buttonSize * 0.9); // Slightly reduce size for padding

            int totalWidth = columns * buttonSize + (columns - 1) * margin;
            int totalHeight = rows * buttonSize + (rows - 1) * margin;

            int startX = (panelWidth - totalWidth) / 2;
            int startY = (panelHeight - totalHeight - bottomMargin) / 2;

            for (int i = 0; i < 9; i++)
            {
                int row = i / columns;
                int col = i % columns;

                patternButtons[i].Size = new Size(buttonSize, buttonSize);
                patternButtons[i].Location = new Point(
                    startX + col * (buttonSize + margin),
                    startY + row * (buttonSize + margin)
                );
            }
        }

        /// <summary>
        /// Starts a new game by initializing the random pattern sequence and round.
        /// </summary>
        public void StartGame()
        {
            currentRound = 1;
            sequence = new int[9];
            var rnd = new Random();

            // Generate a random sequence of 9 button indices (0-8)
            for (int i = 0; i < sequence.Length; i++)
                sequence[i] = rnd.Next(0, 9);

            sequencePosition = 0;
            statusLabel.Text = $"ROUND {currentRound}/8";
            ShowSequence();
        }

        /// <summary>
        /// Displays the pattern sequence to the player with visual highlights.
        /// Disables player input while sequence is showing.
        /// </summary>
        private async void ShowSequence()
        {
            isShowingPattern = true;
            gamePanel.Enabled = false;

            statusLabel.Text = "WATCH THE PATTERN!";
            await Task.Delay(800);

            // Show each step in the sequence up to current round length
            for (int i = 0; i < currentRound; i++)
            {
                int buttonIndex = sequence[i];
                await AnimateButton(buttonIndex);
                await Task.Delay(500);
            }

            statusLabel.Text = "YOUR TURN!";
            countdownLabel.Text = $"TIME: {PlayerResponseTime / 2000}s";
            countdownLabel.Visible = true;

            gamePanel.Enabled = true;
            waitingForPlayer = true;
            sequencePosition = 0;
            lastInputTime = DateTime.Now;
            isShowingPattern = false;

            _ = StartCountdown(); // Start player's countdown timer asynchronously
        }

        /// <summary>
        /// Animates a single button by changing its image to highlighted then back.
        /// </summary>
        /// <param name="index">Index of button to animate</param>
        private async Task AnimateButton(int index)
        {
            patternButtons[index].Image = highlightImages[index];
            await Task.Delay(HighlightDuration);
            patternButtons[index].Image = backImage;
        }

        /// <summary>
        /// Countdown timer giving player a limited time to respond each round.
        /// Ends the game if time runs out.
        /// </summary>
        private async Task StartCountdown()
        {
            int timeLeft = PlayerResponseTime / 1000;

            while (timeLeft > 0 && waitingForPlayer && !isShowingPattern)
            {
                countdownLabel.Text = $"TIME: {timeLeft}s";
                await Task.Delay(1000);
                timeLeft--;
            }

            // If player runs out of time without completing input, end game as failure
            if (waitingForPlayer && !isShowingPattern)
            {
                this.Invoke((MethodInvoker)(() => EndGame(false)));
            }
        }

        /// <summary>
        /// Handles player clicking a pattern button during input phase.
        /// Validates input against sequence and progresses rounds or ends game.
        /// </summary>
        private async void PatternButton_Click(object sender, EventArgs e)
        {
            if (!waitingForPlayer || isShowingPattern) return;

            lastInputTime = DateTime.Now;
            var clickedButton = (PictureBox)sender;
            int index = (int)clickedButton.Tag;

            // Provide visual feedback for click
            clickedButton.BackColor = Color.FromArgb(80, 80, 100);
            await AnimateButton(index);
            clickedButton.BackColor = Color.Transparent;

            // Validate player's choice
            if (index != sequence[sequencePosition])
            {
                EndGame(false);
                return;
            }

            sequencePosition++;

            // Player completed current round sequence successfully
            if (sequencePosition >= currentRound)
            {
                if (currentRound >= 8)
                {
                    EndGame(true); // Player wins after 8 rounds
                    return;
                }

                currentRound++;
                waitingForPlayer = false;
                countdownLabel.Visible = false;

                await Task.Delay(1000);
                ShowSequence(); // Show next round pattern
            }
        }

        /// <summary>
        /// Ends the game, providing visual feedback and navigating back to main menu.
        /// </summary>
        /// <param name="victory">True if player won, false if lost</param>
        private async void EndGame(bool victory)
        {
            waitingForPlayer = false;
            countdownLabel.Visible = false;

            // Flash background green for win or red for loss
            await ExecuteFlash(victory ? Color.Green : Color.Red);

            if (victory)
            {
                ParentForm.GameReward(); // Award the player on victory
            }
            else
            {
                MessageBox.Show("    Game Over!    ", "    Pattern Game    ");
            }

            // Navigate back to main menu or monster screen
            ParentForm?.NavigateTo("Monster");
        }

        /// <summary>
        /// Flashes the background color several times for visual feedback.
        /// </summary>
        /// <param name="flashColor">Color to flash</param>
        private async Task ExecuteFlash(Color flashColor)
        {
            Color originalColor = this.BackColor;
            for (int i = 0; i < 3; i++)
            {
                this.BackColor = flashColor;
                await Task.Delay(200);
                this.BackColor = originalColor;
                await Task.Delay(200);
            }
        }

        /// <summary>
        /// Stops the game logic when control visibility changes to hidden.
        /// </summary>
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (!Visible)
            {
                waitingForPlayer = false;
                isShowingPattern = false;
            }
        }
    }
}
