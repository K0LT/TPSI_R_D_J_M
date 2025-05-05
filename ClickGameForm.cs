using System;
using System.Windows.Forms;
using System.Drawing;

public class ClickGameForm : Form
{
    
    public Button btnClickMe;
    public Label lblScore;
    public Label lblTime;

    public ClickGameForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.Width = 400;
        this.Height = 300;
        this.Text = "Speed Game";

        btnClickMe = new Button();
        btnClickMe.Text = "Clique aqui!";
        btnClickMe.Size = new Size(100, 30);
        btnClickMe.Location = new Point(150, 100);
        this.Controls.Add(btnClickMe);

        lblScore = new Label();
        lblScore.Text = "Pontuação: 0";
        lblScore.Location = new Point(10, 10);
        lblScore.AutoSize = true;
        this.Controls.Add(lblScore);

        lblTime = new Label();
        lblTime.Text = "Tempo: 30";
        lblTime.Location = new Point(300, 10);
        lblTime.AutoSize = true;
        this.Controls.Add(lblTime);
    }
}