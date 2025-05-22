namespace Monster.UI
{
    partial class battleGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(battleGame));
            pictureBox_battleGame_myMonster = new PictureBox();
            pictureBox_battleGame_Boss = new PictureBox();
            progressBar_battleGame_BossHP = new GoldProgressBar();
            progressBar_battleGame_MyMonsterHp = new GoldProgressBar();
            pictureBox_myMonster_HPicon = new PictureBox();
            pictureBox1 = new PictureBox();
            label_battle_Name = new Label();
            button_Battle_Attack1 = new Button();
            button_Battle_Attack2 = new Button();
            progressBar_battleGame_MyMonsterEnergy = new GoldProgressBar();
            pictureBox2 = new PictureBox();
            label_Message = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_battleGame_myMonster).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_battleGame_Boss).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_myMonster_HPicon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_battleGame_myMonster
            // 
            pictureBox_battleGame_myMonster.BackColor = Color.Transparent;
            pictureBox_battleGame_myMonster.Location = new Point(33, 633);
            pictureBox_battleGame_myMonster.Name = "pictureBox_battleGame_myMonster";
            pictureBox_battleGame_myMonster.Size = new Size(200, 200);
            pictureBox_battleGame_myMonster.TabIndex = 0;
            pictureBox_battleGame_myMonster.TabStop = false;
            // 
            // pictureBox_battleGame_Boss
            // 
            pictureBox_battleGame_Boss.BackColor = Color.Transparent;
            pictureBox_battleGame_Boss.Location = new Point(147, 4);
            pictureBox_battleGame_Boss.Name = "pictureBox_battleGame_Boss";
            pictureBox_battleGame_Boss.Size = new Size(450, 450);
            pictureBox_battleGame_Boss.TabIndex = 1;
            pictureBox_battleGame_Boss.TabStop = false;
            // 
            // progressBar_battleGame_BossHP
            // 
            progressBar_battleGame_BossHP.BackColor = Color.AntiqueWhite;
            progressBar_battleGame_BossHP.ForeColor = Color.Gold;
            progressBar_battleGame_BossHP.Location = new Point(355, 476);
            progressBar_battleGame_BossHP.Name = "progressBar_battleGame_BossHP";
            progressBar_battleGame_BossHP.Size = new Size(235, 23);
            progressBar_battleGame_BossHP.TabIndex = 2;
            // 
            // progressBar_battleGame_MyMonsterHp
            // 
            progressBar_battleGame_MyMonsterHp.BackColor = Color.AntiqueWhite;
            progressBar_battleGame_MyMonsterHp.ForeColor = Color.Gold;
            progressBar_battleGame_MyMonsterHp.Location = new Point(320, 668);
            progressBar_battleGame_MyMonsterHp.Name = "progressBar_battleGame_MyMonsterHp";
            progressBar_battleGame_MyMonsterHp.Size = new Size(235, 23);
            progressBar_battleGame_MyMonsterHp.TabIndex = 3;
            // 
            // pictureBox_myMonster_HPicon
            // 
            pictureBox_myMonster_HPicon.BackColor = Color.Transparent;
            pictureBox_myMonster_HPicon.Image = (Image)resources.GetObject("pictureBox_myMonster_HPicon.Image");
            pictureBox_myMonster_HPicon.Location = new Point(289, 462);
            pictureBox_myMonster_HPicon.Name = "pictureBox_myMonster_HPicon";
            pictureBox_myMonster_HPicon.Size = new Size(50, 50);
            pictureBox_myMonster_HPicon.TabIndex = 13;
            pictureBox_myMonster_HPicon.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(254, 641);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // label_battle_Name
            // 
            label_battle_Name.AutoSize = true;
            label_battle_Name.BackColor = Color.Transparent;
            label_battle_Name.Font = new Font("VCR OSD Mono", 14.25F);
            label_battle_Name.ForeColor = Color.Goldenrod;
            label_battle_Name.Location = new Point(254, 603);
            label_battle_Name.Name = "label_battle_Name";
            label_battle_Name.Size = new Size(54, 19);
            label_battle_Name.TabIndex = 15;
            label_battle_Name.Text = "name";
            // 
            // button_Battle_Attack1
            // 
            button_Battle_Attack1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_Battle_Attack1.BackgroundImage = (Image)resources.GetObject("button_Battle_Attack1.BackgroundImage");
            button_Battle_Attack1.BackgroundImageLayout = ImageLayout.Center;
            button_Battle_Attack1.Cursor = Cursors.Hand;
            button_Battle_Attack1.FlatStyle = FlatStyle.Flat;
            button_Battle_Attack1.Font = new Font("VCR OSD Mono", 12F);
            button_Battle_Attack1.Location = new Point(254, 782);
            button_Battle_Attack1.Name = "button_Battle_Attack1";
            button_Battle_Attack1.Size = new Size(140, 51);
            button_Battle_Attack1.TabIndex = 16;
            button_Battle_Attack1.Text = "Attack 1";
            button_Battle_Attack1.UseVisualStyleBackColor = true;
            button_Battle_Attack1.Click += button_Battle_Attack1_Click;
            // 
            // button_Battle_Attack2
            // 
            button_Battle_Attack2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_Battle_Attack2.BackgroundImage = (Image)resources.GetObject("button_Battle_Attack2.BackgroundImage");
            button_Battle_Attack2.BackgroundImageLayout = ImageLayout.Center;
            button_Battle_Attack2.Cursor = Cursors.Hand;
            button_Battle_Attack2.FlatStyle = FlatStyle.Flat;
            button_Battle_Attack2.Font = new Font("VCR OSD Mono", 12F);
            button_Battle_Attack2.Location = new Point(415, 782);
            button_Battle_Attack2.Name = "button_Battle_Attack2";
            button_Battle_Attack2.Size = new Size(140, 51);
            button_Battle_Attack2.TabIndex = 17;
            button_Battle_Attack2.Text = "Attack 2";
            button_Battle_Attack2.UseVisualStyleBackColor = true;
            button_Battle_Attack2.Click += button_Battle_Attack2_Click;
            // 
            // progressBar_battleGame_MyMonsterEnergy
            // 
            progressBar_battleGame_MyMonsterEnergy.BackColor = Color.AntiqueWhite;
            progressBar_battleGame_MyMonsterEnergy.ForeColor = Color.Gold;
            progressBar_battleGame_MyMonsterEnergy.Location = new Point(320, 723);
            progressBar_battleGame_MyMonsterEnergy.Name = "progressBar_battleGame_MyMonsterEnergy";
            progressBar_battleGame_MyMonsterEnergy.Size = new Size(235, 23);
            progressBar_battleGame_MyMonsterEnergy.TabIndex = 18;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(254, 708);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.TabIndex = 19;
            pictureBox2.TabStop = false;
            // 
            // label_Message
            // 
            label_Message.BackColor = Color.Transparent;
            label_Message.Font = new Font("VCR OSD Mono", 14.25F);
            label_Message.ForeColor = Color.Gold;
            label_Message.Location = new Point(3, 441);
            label_Message.Name = "label_Message";
            label_Message.Size = new Size(283, 153);
            label_Message.TabIndex = 20;
            label_Message.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // battleGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(label_Message);
            Controls.Add(pictureBox2);
            Controls.Add(progressBar_battleGame_MyMonsterEnergy);
            Controls.Add(button_Battle_Attack2);
            Controls.Add(button_Battle_Attack1);
            Controls.Add(label_battle_Name);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox_myMonster_HPicon);
            Controls.Add(progressBar_battleGame_MyMonsterHp);
            Controls.Add(progressBar_battleGame_BossHP);
            Controls.Add(pictureBox_battleGame_Boss);
            Controls.Add(pictureBox_battleGame_myMonster);
            Name = "battleGame";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_battleGame_myMonster).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_battleGame_Boss).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_myMonster_HPicon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_battleGame_myMonster;
        private PictureBox pictureBox_battleGame_Boss;
        private GoldProgressBar progressBar_battleGame_BossHP;
        private GoldProgressBar progressBar_battleGame_MyMonsterHp;
        private PictureBox pictureBox_myMonster_HPicon;
        private PictureBox pictureBox1;
        private Label label_battle_Name;
        private Button button_Battle_Attack1;
        private Button button_Battle_Attack2;
        private GoldProgressBar progressBar_battleGame_MyMonsterEnergy;
        private PictureBox pictureBox2;
        private Label label_Message;
    }
}
