using System;
using System.Windows.Forms;
using System.Drawing;

public class ClickGameLogic
{
    private ClickGameForm form;
    private int score = 0;
    private int timeLeft = 30; // segundos
    private Timer gameTimer;
    private Random random;

    public ClickGameLogic(ClickGameForm form)
    {
        this.form = form;
        random = new Random();

        form.btnClickMe.Click += BtnClickMe_Click; // liga evento de clique

        gameTimer = new Timer();
        gameTimer.Interval = 1000; // 1 segundo
        gameTimer.Tick += GameTimer_Tick;
        gameTimer.Start();
    }

    private void BtnClickMe_Click(object sender, EventArgs e)
    {
        score++;
        form.lblScore.Text = "Pontuação: " + score;

        // Mover botão para posição aleatória dentro do formulário
        int maxX = form.ClientSize.Width - form.btnClickMe.Width;
        int maxY = form.ClientSize.Height - form.btnClickMe.Height;
        int x = random.Next(0, maxX);
        int y = random.Next(30, maxY); // evita sobreposição com labels
        form.btnClickMe.Location = new Point(x, y);
    }

    private void GameTimer_Tick(object sender, EventArgs e)
    {
        timeLeft--;
        form.lblTime.Text = "Tempo: " + timeLeft;

        if (timeLeft == 0)
        {
            gameTimer.Stop();
            form.btnClickMe.Enabled = false;
            MessageBox.Show("Tempo esgotado! Pontuação final: " + score, "Fim do jogo");
        }
    }
}