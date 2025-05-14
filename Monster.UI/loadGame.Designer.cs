namespace Monster.UI
{
    partial class loadGame
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loadGame));
            buttonLoadGameNext = new Button();
            loadGameLabel = new Label();
            label_newGamePlayer_UsernameText = new PictureBox();
            textBox_LoadGame_InputForUsername = new TextBox();
            button_LoadGame_Exit = new Button();
            ((System.ComponentModel.ISupportInitialize)label_newGamePlayer_UsernameText).BeginInit();
            SuspendLayout();
            // 
            // buttonLoadGameNext
            // 
            buttonLoadGameNext.FlatStyle = FlatStyle.Flat;
            buttonLoadGameNext.Image = (Image)resources.GetObject("buttonLoadGameNext.Image");
            buttonLoadGameNext.Location = new Point(258, 508);
            buttonLoadGameNext.Name = "buttonLoadGameNext";
            buttonLoadGameNext.Size = new Size(106, 40);
            buttonLoadGameNext.TabIndex = 1;
            buttonLoadGameNext.UseVisualStyleBackColor = true;
            buttonLoadGameNext.Click += button1_Click;
            // 
            // loadGameLabel
            // 
            loadGameLabel.AutoSize = true;
            loadGameLabel.BackColor = Color.Transparent;
            loadGameLabel.Font = new Font("VCR OSD Mono", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadGameLabel.ForeColor = Color.DarkGoldenrod;
            loadGameLabel.Location = new Point(131, 118);
            loadGameLabel.Name = "loadGameLabel";
            loadGameLabel.Size = new Size(369, 64);
            loadGameLabel.TabIndex = 2;
            loadGameLabel.Text = "Load Game";
            // 
            // label_newGamePlayer_UsernameText
            // 
            label_newGamePlayer_UsernameText.Image = (Image)resources.GetObject("label_newGamePlayer_UsernameText.Image");
            label_newGamePlayer_UsernameText.Location = new Point(158, 346);
            label_newGamePlayer_UsernameText.Name = "label_newGamePlayer_UsernameText";
            label_newGamePlayer_UsernameText.Size = new Size(106, 30);
            label_newGamePlayer_UsernameText.TabIndex = 15;
            label_newGamePlayer_UsernameText.TabStop = false;
            // 
            // textBox_LoadGame_InputForUsername
            // 
            textBox_LoadGame_InputForUsername.Cursor = Cursors.IBeam;
            textBox_LoadGame_InputForUsername.Font = new Font("VCR OSD Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_LoadGame_InputForUsername.Location = new Point(275, 347);
            textBox_LoadGame_InputForUsername.Name = "textBox_LoadGame_InputForUsername";
            textBox_LoadGame_InputForUsername.Size = new Size(183, 26);
            textBox_LoadGame_InputForUsername.TabIndex = 14;
            // 
            // button_LoadGame_Exit
            // 
            button_LoadGame_Exit.BackColor = Color.Transparent;
            button_LoadGame_Exit.BackgroundImage = (Image)resources.GetObject("button_LoadGame_Exit.BackgroundImage");
            button_LoadGame_Exit.FlatAppearance.BorderSize = 0;
            button_LoadGame_Exit.FlatStyle = FlatStyle.Flat;
            button_LoadGame_Exit.Location = new Point(555, 0);
            button_LoadGame_Exit.Name = "button_LoadGame_Exit";
            button_LoadGame_Exit.Size = new Size(45, 45);
            button_LoadGame_Exit.TabIndex = 22;
            button_LoadGame_Exit.UseVisualStyleBackColor = false;
            button_LoadGame_Exit.Click += button_LoadGame_Exit_Click;
            // 
            // loadGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button_LoadGame_Exit);
            Controls.Add(label_newGamePlayer_UsernameText);
            Controls.Add(textBox_LoadGame_InputForUsername);
            Controls.Add(loadGameLabel);
            Controls.Add(buttonLoadGameNext);
            Name = "loadGame";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)label_newGamePlayer_UsernameText).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button buttonLoadGameNext;
        private Label loadGameLabel;
        private PictureBox label_newGamePlayer_UsernameText;
        private TextBox textBox_LoadGame_InputForUsername;
        private Button button_LoadGame_Exit;
    }
}
