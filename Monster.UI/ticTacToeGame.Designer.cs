namespace Monster.UI
{
    partial class ticTacToeGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ticTacToeGame));
            pictureBox_ticTacToeGame_TicTacToeText = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_ticTacToeGame_TicTacToeText).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_ticTacToeGame_TicTacToeText
            // 
            pictureBox_ticTacToeGame_TicTacToeText.BackColor = Color.Transparent;
            pictureBox_ticTacToeGame_TicTacToeText.Image = (Image)resources.GetObject("pictureBox_ticTacToeGame_TicTacToeText.Image");
            pictureBox_ticTacToeGame_TicTacToeText.Location = new Point(50, 41);
            pictureBox_ticTacToeGame_TicTacToeText.Name = "pictureBox_ticTacToeGame_TicTacToeText";
            pictureBox_ticTacToeGame_TicTacToeText.Size = new Size(500, 133);
            pictureBox_ticTacToeGame_TicTacToeText.TabIndex = 5;
            pictureBox_ticTacToeGame_TicTacToeText.TabStop = false;
            // 
            // ticTacToeGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(pictureBox_ticTacToeGame_TicTacToeText);
            Name = "ticTacToeGame";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_ticTacToeGame_TicTacToeText).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_ticTacToeGame_TicTacToeText;
    }
}
