namespace Monster.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            newGamePlayer = new Panel();
            MainPanel = new Panel();
            newGamePlayer.SuspendLayout();
            SuspendLayout();
            // 
            // newGamePlayer
            // 
            newGamePlayer.Controls.Add(MainPanel);
            newGamePlayer.Dock = DockStyle.Fill;
            newGamePlayer.Location = new Point(0, 0);
            newGamePlayer.Margin = new Padding(4, 5, 4, 5);
            newGamePlayer.Name = "newGamePlayer";
<<<<<<< HEAD
            newGamePlayer.Size = new Size(584, 911);
=======
            newGamePlayer.Size = new Size(2244, 1370);
>>>>>>> 5aa30fcc809483335752cd0cbf53d11194f28b88
            newGamePlayer.TabIndex = 0;
            // 
            // MainPanel
            // 
<<<<<<< HEAD
            MainPanel.Location = new Point(0, 3);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(584, 908);
=======
            MainPanel.Location = new Point(0, 0);
            MainPanel.Margin = new Padding(4, 5, 4, 5);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(2263, 1435);
>>>>>>> 5aa30fcc809483335752cd0cbf53d11194f28b88
            MainPanel.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
<<<<<<< HEAD
            ClientSize = new Size(584, 911);
            Controls.Add(newGamePlayer);
            MaximumSize = new Size(600, 950);
            MinimumSize = new Size(600, 900);
=======
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(2244, 1370);
            Controls.Add(newGamePlayer);
            Margin = new Padding(4, 5, 4, 5);
            MaximumSize = new Size(3000, 3000);
>>>>>>> 5aa30fcc809483335752cd0cbf53d11194f28b88
            Name = "Form1";
            Text = "Form1";
            newGamePlayer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel newGamePlayer;
        private Panel MainPanel;
    }
}
