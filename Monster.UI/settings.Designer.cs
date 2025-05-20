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
            button_Settings_Exit = new Button();
            settingsTitleLabel = new Label();
            SuspendLayout();
            // 
            // button_Settings_Exit
            // 
            button_Settings_Exit.BackColor = Color.Transparent;
            button_Settings_Exit.BackgroundImage = (Image)resources.GetObject("button_Settings_Exit.BackgroundImage");
            button_Settings_Exit.Cursor = Cursors.Hand;
            button_Settings_Exit.FlatAppearance.BorderSize = 0;
            button_Settings_Exit.FlatStyle = FlatStyle.Flat;
            button_Settings_Exit.Location = new Point(555, 0);
            button_Settings_Exit.Name = "button_Settings_Exit";
            button_Settings_Exit.Size = new Size(45, 45);
            button_Settings_Exit.TabIndex = 26;
            button_Settings_Exit.UseVisualStyleBackColor = false;
            button_Settings_Exit.Click += button_Settings_Exit_Click;
            // 
            // settingsTitleLabel
            // 
            settingsTitleLabel.AutoSize = true;
            settingsTitleLabel.BackColor = Color.Transparent;
            settingsTitleLabel.Font = new Font("VCR OSD Mono", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            settingsTitleLabel.ForeColor = Color.DarkGoldenrod;
            settingsTitleLabel.Location = new Point(157, 89);
            settingsTitleLabel.Name = "settingsTitleLabel";
            settingsTitleLabel.Size = new Size(331, 64);
            settingsTitleLabel.TabIndex = 25;
            settingsTitleLabel.Text = "Settings";
            // 
            // settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button_Settings_Exit);
            Controls.Add(settingsTitleLabel);
            Name = "settings";
            Size = new Size(600, 900);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Settings_Exit;
        private Label settingsTitleLabel;
    }
}
