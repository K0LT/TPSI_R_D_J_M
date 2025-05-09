namespace Monster.UI
{
    partial class newGamePlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newGamePlayer));
            pictureBox_newGamePlayer_Male = new PictureBox();
            pictureBox_newGamePlayer_Female = new PictureBox();
            panel1 = new Panel();
            button_newGamePlayer_RegisterText = new Button();
            button_newGamePlayer_Next = new Button();
            textBox_newGamePlayer_InputForUsername = new TextBox();
            label_newGamePlayer_UsernameText = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_newGamePlayer_Male).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_newGamePlayer_Female).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_newGamePlayer_Male
            // 
            pictureBox_newGamePlayer_Male.BackColor = Color.Transparent;
            pictureBox_newGamePlayer_Male.Image = (Image)resources.GetObject("pictureBox_newGamePlayer_Male.Image");
            pictureBox_newGamePlayer_Male.Location = new Point(54, 193);
            pictureBox_newGamePlayer_Male.Name = "pictureBox_newGamePlayer_Male";
            pictureBox_newGamePlayer_Male.Size = new Size(196, 215);
            pictureBox_newGamePlayer_Male.TabIndex = 0;
            pictureBox_newGamePlayer_Male.TabStop = false;
            // 
            // pictureBox_newGamePlayer_Female
            // 
            pictureBox_newGamePlayer_Female.BackColor = Color.Transparent;
            pictureBox_newGamePlayer_Female.Image = (Image)resources.GetObject("pictureBox_newGamePlayer_Female.Image");
            pictureBox_newGamePlayer_Female.Location = new Point(320, 193);
            pictureBox_newGamePlayer_Female.Name = "pictureBox_newGamePlayer_Female";
            pictureBox_newGamePlayer_Female.Size = new Size(218, 215);
            pictureBox_newGamePlayer_Female.TabIndex = 1;
            pictureBox_newGamePlayer_Female.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(164, 131, 91);
            panel1.Controls.Add(button_newGamePlayer_RegisterText);
            panel1.Controls.Add(button_newGamePlayer_Next);
            panel1.Controls.Add(textBox_newGamePlayer_InputForUsername);
            panel1.Controls.Add(label_newGamePlayer_UsernameText);
            panel1.Location = new Point(105, 517);
            panel1.Name = "panel1";
            panel1.Size = new Size(335, 171);
            panel1.TabIndex = 4;
            // 
            // button_newGamePlayer_RegisterText
            // 
            button_newGamePlayer_RegisterText.Location = new Point(128, 95);
            button_newGamePlayer_RegisterText.Name = "button_newGamePlayer_RegisterText";
            button_newGamePlayer_RegisterText.Size = new Size(75, 23);
            button_newGamePlayer_RegisterText.TabIndex = 2;
            button_newGamePlayer_RegisterText.Text = "Register";
            button_newGamePlayer_RegisterText.UseVisualStyleBackColor = true;
            // 
            // button_newGamePlayer_Next
            // 
            button_newGamePlayer_Next.Location = new Point(128, 137);
            button_newGamePlayer_Next.Name = "button_newGamePlayer_Next";
            button_newGamePlayer_Next.Size = new Size(75, 23);
            button_newGamePlayer_Next.TabIndex = 3;
            button_newGamePlayer_Next.Text = "Next";
            button_newGamePlayer_Next.UseVisualStyleBackColor = true;
            // 
            // textBox_newGamePlayer_InputForUsername
            // 
            textBox_newGamePlayer_InputForUsername.Location = new Point(167, 38);
            textBox_newGamePlayer_InputForUsername.Name = "textBox_newGamePlayer_InputForUsername";
            textBox_newGamePlayer_InputForUsername.Size = new Size(142, 23);
            textBox_newGamePlayer_InputForUsername.TabIndex = 1;
            // 
            // label_newGamePlayer_UsernameText
            // 
            label_newGamePlayer_UsernameText.AutoSize = true;
            label_newGamePlayer_UsernameText.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_newGamePlayer_UsernameText.ForeColor = Color.FromArgb(54, 39, 22);
            label_newGamePlayer_UsernameText.Location = new Point(15, 28);
            label_newGamePlayer_UsernameText.Name = "label_newGamePlayer_UsernameText";
            label_newGamePlayer_UsernameText.Size = new Size(160, 37);
            label_newGamePlayer_UsernameText.TabIndex = 0;
            label_newGamePlayer_UsernameText.Text = "Username: ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(772, 795);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(44, 44);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // newGamePlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(54, 39, 22);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(pictureBox_newGamePlayer_Female);
            Controls.Add(pictureBox_newGamePlayer_Male);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "newGamePlayer";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_newGamePlayer_Male).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_newGamePlayer_Female).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_newGamePlayer_Male;
        private PictureBox pictureBox_newGamePlayer_Female;
        private Panel panel1;
        private Label label_newGamePlayer_UsernameText;
        private Button button_newGamePlayer_RegisterText;
        private TextBox textBox_newGamePlayer_InputForUsername;
        private Button button_newGamePlayer_Next;
        private PictureBox pictureBox1;
    }
}
