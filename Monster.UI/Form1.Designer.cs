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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            newGamePlayer = new Panel();
            MainPanel = new Panel();
            process1 = new System.Diagnostics.Process();
            newGamePlayer.SuspendLayout();
            SuspendLayout();
            // 
            // newGamePlayer
            // 
            newGamePlayer.Controls.Add(MainPanel);
            newGamePlayer.Dock = DockStyle.Fill;
            newGamePlayer.Location = new Point(0, 0);
            newGamePlayer.Name = "newGamePlayer";
            newGamePlayer.Size = new Size(600, 857);
            newGamePlayer.TabIndex = 0;
            // 
            // MainPanel
            // 
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(604, 900);
            MainPanel.TabIndex = 0;
            // 
            // process1
            // 
            process1.StartInfo.Domain = "";
            process1.StartInfo.LoadUserProfile = false;
            process1.StartInfo.Password = null;
            process1.StartInfo.StandardErrorEncoding = null;
            process1.StartInfo.StandardInputEncoding = null;
            process1.StartInfo.StandardOutputEncoding = null;
            process1.StartInfo.UseCredentialsForNetworkingOnly = false;
            process1.StartInfo.UserName = "";
            process1.SynchronizingObject = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 900);
            Controls.Add(newGamePlayer);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(620, 900);
            MinimumSize = new Size(620, 900);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Monsters";
            newGamePlayer.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel newGamePlayer;
        private Panel MainPanel;
        private System.Diagnostics.Process process1;
    }
}
