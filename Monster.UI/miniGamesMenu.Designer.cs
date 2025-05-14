namespace Monster.UI
{
    partial class miniGamesMenu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(miniGamesMenu));
            miniGamesTitleLabel = new Label();
            button_MiniGames_Exit = new Button();
            SuspendLayout();
            // 
            // miniGamesTitleLabel
            // 
            miniGamesTitleLabel.AutoSize = true;
            miniGamesTitleLabel.BackColor = Color.Transparent;
            miniGamesTitleLabel.Font = new Font("VCR OSD Mono", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            miniGamesTitleLabel.ForeColor = Color.DarkGoldenrod;
            miniGamesTitleLabel.Location = new Point(110, 95);
            miniGamesTitleLabel.Name = "miniGamesTitleLabel";
            miniGamesTitleLabel.Size = new Size(407, 64);
            miniGamesTitleLabel.TabIndex = 22;
            miniGamesTitleLabel.Text = "Mini-Games";
            // 
            // button_MiniGames_Exit
            // 
            button_MiniGames_Exit.BackColor = Color.Transparent;
            button_MiniGames_Exit.BackgroundImage = (Image)resources.GetObject("button_MiniGames_Exit.BackgroundImage");
            button_MiniGames_Exit.FlatAppearance.BorderSize = 0;
            button_MiniGames_Exit.FlatStyle = FlatStyle.Flat;
            button_MiniGames_Exit.Location = new Point(555, 0);
            button_MiniGames_Exit.Name = "button_MiniGames_Exit";
            button_MiniGames_Exit.Size = new Size(45, 45);
            button_MiniGames_Exit.TabIndex = 23;
            button_MiniGames_Exit.UseVisualStyleBackColor = false;
            // 
            // miniGamesMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button_MiniGames_Exit);
            Controls.Add(miniGamesTitleLabel);
            Name = "miniGamesMenu";
            Size = new Size(600, 900);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label miniGamesTitleLabel;
        private Button button_MiniGames_Exit;
    }
}
