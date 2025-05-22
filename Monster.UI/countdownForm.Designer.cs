namespace Monster.UI
{
    partial class countdownForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(countdownForm));
            label_Zz = new Label();
            label_Zz1 = new Label();
            SuspendLayout();
            // 
            // label_Zz
            // 
            label_Zz.AutoSize = true;
            label_Zz.BackColor = Color.Transparent;
            label_Zz.Font = new Font("VCR OSD Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Zz.ForeColor = Color.AntiqueWhite;
            label_Zz.Location = new Point(41, 45);
            label_Zz.Name = "label_Zz";
            label_Zz.Size = new Size(58, 22);
            label_Zz.TabIndex = 0;
            label_Zz.Text = "ZzZz";
            // 
            // label_Zz1
            // 
            label_Zz1.AutoSize = true;
            label_Zz1.BackColor = Color.Transparent;
            label_Zz1.Font = new Font("VCR OSD Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Zz1.ForeColor = Color.AntiqueWhite;
            label_Zz1.Location = new Point(41, 45);
            label_Zz1.Name = "label_Zz1";
            label_Zz1.Size = new Size(58, 22);
            label_Zz1.TabIndex = 1;
            label_Zz1.Text = "zZzZ";
            // 
            // countdownForm
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(391, 132);
            ControlBox = false;
            Controls.Add(label_Zz1);
            Controls.Add(label_Zz);
            DoubleBuffered = true;
            Font = new Font("VCR OSD Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Goldenrod;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "countdownForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sleeping...";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Zz;
        private Label label_Zz1;
    }
}