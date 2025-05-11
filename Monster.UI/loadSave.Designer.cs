namespace Monster.UI
{
    partial class loadSave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loadSave));
            button_loadSave_loadSaveSlot1 = new Button();
            button_loadSave_loadSaveSlot3 = new Button();
            button_loadSave_loadSaveSlot2 = new Button();
            SuspendLayout();
            // 
            // button_loadSave_loadSaveSlot1
            // 
            button_loadSave_loadSaveSlot1.Location = new Point(225, 253);
            button_loadSave_loadSaveSlot1.Name = "button_loadSave_loadSaveSlot1";
            button_loadSave_loadSaveSlot1.Size = new Size(105, 23);
            button_loadSave_loadSaveSlot1.TabIndex = 0;
            button_loadSave_loadSaveSlot1.Text = "Load Save 1";
            button_loadSave_loadSaveSlot1.UseVisualStyleBackColor = true;
            // 
            // button_loadSave_loadSaveSlot3
            // 
            button_loadSave_loadSaveSlot3.Location = new Point(225, 417);
            button_loadSave_loadSaveSlot3.Name = "button_loadSave_loadSaveSlot3";
            button_loadSave_loadSaveSlot3.Size = new Size(105, 23);
            button_loadSave_loadSaveSlot3.TabIndex = 1;
            button_loadSave_loadSaveSlot3.Text = "Load Save 3";
            button_loadSave_loadSaveSlot3.UseVisualStyleBackColor = true;
            // 
            // button_loadSave_loadSaveSlot2
            // 
            button_loadSave_loadSaveSlot2.Location = new Point(225, 338);
            button_loadSave_loadSaveSlot2.Name = "button_loadSave_loadSaveSlot2";
            button_loadSave_loadSaveSlot2.Size = new Size(105, 23);
            button_loadSave_loadSaveSlot2.TabIndex = 2;
            button_loadSave_loadSaveSlot2.Text = "Load Save 2";
            button_loadSave_loadSaveSlot2.UseVisualStyleBackColor = true;
            // 
            // loadSave
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            Controls.Add(button_loadSave_loadSaveSlot2);
            Controls.Add(button_loadSave_loadSaveSlot3);
            Controls.Add(button_loadSave_loadSaveSlot1);
            Name = "loadSave";
            Size = new Size(600, 900);
            ResumeLayout(false);
        }

        #endregion

        private Button button_loadSave_loadSaveSlot1;
        private Button button_loadSave_loadSaveSlot3;
        private Button button_loadSave_loadSaveSlot2;
    }
}
