using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Monster.UI
{
    partial class memoryGame
    {
       

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                gameTimer?.Dispose();
                flipBackTimer?.Dispose();
            components?.Dispose();
                components.Dispose();
            base.Dispose(disposing);
        }
            }

        private void InitializeComponent()
        {
            this.components = new Container();
            var resources = new ComponentResourceManager(typeof(memoryGame));

            
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Name = "memoryGame";
            this.Size = new Size(600, 900);

            // rootTableLayoutPanel: 1 coluna, 3 linhas (100px + 50px + resto)
            this.rootTableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                BackColor = Color.Transparent,
                ColumnCount = 1,
                RowCount = 3
            };
            this.rootTableLayoutPanel.ColumnStyles.Add(
              new ColumnStyle(SizeType.Percent, 100F));
            this.rootTableLayoutPanel.RowStyles.Clear();
            this.rootTableLayoutPanel.RowStyles.Add(
              new RowStyle(SizeType.Absolute, 100F));   // cabeçalho
            this.rootTableLayoutPanel.RowStyles.Add(
              new RowStyle(SizeType.Absolute, 50F));   // timer
            this.rootTableLayoutPanel.RowStyles.Add(
              new RowStyle(SizeType.Percent, 100F));   // grid

            // pictureBoxTitle 
            this.pictureBoxTitle = new PictureBox
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 20, 0, 0),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = (Image)resources.GetObject("pictureBox_memoryGames_MemoryGameText.Image")
            };
            this.rootTableLayoutPanel.Controls.Add(this.pictureBoxTitle, 0, 0);

            // lblGameTimer 
            this.lblGameTimer = new Label
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 10, 0, 0),
                Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.DarkGoldenrod,
                Text = "01:00",  // valor inicial
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.rootTableLayoutPanel.Controls.Add(this.lblGameTimer, 0, 1);

            // panelGrid 
            this.panelGrid = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                BackColor = Color.Transparent
            };
            this.rootTableLayoutPanel.Controls.Add(this.panelGrid, 0, 2);

            // flipBackTimer 
            this.flipBackTimer = new System.Windows.Forms.Timer(this.components)
            {
                Interval = 750
            };
            this.flipBackTimer.Tick += new EventHandler(this.flipBackTimer_Tick);

            // gameTimer (1s para countdown)
            this.gameTimer = new System.Windows.Forms.Timer(this.components)
            {
                Interval = 1000
            };
            this.gameTimer.Tick += new EventHandler(this.GameTimer_Tick);

            // adiciona layout raiz
            this.Controls.Add(this.rootTableLayoutPanel);
        }

        private IContainer components = null;
        private TableLayoutPanel rootTableLayoutPanel;
        private PictureBox pictureBoxTitle;
        private Label lblGameTimer;
        private Panel panelGrid;
        private System.Windows.Forms.Timer flipBackTimer;
        private System.Windows.Forms.Timer gameTimer;
       
    }
}