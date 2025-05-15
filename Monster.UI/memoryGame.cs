using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Monster.UI
{
    public partial class memoryGame : UserControl
    {

        private Form1 ParentForm => this.FindForm() as Form1;

        public memoryGame()
        {
            InitializeComponent();


            LoadCardImages();
            var playerRes = new ComponentResourceManager(typeof(playerMenu));
            this.BackgroundImage =
               (Image)playerRes.GetObject("$this.BackgroundImage");
            var mainRes = new ComponentResourceManager(typeof(mainMenu));
            backImage =
               (Image)mainRes.GetObject("$this.BackgroundImage");

            timeLeft = 10;
            lblGameTimer.Text = TimeSpan.FromSeconds(timeLeft)
                                         .ToString(@"mm\:ss");
        


            InitializeCards();


            panelGrid.Resize += (s, e) => PositionCards();
        }

        private void LoadCardImages()
        {
            var res = new ComponentResourceManager(typeof(memoryGame));
            


            string[] monsterKeys = {
    "draco",
    "grifo",
    "siren",
    "tauro",
    "egggrifo",
    "eggsiren",
    "eggdraco",
    "eggtauro"
  };
     

            cardImages = new List<Image>();
            foreach (var k in monsterKeys)
                cardImages.Add((Image)res.GetObject(k));
            

            backImage = (Image)res.GetObject("$verso");
        }

        private void InitializeCards()
        {
            panelGrid.Controls.Clear();
            matched = 0;    


            var indices = Enumerable.Range(0, cardImages.Count)
                                    .SelectMany(i => new[] { i, i })
                                    .OrderBy(_ => Guid.NewGuid())
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

        private void Card_Click(object sender, EventArgs e)
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
                    firstClicked.Click -= Card_Click;
                    secondClicked.Click -= Card_Click;
                    firstClicked = secondClicked = null;

                    matched++;
                    if (matched == cardImages.Count)
                    {
                        gameTimer.Stop();
                        flipBackTimer.Stop();
                        MessageBox.Show("Parabéns, você venceu!", "Fim de Jogo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ParentForm?.NavigateTo("Monster");
                    }
                }
            
                else
                {
                    flipBackTimer.Start();
                }
            }
        }

        
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

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            lblGameTimer.Text = TimeSpan.FromSeconds(timeLeft)
                                         .ToString(@"mm\:ss");
            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                flipBackTimer.Stop();
                MessageBox.Show("Tempo esgotado!", "Fim de Jogo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                ParentForm.NavigateTo("Monster");
            }
        }
        public void StartGame()
        {
            gameTimer.Start();
        }

        private List<Image> cardImages;
        private Image backImage;
        private PictureBox firstClicked, secondClicked;
        private int matched = 0;
        private int timeLeft; //seconds
    }
}