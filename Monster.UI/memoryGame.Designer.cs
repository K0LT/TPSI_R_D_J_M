namespace Monster.UI
{
    partial class memoryGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(memoryGame));
            pictureBox_memoryGames_MemoryGameText = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_memoryGames_MemoryGameText).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_memoryGames_MemoryGameText
            // 
            pictureBox_memoryGames_MemoryGameText.BackColor = Color.Transparent;
            pictureBox_memoryGames_MemoryGameText.Image = (Image)resources.GetObject("pictureBox_memoryGames_MemoryGameText.Image");
            pictureBox_memoryGames_MemoryGameText.Location = new Point(40, 31);
            pictureBox_memoryGames_MemoryGameText.Name = "pictureBox_memoryGames_MemoryGameText";
            pictureBox_memoryGames_MemoryGameText.Size = new Size(500, 133);
            pictureBox_memoryGames_MemoryGameText.TabIndex = 6;
            pictureBox_memoryGames_MemoryGameText.TabStop = false;
            // 
            // memoryGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(pictureBox_memoryGames_MemoryGameText);
            Name = "memoryGame";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_memoryGames_MemoryGameText).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_memoryGames_MemoryGameText;
    }
}
