using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Monster.UI
{
    /// <summary>
    /// Represents a memory-matching mini-game UserControl.
    /// Handles game setup, timing, card interactions, and reward logic.
    /// </summary>
    public partial class memoryGame : UserControl
    {
        // Reference to the main parent form for navigation and game rewards
        private Form1 ParentForm => this.FindForm() as Form1;

        // Card image resources and UI state
        private List<Image> cardImages;
        private Image backImage;
        private PictureBox firstClicked, secondClicked;
        private int matched = 0;
        private int timeLeft; // Remaining time in seconds
        private readonly Random rnd = new();

        /// <summary>
        /// Initializes the memory game UserControl, loads resources, and sets up UI events.
        /// </summary>
        public memoryGame()
        {
            InitializeComponent();
            LoadCardImages();

            this.Load += (s, e) => ResetGame();
            panelGrid.Resize += (s, e) => PositionCards();
        }

        /// <summary>
        /// Loads card face and back images from resources.
        /// </summary>
        private void LoadCardImages()
        {
            var res = new ComponentResourceManager(typeof(memoryGame));

            string[] monsterKeys = {
                "draco", "grifo", "siren", "tauro",
                "egggrifo", "eggsiren", "eggdraco", "eggtauro"
            };

            cardImages = monsterKeys.Select(k => (Image)res.GetObject(k)).ToList();
            backImage = (Image)res.GetObject("verso");
        }

        /// <summary>
        /// Initializes the game board by shuffling cards and setting click handlers.
        /// </summary>
        private void InitializeCards()
        {
            panelGrid.Controls.Clear();
            matched = 0;

            var indices = Enumerable.Range(0, cardImages.Count)
                                    .SelectMany(i => new[] { i, i }) // Create pairs
                                    .OrderBy(_ => Guid.NewGuid())   // Shuffle
                                    .ToList();

            for (int i = 0; i < 16; i++)
            {
                var pic = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = backImage,
                    Tag = indices[i]
                };
                pic.Click += Card_Click;
                panelGrid.Controls.Add(pic);
            }

            PositionCards();
        }

        /// <summary>
        /// Dynamically positions the card grid based on panel size.
        /// </summary>
        private void PositionCards()
        {
            int rows = 4, cols = 4, spacing = 8;

            int totalGapX = spacing * (cols + 1);
            int totalGapY = spacing * (rows + 1);

            int availW = panelGrid.ClientSize.Width;
            int availH = panelGrid.ClientSize.Height;

            int cellW = (availW - totalGapX) / cols;
            int cellH = (availH - totalGapY) / rows;
            int size = Math.Min(cellW, cellH);

            int offsetX = (availW - (cols * size + totalGapX)) / 2 + spacing;
            int offsetY = (availH - (rows * size + totalGapY)) / 2 + spacing;

            for (int i = 0; i < panelGrid.Controls.Count; i++)
            {
                var pb = panelGrid.Controls[i] as PictureBox;
                int r = i / cols, c = i % cols;

                pb.SetBounds(
                    offsetX + c * (size + spacing),
                    offsetY + r * (size + spacing),
                    size, size);
            }
        }

        /// <summary>
        /// Handles card click events. Reveals cards and checks for matches.
        /// </summary>
        private async void Card_Click(object sender, EventArgs e)
        {
            if (flipBackTimer.Enabled) return;

            var clicked = (PictureBox)sender;
            if (clicked == firstClicked) return;

            clicked.Image = cardImages[(int)clicked.Tag];

            if (firstClicked == null)
            {
                firstClicked = clicked;
            }
            else
            {
                secondClicked = clicked;

                if ((int)firstClicked.Tag == (int)secondClicked.Tag)
                {
                    // Match found - disable further clicks on these cards
                    firstClicked.Click -= Card_Click;
                    secondClicked.Click -= Card_Click;

                    firstClicked = secondClicked = null;
                    matched++;

                    // Check for win condition
                    if (matched == cardImages.Count)
                    {
                        gameTimer.Stop();
                        flipBackTimer.Stop();

                        ParentForm.GameReward();
                        ParentForm?.NavigateTo("Monster");
                    }
                }
                else
                {
                    // No match - start timer to flip them back
                    flipBackTimer.Start();
                }
            }
        }

        /// <summary>
        /// Timer tick to flip unmatched cards back face down.
        /// </summary>
        private void flipBackTimer_Tick(object sender, EventArgs e)
        {
            flipBackTimer.Stop();

            if (firstClicked != null && secondClicked != null)
            {
                firstClicked.Image = backImage;
                secondClicked.Image = backImage;
            }

            firstClicked = secondClicked = null;
        }

        /// <summary>
        /// Countdown timer for the game. Ends the game when time runs out.
        /// </summary>
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblGameTimer.Text = TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss");

            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                flipBackTimer.Stop();

                MessageBox.Show("Time ended!", "Game Over",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                ParentForm.NavigateTo("Monster");
            }
        }

        /// <summary>
        /// Resets and starts a new game.
        /// </summary>
        public void ResetGame()
        {
            flipBackTimer.Stop();
            gameTimer.Stop();

            firstClicked = null;
            secondClicked = null;
            matched = 0;

            timeLeft = 60;
            lblGameTimer.Text = TimeSpan.FromSeconds(timeLeft).ToString(@"mm\:ss");

            InitializeCards();
            gameTimer.Start();
        }

        /// <summary>
        /// Starts the game timer without resetting cards.
        /// </summary>
        public void StartGame()
        {
            gameTimer.Start();
        }

        /// <summary>
        /// Ensures timers are stopped when the control is removed from its parent.
        /// </summary>
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent == null)
            {
                gameTimer.Stop();
                flipBackTimer.Stop();
            }
            else
            {
                ResetGame();
            }
        }
    }
}
