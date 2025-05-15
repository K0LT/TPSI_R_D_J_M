namespace Monster.UI
{
    partial class myMonster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myMonster));
            pictureBox_myMonster_EXPicon = new PictureBox();
            pictureBox_myMonster_STicon = new PictureBox();
            progressBar_myMonster_EXP = new ProgressBar();
            progressBar_myMonster_ST = new ProgressBar();
            pictureBox_myMonster_HPicon = new PictureBox();
            progressBar_myMonster_HP = new ProgressBar();
            pictureBox_myMonster = new PictureBox();
            button_myMonster_Food = new Button();
            button_myMonster_Sleep = new Button();
            button_myMonster_Inventory = new Button();
            button_myMonster_Player = new Button();
            button_myMonster_Save = new Button();
            button_myMonster_ReturnToMainMenu = new Button();
            button_myMonster_Battle = new Button();
            button_myMonster_MiniGames = new Button();
            nameMyMonsterLabel = new Label();
            levelMyMonster = new Label();
            label_MyMonster_LVL = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox_myMonster_EXPicon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_myMonster_STicon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_myMonster_HPicon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_myMonster).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_myMonster_EXPicon
            // 
            pictureBox_myMonster_EXPicon.Image = (Image)resources.GetObject("pictureBox_myMonster_EXPicon.Image");
            pictureBox_myMonster_EXPicon.Location = new Point(66, 565);
            pictureBox_myMonster_EXPicon.Name = "pictureBox_myMonster_EXPicon";
            pictureBox_myMonster_EXPicon.Size = new Size(51, 50);
            pictureBox_myMonster_EXPicon.TabIndex = 6;
            pictureBox_myMonster_EXPicon.TabStop = false;
            // 
            // pictureBox_myMonster_STicon
            // 
            pictureBox_myMonster_STicon.Image = (Image)resources.GetObject("pictureBox_myMonster_STicon.Image");
            pictureBox_myMonster_STicon.Location = new Point(66, 505);
            pictureBox_myMonster_STicon.Name = "pictureBox_myMonster_STicon";
            pictureBox_myMonster_STicon.Size = new Size(51, 50);
            pictureBox_myMonster_STicon.TabIndex = 5;
            pictureBox_myMonster_STicon.TabStop = false;
            // 
            // progressBar_myMonster_EXP
            // 
            progressBar_myMonster_EXP.Location = new Point(134, 575);
            progressBar_myMonster_EXP.Name = "progressBar_myMonster_EXP";
            progressBar_myMonster_EXP.Size = new Size(377, 27);
            progressBar_myMonster_EXP.TabIndex = 2;
            // 
            // progressBar_myMonster_ST
            // 
            progressBar_myMonster_ST.Location = new Point(134, 515);
            progressBar_myMonster_ST.Name = "progressBar_myMonster_ST";
            progressBar_myMonster_ST.Size = new Size(377, 27);
            progressBar_myMonster_ST.TabIndex = 1;
            // 
            // pictureBox_myMonster_HPicon
            // 
            pictureBox_myMonster_HPicon.Image = (Image)resources.GetObject("pictureBox_myMonster_HPicon.Image");
            pictureBox_myMonster_HPicon.Location = new Point(66, 445);
            pictureBox_myMonster_HPicon.Name = "pictureBox_myMonster_HPicon";
            pictureBox_myMonster_HPicon.Size = new Size(50, 50);
            pictureBox_myMonster_HPicon.TabIndex = 4;
            pictureBox_myMonster_HPicon.TabStop = false;
            // 
            // progressBar_myMonster_HP
            // 
            progressBar_myMonster_HP.Location = new Point(134, 456);
            progressBar_myMonster_HP.Name = "progressBar_myMonster_HP";
            progressBar_myMonster_HP.Size = new Size(377, 27);
            progressBar_myMonster_HP.TabIndex = 0;
            // 
            // pictureBox_myMonster
            // 
            pictureBox_myMonster.BackColor = Color.Transparent;
            pictureBox_myMonster.Image = (Image)resources.GetObject("pictureBox_myMonster.Image");
            pictureBox_myMonster.Location = new Point(87, -2);
            pictureBox_myMonster.Name = "pictureBox_myMonster";
            pictureBox_myMonster.Size = new Size(410, 410);
            pictureBox_myMonster.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox_myMonster.TabIndex = 3;
            pictureBox_myMonster.TabStop = false;
            // 
            // button_myMonster_Food
            // 
            button_myMonster_Food.BackgroundImage = (Image)resources.GetObject("button_myMonster_Food.BackgroundImage");
            button_myMonster_Food.FlatAppearance.BorderSize = 0;
            button_myMonster_Food.FlatStyle = FlatStyle.Flat;
            button_myMonster_Food.Location = new Point(66, 630);
            button_myMonster_Food.Name = "button_myMonster_Food";
            button_myMonster_Food.Size = new Size(50, 50);
            button_myMonster_Food.TabIndex = 7;
            button_myMonster_Food.UseVisualStyleBackColor = true;
            button_myMonster_Food.Click += button_myMonster_Food_Click;
            // 
            // button_myMonster_Sleep
            // 
            button_myMonster_Sleep.BackgroundImage = (Image)resources.GetObject("button_myMonster_Sleep.BackgroundImage");
            button_myMonster_Sleep.FlatAppearance.BorderSize = 0;
            button_myMonster_Sleep.FlatStyle = FlatStyle.Flat;
            button_myMonster_Sleep.Location = new Point(155, 630);
            button_myMonster_Sleep.Name = "button_myMonster_Sleep";
            button_myMonster_Sleep.Size = new Size(50, 50);
            button_myMonster_Sleep.TabIndex = 8;
            button_myMonster_Sleep.UseVisualStyleBackColor = true;
            button_myMonster_Sleep.Click += button_myMonster_Sleep_Click;
            // 
            // button_myMonster_Inventory
            // 
            button_myMonster_Inventory.BackgroundImage = (Image)resources.GetObject("button_myMonster_Inventory.BackgroundImage");
            button_myMonster_Inventory.FlatAppearance.BorderSize = 0;
            button_myMonster_Inventory.FlatStyle = FlatStyle.Flat;
            button_myMonster_Inventory.Location = new Point(66, 707);
            button_myMonster_Inventory.Name = "button_myMonster_Inventory";
            button_myMonster_Inventory.Size = new Size(50, 50);
            button_myMonster_Inventory.TabIndex = 9;
            button_myMonster_Inventory.UseVisualStyleBackColor = true;
            button_myMonster_Inventory.Click += button_myMonster_Inventory_Click;
            // 
            // button_myMonster_Player
            // 
            button_myMonster_Player.BackgroundImage = (Image)resources.GetObject("button_myMonster_Player.BackgroundImage");
            button_myMonster_Player.FlatAppearance.BorderSize = 0;
            button_myMonster_Player.FlatStyle = FlatStyle.Flat;
            button_myMonster_Player.Location = new Point(155, 707);
            button_myMonster_Player.Name = "button_myMonster_Player";
            button_myMonster_Player.Size = new Size(50, 50);
            button_myMonster_Player.TabIndex = 10;
            button_myMonster_Player.UseVisualStyleBackColor = true;
            button_myMonster_Player.Click += button_myMonster_Player_Click;
            // 
            // button_myMonster_Save
            // 
            button_myMonster_Save.BackgroundImage = (Image)resources.GetObject("button_myMonster_Save.BackgroundImage");
            button_myMonster_Save.FlatAppearance.BorderSize = 0;
            button_myMonster_Save.FlatStyle = FlatStyle.Flat;
            button_myMonster_Save.Location = new Point(66, 783);
            button_myMonster_Save.Name = "button_myMonster_Save";
            button_myMonster_Save.Size = new Size(50, 50);
            button_myMonster_Save.TabIndex = 11;
            button_myMonster_Save.UseVisualStyleBackColor = true;
            button_myMonster_Save.Click += button_myMonster_Save_Click;
            // 
            // button_myMonster_ReturnToMainMenu
            // 
            button_myMonster_ReturnToMainMenu.BackgroundImage = (Image)resources.GetObject("button_myMonster_ReturnToMainMenu.BackgroundImage");
            button_myMonster_ReturnToMainMenu.FlatAppearance.BorderSize = 0;
            button_myMonster_ReturnToMainMenu.FlatStyle = FlatStyle.Flat;
            button_myMonster_ReturnToMainMenu.Location = new Point(155, 783);
            button_myMonster_ReturnToMainMenu.Name = "button_myMonster_ReturnToMainMenu";
            button_myMonster_ReturnToMainMenu.Size = new Size(50, 50);
            button_myMonster_ReturnToMainMenu.TabIndex = 12;
            button_myMonster_ReturnToMainMenu.UseVisualStyleBackColor = true;
            button_myMonster_ReturnToMainMenu.Click += button_myMonster_ReturnToMainMenu_Click;
            // 
            // button_myMonster_Battle
            // 
            button_myMonster_Battle.BackgroundImage = (Image)resources.GetObject("button_myMonster_Battle.BackgroundImage");
            button_myMonster_Battle.FlatAppearance.BorderSize = 0;
            button_myMonster_Battle.FlatStyle = FlatStyle.Flat;
            button_myMonster_Battle.Location = new Point(321, 630);
            button_myMonster_Battle.Name = "button_myMonster_Battle";
            button_myMonster_Battle.Size = new Size(190, 91);
            button_myMonster_Battle.TabIndex = 13;
            button_myMonster_Battle.UseVisualStyleBackColor = true;
            button_myMonster_Battle.Click += button_myMonster_Battle_Click;
            // 
            // button_myMonster_MiniGames
            // 
            button_myMonster_MiniGames.BackgroundImage = (Image)resources.GetObject("button_myMonster_MiniGames.BackgroundImage");
            button_myMonster_MiniGames.FlatAppearance.BorderSize = 0;
            button_myMonster_MiniGames.FlatStyle = FlatStyle.Flat;
            button_myMonster_MiniGames.Location = new Point(321, 753);
            button_myMonster_MiniGames.Name = "button_myMonster_MiniGames";
            button_myMonster_MiniGames.Size = new Size(190, 80);
            button_myMonster_MiniGames.TabIndex = 14;
            button_myMonster_MiniGames.UseVisualStyleBackColor = true;
            button_myMonster_MiniGames.Click += button_myMonster_MiniGames_Click;
            // 
            // nameMyMonsterLabel
            // 
            nameMyMonsterLabel.AutoSize = true;
            nameMyMonsterLabel.BackColor = Color.Transparent;
            nameMyMonsterLabel.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameMyMonsterLabel.ForeColor = Color.DarkGoldenrod;
            nameMyMonsterLabel.Location = new Point(174, 411);
            nameMyMonsterLabel.Name = "nameMyMonsterLabel";
            nameMyMonsterLabel.Size = new Size(93, 33);
            nameMyMonsterLabel.TabIndex = 22;
            nameMyMonsterLabel.Text = "Name";
            // 
            // levelMyMonster
            // 
            levelMyMonster.AutoSize = true;
            levelMyMonster.BackColor = Color.Transparent;
            levelMyMonster.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            levelMyMonster.ForeColor = Color.DarkGoldenrod;
            levelMyMonster.Location = new Point(432, 411);
            levelMyMonster.Name = "levelMyMonster";
            levelMyMonster.Size = new Size(31, 33);
            levelMyMonster.TabIndex = 23;
            levelMyMonster.Text = "#";
            // 
            // label_MyMonster_LVL
            // 
            label_MyMonster_LVL.AutoSize = true;
            label_MyMonster_LVL.BackColor = Color.Transparent;
            label_MyMonster_LVL.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_MyMonster_LVL.ForeColor = Color.DarkGoldenrod;
            label_MyMonster_LVL.Location = new Point(351, 411);
            label_MyMonster_LVL.Name = "label_MyMonster_LVL";
            label_MyMonster_LVL.Size = new Size(61, 33);
            label_MyMonster_LVL.TabIndex = 24;
            label_MyMonster_LVL.Text = "Lvl.";
            // 
            // myMonster
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(54, 39, 22);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(label_MyMonster_LVL);
            Controls.Add(levelMyMonster);
            Controls.Add(nameMyMonsterLabel);
            Controls.Add(button_myMonster_MiniGames);
            Controls.Add(button_myMonster_Battle);
            Controls.Add(button_myMonster_ReturnToMainMenu);
            Controls.Add(button_myMonster_Save);
            Controls.Add(button_myMonster_Player);
            Controls.Add(button_myMonster_Inventory);
            Controls.Add(button_myMonster_Sleep);
            Controls.Add(button_myMonster_Food);
            Controls.Add(pictureBox_myMonster);
            Controls.Add(progressBar_myMonster_EXP);
            Controls.Add(pictureBox_myMonster_HPicon);
            Controls.Add(progressBar_myMonster_ST);
            Controls.Add(pictureBox_myMonster_EXPicon);
            Controls.Add(progressBar_myMonster_HP);
            Controls.Add(pictureBox_myMonster_STicon);
            Name = "myMonster";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_myMonster_EXPicon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_myMonster_STicon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_myMonster_HPicon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox_myMonster).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox_myMonster_HPicon;
        private ProgressBar progressBar_myMonster_EXP;
        private ProgressBar progressBar_myMonster_ST;
        private ProgressBar progressBar_myMonster_HP;
        private PictureBox pictureBox_myMonster_EXPicon;
        private PictureBox pictureBox_myMonster_STicon;
        private PictureBox pictureBox_myMonster;
        private Button button_myMonster_Food;
        private Button button_myMonster_Sleep;
        private Button button_myMonster_Inventory;
        private Button button_myMonster_Player;
        private Button button_myMonster_Save;
        private Button button_myMonster_ReturnToMainMenu;
        private Button button_myMonster_Battle;
        private Button button_myMonster_MiniGames;
        private Label nameMyMonsterLabel;
        private Label levelMyMonster;
        private Label label_MyMonster_LVL;
    }
}
