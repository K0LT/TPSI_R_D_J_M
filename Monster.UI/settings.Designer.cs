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
            // settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(pictureBox_settings_settingsText);
            Name = "settings";
            Size = new Size(600, 900);
            ((System.ComponentModel.ISupportInitialize)pictureBox_settings_settingsText).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox_settings_settingsText;
    }
}
