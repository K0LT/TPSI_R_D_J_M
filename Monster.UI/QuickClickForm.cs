using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    public partial class QuickClickForm : Form
    {

        private readonly Random rnd = new Random();
        private readonly Stopwatch sw = new Stopwatch();

        public QuickClickForm()
        {
            InitializeComponent();

            // Inicial state
            lblResult.Text = "Aguarde...";
            btnClick.Visible = false;
            btnClick.Click += BtnClick_Click;


            timerDelay.Tick += TimerDelay_Tick;

            this.Load += (s, e) => StartNewRound();

        }
        private void StartNewRound()
        {

            timerDelay.Interval = rnd.Next(1000, 3000);
            timerDelay.Start();
        }

        private void TimerDelay_Tick(object sender, EventArgs e)
        {
            timerDelay.Stop();

            // posiciona o botão em lugar random
            int maxX = ClientSize.Width - btnClick.Width;
            int maxY = ClientSize.Height - btnClick.Height;
            btnClick.Location = new Point(rnd.Next(0, Math.Max(1, maxX)),
                                          rnd.Next(0, Math.Max(1, maxY)));

            // mostra e inicia cronômetro
            btnClick.Visible = true;
            sw.Restart();
            lblResult.Text = "Clique!";
        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            sw.Stop();
            int ms = (int)sw.ElapsedMilliseconds;

            // Exibe o resultado
            lblResult.Text = $"Tempo Reacção: {ms} ms";


            btnClick.Enabled = false;


            // Ou então, após um delay, reinicie um novo round:
            var t2 = new Timer { Interval = 2000 };
            t2.Tick += (s2, e2) =>
            {
                t2.Stop();
                btnClick.Enabled = true;
                StartNewRound();
            };
            t2.Start();
        }
    }

}
