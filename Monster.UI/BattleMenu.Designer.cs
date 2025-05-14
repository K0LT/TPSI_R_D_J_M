namespace Monster.UI
{
    partial class BattleMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BattleMenu));
            battleMenuTitleLabel = new Label();
            pictureBox_miniGames_Memory = new PictureBox();
            pictureBox1 = new PictureBox();
            nameMyMonsterLabel = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_miniGames_Memory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // battleMenuTitleLabel
            // 
            battleMenuTitleLabel.AutoSize = true;
            battleMenuTitleLabel.BackColor = Color.Transparent;
            battleMenuTitleLabel.Font = new Font("VCR OSD Mono", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            battleMenuTitleLabel.ForeColor = Color.DarkGoldenrod;
            battleMenuTitleLabel.Location = new Point(36, 49);
            battleMenuTitleLabel.Name = "battleMenuTitleLabel";
            battleMenuTitleLabel.Size = new Size(521, 64);
            battleMenuTitleLabel.TabIndex = 23;
            battleMenuTitleLabel.Text = "Choose Battle";
            // 
            // pictureBox_miniGames_Memory
            // 
            pictureBox_miniGames_Memory.Image = (Image)resources.GetObject("pictureBox_miniGames_Memory.Image");
            pictureBox_miniGames_Memory.Location = new Point(36, 172);
            pictureBox_miniGames_Memory.Name = "pictureBox_miniGames_Memory";
            pictureBox_miniGames_Memory.Size = new Size(250, 587);
            pictureBox_miniGames_Memory.TabIndex = 25;
            pictureBox_miniGames_Memory.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(308, 172);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 587);
            pictureBox1.TabIndex = 26;
            pictureBox1.TabStop = false;
            // 
            // nameMyMonsterLabel
            // 
            nameMyMonsterLabel.AutoSize = true;
            nameMyMonsterLabel.BackColor = Color.Transparent;
            nameMyMonsterLabel.Font = new Font("VCR OSD Mono", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameMyMonsterLabel.ForeColor = Color.DarkGoldenrod;
            nameMyMonsterLabel.Location = new Point(60, 788);
            nameMyMonsterLabel.Name = "nameMyMonsterLabel";
            nameMyMonsterLabel.Size = new Size(213, 29);
            nameMyMonsterLabel.TabIndex = 27;
            nameMyMonsterLabel.Text = "Demon Lvl. 3";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("VCR OSD Mono", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkGoldenrod;
            label1.Location = new Point(322, 788);
            label1.Name = "label1";
            label1.Size = new Size(216, 29);
            label1.TabIndex = 28;
            label1.Text = "Skull Lvl. 7";
            // 
            // BattleMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            Controls.Add(label1);
            Controls.Add(nameMyMonsterLabel);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox_miniGames_Memory);
            Controls.Add(battleMenuTitleLabel);
            DoubleBuffered = true;
            Name = "BattleMenu";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_miniGames_Memory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label battleMenuTitleLabel;
        private PictureBox pictureBox_miniGames_Memory;
        private PictureBox pictureBox1;
        private Label nameMyMonsterLabel;
        private Label label1;
    }
}
