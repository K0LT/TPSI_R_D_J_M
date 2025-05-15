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
            pictureBox_Tutorial1 = new PictureBox();
            button_Tutorial1_Next = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Tutorial1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_Tutorial1
            // 
            pictureBox_Tutorial1.BackColor = Color.Transparent;
            pictureBox_Tutorial1.Image = (Image)resources.GetObject("pictureBox_Tutorial1.Image");
            pictureBox_Tutorial1.Location = new Point(55, 36);
            pictureBox_Tutorial1.Name = "pictureBox_Tutorial1";
            pictureBox_Tutorial1.Size = new Size(500, 750);
            pictureBox_Tutorial1.TabIndex = 0;
            pictureBox_Tutorial1.TabStop = false;
            // 
            // button_Tutorial1_Next
            // 
            button_Tutorial1_Next.FlatStyle = FlatStyle.Flat;
            button_Tutorial1_Next.Image = (Image)resources.GetObject("button_Tutorial1_Next.Image");
            button_Tutorial1_Next.Location = new Point(255, 808);
            button_Tutorial1_Next.Name = "button_Tutorial1_Next";
            button_Tutorial1_Next.Size = new Size(106, 40);
            button_Tutorial1_Next.TabIndex = 24;
            button_Tutorial1_Next.UseVisualStyleBackColor = true;
            button_Tutorial1_Next.Click += button_Tutorial1_Next_Click;
            // 
            // tutorialfirstPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button_Tutorial1_Next);
            Controls.Add(pictureBox_Tutorial1);
            Name = "tutorialfirstPage";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Tutorial1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_Tutorial1;
        private Button button_Tutorial1_Next;
    }
}
