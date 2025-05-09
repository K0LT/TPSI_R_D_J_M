namespace Monster.UI
{
    partial class tutorialfirstPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tutorialfirstPage));
            pictureBox_tutorialFirstPage_tutorialText = new PictureBox();
            button_tutorialFirstPage_ReturnToMainMenu = new Button();
            button_tutorialFirstPage_NextToTutorialSecondPage = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_tutorialFirstPage_tutorialText).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_tutorialFirstPage_tutorialText
            // 
            pictureBox_tutorialFirstPage_tutorialText.BackColor = Color.Transparent;
            pictureBox_tutorialFirstPage_tutorialText.Image = (Image)resources.GetObject("pictureBox_tutorialFirstPage_tutorialText.Image");
            pictureBox_tutorialFirstPage_tutorialText.Location = new Point(52, 24);
            pictureBox_tutorialFirstPage_tutorialText.Name = "pictureBox_tutorialFirstPage_tutorialText";
            pictureBox_tutorialFirstPage_tutorialText.Size = new Size(500, 133);
            pictureBox_tutorialFirstPage_tutorialText.TabIndex = 1;
            pictureBox_tutorialFirstPage_tutorialText.TabStop = false;
            // 
            // button_tutorialFirstPage_ReturnToMainMenu
            // 
            button_tutorialFirstPage_ReturnToMainMenu.BackColor = Color.Transparent;
            button_tutorialFirstPage_ReturnToMainMenu.BackgroundImage = (Image)resources.GetObject("button_tutorialFirstPage_ReturnToMainMenu.BackgroundImage");
            button_tutorialFirstPage_ReturnToMainMenu.Location = new Point(270, 764);
            button_tutorialFirstPage_ReturnToMainMenu.Name = "button_tutorialFirstPage_ReturnToMainMenu";
            button_tutorialFirstPage_ReturnToMainMenu.Size = new Size(33, 43);
            button_tutorialFirstPage_ReturnToMainMenu.TabIndex = 21;
            button_tutorialFirstPage_ReturnToMainMenu.UseVisualStyleBackColor = false;
            // 
            // button_tutorialFirstPage_NextToTutorialSecondPage
            // 
            button_tutorialFirstPage_NextToTutorialSecondPage.BackColor = Color.Transparent;
            button_tutorialFirstPage_NextToTutorialSecondPage.BackgroundImage = (Image)resources.GetObject("button_tutorialFirstPage_NextToTutorialSecondPage.BackgroundImage");
            button_tutorialFirstPage_NextToTutorialSecondPage.Location = new Point(245, 673);
            button_tutorialFirstPage_NextToTutorialSecondPage.Name = "button_tutorialFirstPage_NextToTutorialSecondPage";
            button_tutorialFirstPage_NextToTutorialSecondPage.Size = new Size(85, 75);
            button_tutorialFirstPage_NextToTutorialSecondPage.TabIndex = 22;
            button_tutorialFirstPage_NextToTutorialSecondPage.UseVisualStyleBackColor = false;
            // 
            // tutorialfirstPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button_tutorialFirstPage_NextToTutorialSecondPage);
            Controls.Add(button_tutorialFirstPage_ReturnToMainMenu);
            Controls.Add(pictureBox_tutorialFirstPage_tutorialText);
            Name = "tutorialfirstPage";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_tutorialFirstPage_tutorialText).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_tutorialFirstPage_tutorialText;
        private Button button_tutorialFirstPage_ReturnToMainMenu;
        private Button button_tutorialFirstPage_NextToTutorialSecondPage;
    }
}
