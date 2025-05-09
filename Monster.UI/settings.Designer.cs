namespace Monster.UI
{
    partial class settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings));
            pictureBox_settings_settingsText = new PictureBox();
            button_settings_ReturnToMyMonster = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_settings_settingsText).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_settings_settingsText
            // 
            pictureBox_settings_settingsText.BackColor = Color.Transparent;
            pictureBox_settings_settingsText.Image = (Image)resources.GetObject("pictureBox_settings_settingsText.Image");
            pictureBox_settings_settingsText.Location = new Point(55, 14);
            pictureBox_settings_settingsText.Name = "pictureBox_settings_settingsText";
            pictureBox_settings_settingsText.Size = new Size(500, 133);
            pictureBox_settings_settingsText.TabIndex = 0;
            pictureBox_settings_settingsText.TabStop = false;
            // 
            // button_settings_ReturnToMyMonster
            // 
            button_settings_ReturnToMyMonster.BackColor = Color.Transparent;
            button_settings_ReturnToMyMonster.BackgroundImage = (Image)resources.GetObject("button_settings_ReturnToMyMonster.BackgroundImage");
            button_settings_ReturnToMyMonster.Location = new Point(260, 756);
            button_settings_ReturnToMyMonster.Name = "button_settings_ReturnToMyMonster";
            button_settings_ReturnToMyMonster.Size = new Size(33, 43);
            button_settings_ReturnToMyMonster.TabIndex = 21;
            button_settings_ReturnToMyMonster.UseVisualStyleBackColor = false;
            // 
            // settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button_settings_ReturnToMyMonster);
            Controls.Add(pictureBox_settings_settingsText);
            Name = "settings";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_settings_settingsText).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_settings_settingsText;
        private Button button_settings_ReturnToMyMonster;
    }
}
