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
            labelCountdown = new Label();
            SuspendLayout();
            // 
            // labelCountdown
            // 
            labelCountdown.AutoSize = true;
            labelCountdown.Dock = DockStyle.Fill;
            labelCountdown.Font = new Font("VCR OSD Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCountdown.Location = new Point(0, 0);
            labelCountdown.Margin = new Padding(4, 0, 4, 0);
            labelCountdown.Name = "labelCountdown";
            labelCountdown.Size = new Size(261, 19);
            labelCountdown.TabIndex = 0;
            labelCountdown.Text = "15 seconds remaining...";
            labelCountdown.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // countdownForm
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(391, 132);
            ControlBox = false;
            Controls.Add(labelCountdown);
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

        private Label labelCountdown;
    }
}