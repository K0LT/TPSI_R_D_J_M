namespace Holdingbackthefool
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControlPages = new System.Windows.Forms.TabControl();
            this.tabPageInitial = new System.Windows.Forms.TabPage();
            this.tabPageCreatePlayer = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPageCreateMonster = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageMonster = new System.Windows.Forms.TabPage();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.tabControlPages.SuspendLayout();
            this.tabPageInitial.SuspendLayout();
            this.tabPageCreatePlayer.SuspendLayout();
            this.tabPageCreateMonster.SuspendLayout();
            this.tabPageMonster.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Player";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabControlPages
            // 
            this.tabControlPages.Controls.Add(this.tabPageInitial);
            this.tabControlPages.Controls.Add(this.tabPageCreatePlayer);
            this.tabControlPages.Controls.Add(this.tabPageCreateMonster);
            this.tabControlPages.Controls.Add(this.tabPageMonster);
            this.tabControlPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPages.Location = new System.Drawing.Point(0, 0);
            this.tabControlPages.Name = "tabControlPages";
            this.tabControlPages.SelectedIndex = 0;
            this.tabControlPages.Size = new System.Drawing.Size(800, 450);
            this.tabControlPages.TabIndex = 2;
            // 
            // tabPageInitial
            // 
            this.tabPageInitial.Controls.Add(this.button1);
            this.tabPageInitial.Controls.Add(this.button2);
            this.tabPageInitial.Location = new System.Drawing.Point(4, 22);
            this.tabPageInitial.Name = "tabPageInitial";
            this.tabPageInitial.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInitial.Size = new System.Drawing.Size(792, 424);
            this.tabPageInitial.TabIndex = 1;
            this.tabPageInitial.Text = "tabPageInitial";
            this.tabPageInitial.UseVisualStyleBackColor = true;
            // 
            // tabPageCreatePlayer
            // 
            this.tabPageCreatePlayer.Controls.Add(this.button3);
            this.tabPageCreatePlayer.Controls.Add(this.label1);
            this.tabPageCreatePlayer.Controls.Add(this.textBox1);
            this.tabPageCreatePlayer.Location = new System.Drawing.Point(4, 22);
            this.tabPageCreatePlayer.Name = "tabPageCreatePlayer";
            this.tabPageCreatePlayer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreatePlayer.Size = new System.Drawing.Size(792, 424);
            this.tabPageCreatePlayer.TabIndex = 0;
            this.tabPageCreatePlayer.Text = "TabPageCreatePlayer";
            this.tabPageCreatePlayer.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(183, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(77, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // tabPageCreateMonster
            // 
            this.tabPageCreateMonster.Controls.Add(this.button8);
            this.tabPageCreateMonster.Controls.Add(this.textBox2);
            this.tabPageCreateMonster.Controls.Add(this.label4);
            this.tabPageCreateMonster.Controls.Add(this.button7);
            this.tabPageCreateMonster.Controls.Add(this.button6);
            this.tabPageCreateMonster.Controls.Add(this.button5);
            this.tabPageCreateMonster.Controls.Add(this.button4);
            this.tabPageCreateMonster.Controls.Add(this.label3);
            this.tabPageCreateMonster.Controls.Add(this.label2);
            this.tabPageCreateMonster.Location = new System.Drawing.Point(4, 22);
            this.tabPageCreateMonster.Name = "tabPageCreateMonster";
            this.tabPageCreateMonster.Size = new System.Drawing.Size(792, 424);
            this.tabPageCreateMonster.TabIndex = 2;
            this.tabPageCreateMonster.Text = "tabPageCreateMonster";
            this.tabPageCreateMonster.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(158, 85);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(30, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "OK";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(52, 87);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 7;
            this.textBox2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name:";
            this.label4.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(380, 40);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 5;
            this.button7.Text = "Grifo";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(299, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Tauro";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(218, 40);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Siren";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(137, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Draco";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Choose a Monster Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // tabPageMonster
            // 
            this.tabPageMonster.Controls.Add(this.button13);
            this.tabPageMonster.Controls.Add(this.textBox3);
            this.tabPageMonster.Controls.Add(this.label10);
            this.tabPageMonster.Controls.Add(this.button12);
            this.tabPageMonster.Controls.Add(this.button11);
            this.tabPageMonster.Controls.Add(this.button10);
            this.tabPageMonster.Controls.Add(this.button9);
            this.tabPageMonster.Controls.Add(this.label9);
            this.tabPageMonster.Controls.Add(this.label8);
            this.tabPageMonster.Controls.Add(this.label7);
            this.tabPageMonster.Controls.Add(this.label6);
            this.tabPageMonster.Controls.Add(this.label5);
            this.tabPageMonster.Location = new System.Drawing.Point(4, 22);
            this.tabPageMonster.Name = "tabPageMonster";
            this.tabPageMonster.Size = new System.Drawing.Size(792, 424);
            this.tabPageMonster.TabIndex = 3;
            this.tabPageMonster.Text = "tabPageMonster";
            this.tabPageMonster.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(120, 98);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(95, 23);
            this.button12.TabIndex = 3;
            this.button12.Text = "Fight";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(120, 61);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(95, 23);
            this.button11.TabIndex = 3;
            this.button11.Text = "Gain Experience";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(120, 32);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(95, 23);
            this.button10.TabIndex = 6;
            this.button10.Text = "Punch Yourself";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(120, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(95, 23);
            this.button9.TabIndex = 5;
            this.button9.Text = "Run -Stamina";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "label5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(231, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "label10";
            this.label10.Visible = false;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(278, 100);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(41, 20);
            this.textBox3.TabIndex = 8;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(325, 98);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(32, 23);
            this.button13.TabIndex = 9;
            this.button13.Text = "OK";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlPages);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlPages.ResumeLayout(false);
            this.tabPageInitial.ResumeLayout(false);
            this.tabPageCreatePlayer.ResumeLayout(false);
            this.tabPageCreatePlayer.PerformLayout();
            this.tabPageCreateMonster.ResumeLayout(false);
            this.tabPageCreateMonster.PerformLayout();
            this.tabPageMonster.ResumeLayout(false);
            this.tabPageMonster.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl tabControlPages;
        private System.Windows.Forms.TabPage tabPageCreatePlayer;
        private System.Windows.Forms.TabPage tabPageInitial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPageCreateMonster;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage tabPageMonster;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox textBox3;
    }
}

