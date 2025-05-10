namespace Monster.UI
{
    partial class TicTacToeForm
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
            tableLayoutPanel1 = new TableLayoutPanel();
            btn01 = new Button();
            btn02 = new Button();
            btn03 = new Button();
            btn04 = new Button();
            btn05 = new Button();
            btn06 = new Button();
            btn07 = new Button();
            btn08 = new Button();
            btn09 = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.37306F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.62694F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 179F));
            tableLayoutPanel1.Controls.Add(btn01, 0, 0);
            tableLayoutPanel1.Controls.Add(btn02, 1, 0);
            tableLayoutPanel1.Controls.Add(btn03, 2, 0);
            tableLayoutPanel1.Controls.Add(btn04, 0, 1);
            tableLayoutPanel1.Controls.Add(btn05, 1, 1);
            tableLayoutPanel1.Controls.Add(btn06, 2, 1);
            tableLayoutPanel1.Controls.Add(btn07, 0, 2);
            tableLayoutPanel1.Controls.Add(btn08, 1, 2);
            tableLayoutPanel1.Controls.Add(btn09, 2, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46.22793F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 53.77207F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 282F));
            tableLayoutPanel1.Size = new Size(584, 861);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // btn01
            // 
            btn01.Location = new Point(3, 3);
            btn01.Name = "btn01";
            btn01.Size = new Size(75, 23);
            btn01.TabIndex = 0;
            btn01.Text = "btn01";
            btn01.UseVisualStyleBackColor = true;
            // 
            // btn02
            // 
            btn02.Location = new Point(190, 3);
            btn02.Name = "btn02";
            btn02.Size = new Size(75, 23);
            btn02.TabIndex = 1;
            btn02.Text = "button2";
            btn02.UseVisualStyleBackColor = true;
            // 
            // btn03
            // 
            btn03.Location = new Point(407, 3);
            btn03.Name = "btn03";
            btn03.Size = new Size(75, 23);
            btn03.TabIndex = 2;
            btn03.Text = "button3";
            btn03.UseVisualStyleBackColor = true;
            // 
            // btn04
            // 
            btn04.Location = new Point(3, 270);
            btn04.Name = "btn04";
            btn04.Size = new Size(75, 23);
            btn04.TabIndex = 3;
            btn04.Text = "button4";
            btn04.UseVisualStyleBackColor = true;
            // 
            // btn05
            // 
            btn05.Location = new Point(190, 270);
            btn05.Name = "btn05";
            btn05.Size = new Size(75, 23);
            btn05.TabIndex = 4;
            btn05.Text = "button5";
            btn05.UseVisualStyleBackColor = true;
            // 
            // btn06
            // 
            btn06.Location = new Point(407, 270);
            btn06.Name = "btn06";
            btn06.Size = new Size(75, 23);
            btn06.TabIndex = 5;
            btn06.Text = "button6";
            btn06.UseVisualStyleBackColor = true;
            // 
            // btn07
            // 
            btn07.Location = new Point(3, 581);
            btn07.Name = "btn07";
            btn07.Size = new Size(75, 23);
            btn07.TabIndex = 6;
            btn07.Text = "button7";
            btn07.UseVisualStyleBackColor = true;
            // 
            // btn08
            // 
            btn08.Location = new Point(190, 581);
            btn08.Name = "btn08";
            btn08.Size = new Size(75, 23);
            btn08.TabIndex = 7;
            btn08.Text = "button8";
            btn08.UseVisualStyleBackColor = true;
            // 
            // btn09
            // 
            btn09.Location = new Point(407, 581);
            btn09.Name = "btn09";
            btn09.Size = new Size(75, 23);
            btn09.TabIndex = 8;
            btn09.Text = "button9";
            btn09.UseVisualStyleBackColor = true;
            // 
            // TicTacToeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 861);
            Controls.Add(tableLayoutPanel1);
            Name = "TicTacToeForm";
            Text = "TicTacToeForm";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btn01;
        private Button btn02;
        private Button btn03;
        private Button btn04;
        private Button btn05;
        private Button btn06;
        private Button btn07;
        private Button btn08;
        private Button btn09;
    }
}