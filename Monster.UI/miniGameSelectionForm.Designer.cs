namespace Monster.UI
{
    partial class miniGameSelectionForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxTicTacToe = new PictureBox();
            pictureBoxMemory = new PictureBox();
            pictureBoxQuickClick = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxTicTacToe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMemory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQuickClick).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxTicTacToe
            // 
            pictureBoxTicTacToe.Location = new Point(103, 94);
            pictureBoxTicTacToe.Name = "pictureBoxTicTacToe";
            pictureBoxTicTacToe.Size = new Size(158, 150);
            pictureBoxTicTacToe.TabIndex = 0;
            pictureBoxTicTacToe.TabStop = false;
            pictureBoxTicTacToe.Tag = "\"TicTacToe\"";
            // 
            // pictureBoxMemory
            // 
            pictureBoxMemory.Location = new Point(302, 94);
            pictureBoxMemory.Name = "pictureBoxMemory";
            pictureBoxMemory.Size = new Size(158, 150);
            pictureBoxMemory.TabIndex = 1;
            pictureBoxMemory.TabStop = false;
            pictureBoxMemory.Tag = "\"Memory\"";
            // 
            // pictureBoxQuickClick
            // 
            pictureBoxQuickClick.Location = new Point(501, 94);
            pictureBoxQuickClick.Name = "pictureBoxQuickClick";
            pictureBoxQuickClick.Size = new Size(158, 150);
            pictureBoxQuickClick.TabIndex = 2;
            pictureBoxQuickClick.TabStop = false;
            pictureBoxQuickClick.Tag = "\"QuickClick\"";
            // 
            // miniGameSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBoxQuickClick);
            Controls.Add(pictureBoxMemory);
            Controls.Add(pictureBoxTicTacToe);
            Name = "miniGameSelectionForm";
            Text = "miniGameSelectionForm";
            Load += miniGameSelectionForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxTicTacToe).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMemory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQuickClick).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxTicTacToe;
        private PictureBox pictureBoxMemory;
        private PictureBox pictureBoxQuickClick;
    }
}