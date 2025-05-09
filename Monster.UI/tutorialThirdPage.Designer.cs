namespace Monster.UI
{
    partial class tutorialThirdPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tutorialThirdPage));
            pictureBox_tutorialThirdPage_tutorialText = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_tutorialThirdPage_tutorialText).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_tutorialThirdPage_tutorialText
            // 
            pictureBox_tutorialThirdPage_tutorialText.BackColor = Color.Transparent;
            pictureBox_tutorialThirdPage_tutorialText.Image = (Image)resources.GetObject("pictureBox_tutorialThirdPage_tutorialText.Image");
            pictureBox_tutorialThirdPage_tutorialText.Location = new Point(36, 23);
            pictureBox_tutorialThirdPage_tutorialText.Name = "pictureBox_tutorialThirdPage_tutorialText";
            pictureBox_tutorialThirdPage_tutorialText.Size = new Size(500, 133);
            pictureBox_tutorialThirdPage_tutorialText.TabIndex = 3;
            pictureBox_tutorialThirdPage_tutorialText.TabStop = false;
            // 
            // tutorialThirdPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(pictureBox_tutorialThirdPage_tutorialText);
            Name = "tutorialThirdPage";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_tutorialThirdPage_tutorialText).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_tutorialThirdPage_tutorialText;
    }
}
