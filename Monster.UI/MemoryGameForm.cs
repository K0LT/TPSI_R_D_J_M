using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    public partial class MemoryGameForm : Form
    {
        private readonly List<Image> images;     
        private readonly PictureBox[,] boxes = new PictureBox[4, 4];
        private PictureBox first, second;
        private Timer revealTimer = new Timer { Interval = 1000 };

        public MemoryGameForm()
        {
            InitializeComponent();
            Text = "Memory Game";

            
            images = new List<Image> {
            Properties.Resources.img1, Properties.Resources.img2,
           
        };

           
            var deck = images.Concat(images).OrderBy(_ => Guid.NewGuid()).ToList();

           
            int idx = 0;
            for (int r = 0; r < 4; r++)
                for (int c = 0; c < 4; c++)
                {
                    var pb = (PictureBox)tableLayoutPanel1.Controls[idx++];
                    boxes[r, c] = pb;
                    pb.Tag = deck[idx - 1];      
                    pb.Image = Properties.Resources.back; 
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;
                    pb.Click += OnClick;
                }

            revealTimer.Tick += (s, e) =>
            {
                revealTimer.Stop();
                first.Image = second.Image = Properties.Resources.back;
                first = second = null;
            };
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (revealTimer.Enabled) return; 

            var pb = (PictureBox)sender;
            if (pb == first || pb.Image != Properties.Resources.back) return;

            // mostra a face
            pb.Image = (Image)pb.Tag;
            if (first == null)
            {
                first = pb;
            }
            else
            {
                second = pb;
                // test match
                if (first.Tag == second.Tag)
                {
                    first = second = null; 
                                          
                    CheckWin();
                }
                else
                {
                    revealTimer.Start();
                }
            }
        }

        private void CheckWin()
        {
            bool allRevealed = tableLayoutPanel1.Controls
                .Cast<PictureBox>()
                .All(x => x.Image != Properties.Resources.back);
            if (allRevealed)
            {
                MessageBox.Show("Ganhou!");
                this.Close();
            }
        }
    }
}