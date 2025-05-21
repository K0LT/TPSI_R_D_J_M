using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    public partial class PatternGame : UserControl
    {
        private const int SequenceShowDelay = 1200;
        private const int PlayerResponseTime = 10000;
        private const int HighlightDuration = 300;
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
            statusLabel.Height = 30; 
            statusLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            statusLabel.ForeColor = Color.Gold;
            statusLabel.BackColor = Color.Transparent;
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            statusLabel.Text = "PREPARING GAME...";

           
            countdownLabel.Dock = DockStyle.Top; 
            countdownLabel.Height = 30; 
            countdownLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold); 
            countdownLabel.ForeColor = Color.WhiteSmoke;
            countdownLabel.BackColor = Color.Transparent;
            countdownLabel.TextAlign = ContentAlignment.MiddleCenter;
            countdownLabel.Visible = false;

           
            gamePanel.Dock = DockStyle.Fill;
            gamePanel.BackColor = Color.Transparent;
            gamePanel.Location = new Point(0, 150);
            


            LoadResources();
            InitializeGameLogic();
        }
    

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
        }

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
                Task.Delay(100).ContinueWith(_ =>
                {
                    if (!this.IsDisposed && this.IsHandleCreated)
                        this.Invoke((Action)StartGame);
                });
            };
        }

        private void PositionButtons()
        {
            int columns = 3;
            int rows = 3;
            int margin = 10;
            int bottomMargin = margin *2;

            int panelWidth = gamePanel.ClientSize.Width;
            int panelHeight = gamePanel.ClientSize.Height;

            int buttonSize = Math.Min(
                (panelWidth - (columns - 1) * margin) / columns,
                (panelHeight - (rows - 1) * margin - bottomMargin) / rows
            );

            buttonSize = (int)(buttonSize * 0.9); 

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


        public void StartGame()
        {
            currentRound = 1;
            sequence = new int[9];
            var rnd = new Random();

            for (int i = 0; i < sequence.Length; i++)
                sequence[i] = rnd.Next(0, 9);

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
            countdownLabel.Text = $"TIME: {PlayerResponseTime / 2000}s";
            countdownLabel.Visible = true;

            //this.BackColor = Color.FromArgb(50, 50, 70);
            //await Task.Delay(200);
            //this.BackColor = Color.FromArgb(30, 30, 40);

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

        private async void EndGame(bool victory)
        {
            waitingForPlayer = false;
            countdownLabel.Visible = false;

            
            await ExecuteFlash(victory ? Color.Green : Color.Red);

            
            if (victory)
            {
                ParentForm.GameReward(); 
            }
            else
            {
                MessageBox.Show("    Game Over!    ","    Pattern Game    ");
            }

            ParentForm?.NavigateTo("Monster");
        }




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
