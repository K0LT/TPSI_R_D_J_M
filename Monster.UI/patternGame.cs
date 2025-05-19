using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    public partial class PatternGame : UserControl
    {
        private const int SequenceShowDelay = 1200;
        private const int PlayerResponseTime = 5000;
        private const int HighlightDuration = 600;
        private Form1 ParentForm => this.FindForm() as Form1;
        private int[] sequence;
        private int currentRound;
        private int sequencePosition;
        private bool waitingForPlayer;
        private bool isShowingPattern;
        private DateTime lastInputTime;

        private Image[] patternImages;
        private Image[] highlightImages;
        private Image backImage;
        private SoundPlayer[] sounds;

        public PatternGame()
        {
            InitializeComponent();
            SetupGame();
        }

        private void SetupGame()
        {
            this.Size = new Size(600, 900);
            this.DoubleBuffered = true;
            this.BackColor = Color.FromArgb(30, 30, 40);

            
            statusLabel.Dock = DockStyle.Top;
            statusLabel.Height = 25; 
            statusLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            statusLabel.ForeColor = Color.Gold;
            statusLabel.BackColor = Color.Transparent;
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.Text = "PREPARING GAME...";

           
            countdownLabel.Dock = DockStyle.Top; 
            countdownLabel.Height = 15; 
            countdownLabel.Font = new Font("Segoe UI", 12, FontStyle.Bold); 
            countdownLabel.ForeColor = Color.WhiteSmoke;
            countdownLabel.BackColor = Color.Transparent;
            countdownLabel.TextAlign = ContentAlignment.MiddleCenter;
            countdownLabel.Visible = false;

           
            gamePanel.Dock = DockStyle.Fill;
            gamePanel.BackColor = Color.Transparent;
            gamePanel.Padding = new Padding(0, 0, 0, 10);

            LoadResources();
            InitializeGameLogic();
        }

        private void LoadResources()
        {
            var res = new ComponentResourceManager(typeof(PatternGame));

            
            backImage = (Image)res.GetObject("cardback");

            patternImages = new Image[8];
            highlightImages = new Image[8];

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
        }

        private void InitializeGameLogic()
        {
            patternButtons = new PictureBox[8];
            for (int i = 0; i < 8; i++)
            {
                patternButtons[i] = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = backImage,
                    Tag = i,
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(120, 120)
                };

                patternButtons[i].MouseEnter += (s, e) =>
                {
                    if (waitingForPlayer)
                        ((PictureBox)s).BackColor = Color.FromArgb(60, 60, 80);
                };

                patternButtons[i].MouseLeave += (s, e) =>
                {
                    ((PictureBox)s).BackColor = Color.Transparent;
                };

                patternButtons[i].Click += PatternButton_Click;
                gamePanel.Controls.Add(patternButtons[i]);
            }

            PositionButtons();
            this.HandleCreated += (s, e) =>
            {
                Task.Delay(500).ContinueWith(_ =>
                {
                    if (!this.IsDisposed && this.IsHandleCreated)
                        this.Invoke((Action)StartGame);
                });
            };
        }

        private void PositionButtons()
        {
            int columns = 2;
            int rows = 4;
            int margin = 10;

         
            int availableHeight = gamePanel.ClientSize.Height - 10;
            int availableWidth = gamePanel.ClientSize.Width;

            int buttonHeight = (availableHeight - (rows - 1) * margin) / rows;
            int buttonWidth = (availableWidth - (columns - 1) * margin) / columns;

            int buttonSize = Math.Min(buttonWidth, buttonHeight);
            buttonSize = (int)(buttonSize * 0.95);
            int totalHeight = rows * buttonSize + (rows - 1) * margin;
            int startY = (availableHeight - totalHeight) / 2;


            for (int i = 0; i < 8; i++)
            {
                int row = i / columns;
                int col = i % columns;

                patternButtons[i].Size = new Size(buttonSize, buttonSize);
                patternButtons[i].Location = new Point(
                    col * (buttonSize + margin),
                    startY + row * (buttonSize + margin)
                );
            }
        }


        public void StartGame()
        {
            currentRound = 1;
            sequence = new int[8];
            var rnd = new Random();

            for (int i = 0; i < sequence.Length; i++)
                sequence[i] = rnd.Next(0, 8);

            sequencePosition = 0;
            statusLabel.Text = $"ROUND {currentRound}/8";
            ShowSequence();
        }

        private async void ShowSequence()
        {
            isShowingPattern = true;
            gamePanel.Enabled = false;

            statusLabel.Text = "WATCH THE PATTERN!";
            await Task.Delay(800);

            for (int i = 0; i < currentRound; i++)
            {
                int buttonIndex = sequence[i];
                await AnimateButton(buttonIndex);
                await Task.Delay(500);
            }

            statusLabel.Text = "YOUR TURN!";
            countdownLabel.Text = $"TIME: {PlayerResponseTime / 1000}s";
            countdownLabel.Visible = true;

            this.BackColor = Color.FromArgb(50, 50, 70);
            await Task.Delay(200);
            this.BackColor = Color.FromArgb(30, 30, 40);

            gamePanel.Enabled = true;
            waitingForPlayer = true;
            sequencePosition = 0;
            lastInputTime = DateTime.Now;
            isShowingPattern = false;

            _ = StartCountdown();
        }

        private async Task AnimateButton(int index)
        {
            patternButtons[index].Image = highlightImages[index];
            await Task.Delay(HighlightDuration);
            patternButtons[index].Image = backImage;
        }

        private async Task StartCountdown()
        {
            int timeLeft = PlayerResponseTime / 1000;

            while (timeLeft > 0 && waitingForPlayer && !isShowingPattern)
            {
                countdownLabel.Text = $"TIME: {timeLeft}s";
                await Task.Delay(1000);
                timeLeft--;
            }

            if (waitingForPlayer && !isShowingPattern)
            {
                this.Invoke((MethodInvoker)(() => EndGame(false)));
            }
        }

        private async void PatternButton_Click(object sender, EventArgs e)
        {
            if (!waitingForPlayer || isShowingPattern) return;

            lastInputTime = DateTime.Now;
            var clickedButton = (PictureBox)sender;
            int index = (int)clickedButton.Tag;

            clickedButton.BackColor = Color.FromArgb(80, 80, 100);
            await AnimateButton(index);
            clickedButton.BackColor = Color.Transparent;

            if (index != sequence[sequencePosition])
            {
                EndGame(false);
                return;
            }

            sequencePosition++;
            if (sequencePosition >= currentRound)
            {
                if (currentRound >= 8)
                {
                    EndGame(true);
                    return;
                }

                currentRound++;
                waitingForPlayer = false;
                countdownLabel.Visible = false;

                await Task.Delay(1000);
                ShowSequence();
            }
        }

        private void EndGame(bool victory)
        {
            waitingForPlayer = false;
            countdownLabel.Visible = false;

            string message = victory ? "CONGRATULATIONS! YOU WON!" : "GAME OVER!";
            statusLabel.Text = message;

            FlashBackground(victory ? Color.Green : Color.Red);
            ParentForm.GameReward();

            Task.Delay(3000).ContinueWith(_ => this.Invoke((Action)(() =>
            {
                ParentForm?.NavigateTo("Monster");
            })));
        }

        private async void FlashBackground(Color flashColor)
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
