using Monster.UI.Properties;
using System.ComponentModel;
using System.Windows.Forms;

namespace Monster.UI
{
    partial class PatternGame
    {
        private IContainer components = null;

        protected PictureBox titlePictureBox;
        protected Label statusLabel;
        protected Label countdownLabel;
        protected Panel gamePanel;
        protected PictureBox[] patternButtons;
        private System.Windows.Forms.Timer gameTimer;


        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }



        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gameTimer = new System.Windows.Forms.Timer(components);
            var resources = new ComponentResourceManager(typeof(PatternGame));

          //raiz layout
            var rootLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4,
                BackColor = Color.Transparent,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
            };
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F)); // título
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));  // status
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));  // contador
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));  // painel jogo

            // titlePictureBox
            titlePictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Margin = new Padding(0, 20, 0, 0),
                Image = (Image)resources.GetObject("pictureBox_patternGames_PatternGameText.Image")
            };
            rootLayout.Controls.Add(titlePictureBox, 0, 0);

            // statusLabel
            statusLabel = new Label
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 20, 0, 0),
                Text = "Follow the pattern",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkSlateBlue
            };
            rootLayout.Controls.Add(statusLabel, 0, 1);

            // countdownLabel
            countdownLabel = new Label
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 10, 0, 0),
                Text = "00:00",
                Font = new Font("Consolas", 14F, FontStyle.Bold, GraphicsUnit.Point),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.DarkGoldenrod
            };
            rootLayout.Controls.Add(countdownLabel, 0, 2);

            // gamePanel
            gamePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                Margin = Padding.Empty, // margens simétricas
                Padding = Padding.Empty
            };
            rootLayout.Controls.Add(gamePanel, 0, 3);


      
            Controls.Add(rootLayout);

            // propriedades do UserControl
            Name = "PatternGame";
            Size = new Size(600, 900);

            // configurar o timer
            gameTimer.Interval = 1000;
            
        }
    }
}
