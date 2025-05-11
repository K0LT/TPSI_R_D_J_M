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
            newGamePlayer.Name = "newGamePlayer";
            newGamePlayer.Size = new Size(584, 911);
            newGamePlayer.TabIndex = 0;
            // 
            // MainPanel
            // 
            MainPanel.Location = new Point(0, 3);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(584, 908);
            MainPanel.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 911);
            Controls.Add(newGamePlayer);
            MaximumSize = new Size(600, 950);
            MinimumSize = new Size(600, 900);
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
