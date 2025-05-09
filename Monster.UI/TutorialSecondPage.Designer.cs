namespace Monster.UI
{
    partial class TutorialSecondPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TutorialSecondPage));
            pictureBox_tutorialSecondPage_tutorial = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_tutorialSecondPage_tutorial).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_tutorialSecondPage_tutorial
            // 
            pictureBox_tutorialSecondPage_tutorial.BackColor = Color.Transparent;
            pictureBox_tutorialSecondPage_tutorial.Image = (Image)resources.GetObject("pictureBox_tutorialSecondPage_tutorial.Image");
            pictureBox_tutorialSecondPage_tutorial.Location = new Point(38, 27);
            pictureBox_tutorialSecondPage_tutorial.Name = "pictureBox_tutorialSecondPage_tutorial";
            pictureBox_tutorialSecondPage_tutorial.Size = new Size(500, 133);
            pictureBox_tutorialSecondPage_tutorial.TabIndex = 2;
            pictureBox_tutorialSecondPage_tutorial.TabStop = false;
            // 
            // TutorialSecondPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(pictureBox_tutorialSecondPage_tutorial);
            Name = "TutorialSecondPage";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_tutorialSecondPage_tutorial).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_tutorialSecondPage_tutorial;
    }
}
