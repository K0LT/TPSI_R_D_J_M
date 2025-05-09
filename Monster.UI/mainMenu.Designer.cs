namespace Monster.UI
{
    partial class mainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainMenu));
            button_mainMenu_NewGame = new Button();
            button_mainMenu_LoadGame = new Button();
            button_mainMenu_Exit = new Button();
            SuspendLayout();
            // 
            // button_mainMenu_NewGame
            // 
            button_mainMenu_NewGame.BackgroundImage = (Image)resources.GetObject("button_mainMenu_NewGame.BackgroundImage");
            button_mainMenu_NewGame.Location = new Point(183, 547);
            button_mainMenu_NewGame.Name = "button_mainMenu_NewGame";
            button_mainMenu_NewGame.Size = new Size(228, 45);
            button_mainMenu_NewGame.TabIndex = 0;
            button_mainMenu_NewGame.UseVisualStyleBackColor = true;
            // 
            // button_mainMenu_LoadGame
            // 
            button_mainMenu_LoadGame.BackgroundImage = (Image)resources.GetObject("button_mainMenu_LoadGame.BackgroundImage");
            button_mainMenu_LoadGame.Location = new Point(183, 652);
            button_mainMenu_LoadGame.Name = "button_mainMenu_LoadGame";
            button_mainMenu_LoadGame.Size = new Size(228, 45);
            button_mainMenu_LoadGame.TabIndex = 1;
            button_mainMenu_LoadGame.UseVisualStyleBackColor = true;
            // 
            // button_mainMenu_Exit
            // 
            button_mainMenu_Exit.BackgroundImage = (Image)resources.GetObject("button_mainMenu_Exit.BackgroundImage");
            button_mainMenu_Exit.Location = new Point(183, 755);
            button_mainMenu_Exit.Name = "button_mainMenu_Exit";
            button_mainMenu_Exit.Size = new Size(228, 45);
            button_mainMenu_Exit.TabIndex = 2;
            button_mainMenu_Exit.UseVisualStyleBackColor = true;
            // 
            // mainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button_mainMenu_Exit);
            Controls.Add(button_mainMenu_LoadGame);
            Controls.Add(button_mainMenu_NewGame);
            Name = "mainMenu";
            Size = new Size(600, 900);
            ResumeLayout(false);
        }

        #endregion

        private Button button_mainMenu_NewGame;
        private Button button_mainMenu_LoadGame;
        private Button button_mainMenu_Exit;
    }
}
