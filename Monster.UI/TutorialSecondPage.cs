﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster.UI
{
    /// <summary>
    /// UserControl representing the second tutorial page.
    /// </summary>
    public partial class TutorialSecondPage : UserControl
    {
        public TutorialSecondPage()
        {
            InitializeComponent();
        }

        private Form1 ParentForm => this.FindForm() as Form1;


  

        private void button_Tutorial2_Next_Click(object sender, EventArgs e)
        {
            ParentForm.NavigateTo("Tutorial3");
        }
    }
}
