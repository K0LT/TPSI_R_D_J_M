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
            pictureBox_miniGames_Memory = new PictureBox();
            pictureBox_miniGames_ticTac = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_miniGames_Memory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_miniGames_ticTac).BeginInit();
            SuspendLayout();
            // 
            // miniGamesTitleLabel
            // 
            miniGamesTitleLabel.BackColor = Color.Transparent;
            miniGamesTitleLabel.Font = new Font("VCR OSD Mono", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            miniGamesTitleLabel.ForeColor = Color.DarkGoldenrod;
            miniGamesTitleLabel.Location = new Point(0, 51);
            miniGamesTitleLabel.Name = "miniGamesTitleLabel";
            miniGamesTitleLabel.Size = new Size(600, 64);
            miniGamesTitleLabel.TabIndex = 22;
            miniGamesTitleLabel.Text = "Mini-Games";
            miniGamesTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button_MiniGames_Exit
            // 
            button_MiniGames_Exit.BackColor = Color.Transparent;
            button_MiniGames_Exit.BackgroundImage = (Image)resources.GetObject("button_MiniGames_Exit.BackgroundImage");
            button_MiniGames_Exit.Cursor = Cursors.Hand;
            button_MiniGames_Exit.FlatAppearance.BorderSize = 0;
            button_MiniGames_Exit.FlatStyle = FlatStyle.Flat;
            button_MiniGames_Exit.Location = new Point(555, 0);
            button_MiniGames_Exit.Name = "button_MiniGames_Exit";
            button_MiniGames_Exit.Size = new Size(45, 45);
            button_MiniGames_Exit.TabIndex = 23;
            button_MiniGames_Exit.UseVisualStyleBackColor = false;
            button_MiniGames_Exit.Click += button_MiniGames_Exit_Click;
            // 
            // pictureBox_miniGames_Memory
            // 
            pictureBox_miniGames_Memory.Cursor = Cursors.Hand;
            pictureBox_miniGames_Memory.Image = (Image)resources.GetObject("pictureBox_miniGames_Memory.Image");
            pictureBox_miniGames_Memory.Location = new Point(36, 172);
            pictureBox_miniGames_Memory.Name = "pictureBox_miniGames_Memory";
            pictureBox_miniGames_Memory.Size = new Size(250, 620);
            pictureBox_miniGames_Memory.TabIndex = 24;
            pictureBox_miniGames_Memory.TabStop = false;
            // 
            // pictureBox_miniGames_ticTac
            // 
            pictureBox_miniGames_ticTac.Cursor = Cursors.Hand;
            pictureBox_miniGames_ticTac.Image = (Image)resources.GetObject("pictureBox_miniGames_ticTac.Image");
            pictureBox_miniGames_ticTac.Location = new Point(308, 172);
            pictureBox_miniGames_ticTac.Name = "pictureBox_miniGames_ticTac";
            pictureBox_miniGames_ticTac.Size = new Size(250, 620);
            pictureBox_miniGames_ticTac.TabIndex = 25;
            pictureBox_miniGames_ticTac.TabStop = false;
            // 
            // miniGamesMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(pictureBox_miniGames_ticTac);
            Controls.Add(pictureBox_miniGames_Memory);
            Controls.Add(button_MiniGames_Exit);
            Controls.Add(miniGamesTitleLabel);
            Name = "miniGamesMenu";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_miniGames_Memory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_miniGames_ticTac).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label miniGamesTitleLabel;
        private Button button_MiniGames_Exit;
        private PictureBox pictureBox_miniGames_Memory;
        private PictureBox pictureBox_miniGames_ticTac;
    }
}
