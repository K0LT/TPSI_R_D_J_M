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
            button_Tutorial2_Next = new Button();
            pictureBox_Tutorial2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Tutorial2).BeginInit();
            SuspendLayout();
            // 
            // button_Tutorial2_Next
            // 
            button_Tutorial2_Next.Cursor = Cursors.Hand;
            button_Tutorial2_Next.FlatStyle = FlatStyle.Flat;
            button_Tutorial2_Next.Image = (Image)resources.GetObject("button_Tutorial2_Next.Image");
            button_Tutorial2_Next.Location = new Point(255, 808);
            button_Tutorial2_Next.Name = "button_Tutorial2_Next";
            button_Tutorial2_Next.Size = new Size(106, 40);
            button_Tutorial2_Next.TabIndex = 27;
            button_Tutorial2_Next.UseVisualStyleBackColor = true;
            button_Tutorial2_Next.Click += button_Tutorial2_Next_Click;
            // 
            // pictureBox_Tutorial2
            // 
            pictureBox_Tutorial2.BackColor = Color.Transparent;
            pictureBox_Tutorial2.Image = (Image)resources.GetObject("pictureBox_Tutorial2.Image");
            pictureBox_Tutorial2.Location = new Point(55, 36);
            pictureBox_Tutorial2.Name = "pictureBox_Tutorial2";
            pictureBox_Tutorial2.Size = new Size(500, 750);
            pictureBox_Tutorial2.TabIndex = 25;
            pictureBox_Tutorial2.TabStop = false;
            // 
            // TutorialSecondPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button_Tutorial2_Next);
            Controls.Add(pictureBox_Tutorial2);
            Name = "TutorialSecondPage";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Tutorial2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button_Tutorial2_Next;
        private PictureBox pictureBox_Tutorial2;
    }
}
