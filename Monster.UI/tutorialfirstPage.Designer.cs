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
            // tutorialfirstPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(pictureBox_tutorialFirstPage_tutorialText);
            Name = "tutorialfirstPage";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_tutorialFirstPage_tutorialText).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_tutorialFirstPage_tutorialText;
    }
}
