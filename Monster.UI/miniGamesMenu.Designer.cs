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
            pictureBox_miniGamesMenu_MiniGamesText = new PictureBox();
            button_miniGamesMenu_ReturnToMyMonster = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_miniGamesMenu_MiniGamesText).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_miniGamesMenu_MiniGamesText
            // 
            pictureBox_miniGamesMenu_MiniGamesText.BackColor = Color.Transparent;
            pictureBox_miniGamesMenu_MiniGamesText.Image = (Image)resources.GetObject("pictureBox_miniGamesMenu_MiniGamesText.Image");
            pictureBox_miniGamesMenu_MiniGamesText.Location = new Point(45, 22);
            pictureBox_miniGamesMenu_MiniGamesText.Name = "pictureBox_miniGamesMenu_MiniGamesText";
            pictureBox_miniGamesMenu_MiniGamesText.Size = new Size(500, 133);
            pictureBox_miniGamesMenu_MiniGamesText.TabIndex = 4;
            pictureBox_miniGamesMenu_MiniGamesText.TabStop = false;
            // 
            // button_miniGamesMenu_ReturnToMyMonster
            // 
            button_miniGamesMenu_ReturnToMyMonster.BackColor = Color.Transparent;
            button_miniGamesMenu_ReturnToMyMonster.BackgroundImage = (Image)resources.GetObject("button_miniGamesMenu_ReturnToMyMonster.BackgroundImage");
            button_miniGamesMenu_ReturnToMyMonster.Location = new Point(278, 756);
            button_miniGamesMenu_ReturnToMyMonster.Name = "button_miniGamesMenu_ReturnToMyMonster";
            button_miniGamesMenu_ReturnToMyMonster.Size = new Size(33, 43);
            button_miniGamesMenu_ReturnToMyMonster.TabIndex = 22;
            button_miniGamesMenu_ReturnToMyMonster.UseVisualStyleBackColor = false;
            // 
            // miniGamesMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button_miniGamesMenu_ReturnToMyMonster);
            Controls.Add(pictureBox_miniGamesMenu_MiniGamesText);
            Name = "miniGamesMenu";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_miniGamesMenu_MiniGamesText).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_miniGamesMenu_MiniGamesText;
        private Button button_miniGamesMenu_ReturnToMyMonster;
    }
}
