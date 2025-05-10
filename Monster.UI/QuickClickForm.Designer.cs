namespace Monster.UI
{
    partial class QuickClickForm
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
            components = new System.ComponentModel.Container();
            btnClick = new Button();
            timerDelay = new System.Windows.Forms.Timer(components);
            lblResult = new Label();
            SuspendLayout();
            // 
            // btnClick
            // 
            btnClick.Location = new Point(365, 188);
            btnClick.Name = "btnClick";
            btnClick.Size = new Size(75, 23);
            btnClick.TabIndex = 0;
            btnClick.Text = "Click Fast";
            btnClick.UseVisualStyleBackColor = true;
            btnClick.Visible = false;
            // 
            // timerDelay
            // 
            timerDelay.Interval = 1000;
            timerDelay.Tick += timer1_Tick;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(373, 316);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(38, 15);
            lblResult.TabIndex = 1;
            lblResult.Text = "label1";
            // 
            // QuickClickForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(btnClick);
            Name = "QuickClickForm";
            Text = "QuickClickForm";
            Load += QuickClickForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClick;
        private System.Windows.Forms.Timer timerDelay;
        private Label lblResult;
    }
}