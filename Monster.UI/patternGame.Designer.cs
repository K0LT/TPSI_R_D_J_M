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
            titlePictureBox = new PictureBox();
            statusLabel = new Label();
            countdownLabel = new Label();
            gamePanel = new Panel();
            gameTimer = new System.Windows.Forms.Timer(components);

            ((System.ComponentModel.ISupportInitialize)(titlePictureBox)).BeginInit();
            SuspendLayout();

            // titlePictureBox 
            titlePictureBox.Dock = DockStyle.Top;
            titlePictureBox.Location = new System.Drawing.Point(0, 0);
            titlePictureBox.Name = "titlePictureBox";
            titlePictureBox.Size = new System.Drawing.Size(600, 80);
            titlePictureBox.TabStop = false;

            // statusLabel
            statusLabel.Dock = DockStyle.Top;
            statusLabel.Location = new System.Drawing.Point(0, 100); 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new System.Drawing.Size(600, 30); 
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;

            // countdownLabel 
            countdownLabel.Dock = DockStyle.Top; 
            countdownLabel.Location = new System.Drawing.Point(0, 140); 
            countdownLabel.Name = "countdownLabel";
            countdownLabel.Size = new System.Drawing.Size(600, 20); 
            countdownLabel.TextAlign = ContentAlignment.MiddleCenter;

            // gamePanel 
            gamePanel.Dock = DockStyle.Fill;
            gamePanel.Location = new System.Drawing.Point(0, 130); 
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new System.Drawing.Size(600, 770); 

           
            Controls.Add(gamePanel);
            Controls.Add(countdownLabel);
            Controls.Add(statusLabel);
            Controls.Add(titlePictureBox);
            Name = "PatternGame";
            Size = new System.Drawing.Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)(titlePictureBox)).EndInit();
            ResumeLayout(false);
        }
    }
}
