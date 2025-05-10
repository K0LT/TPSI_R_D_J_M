using System;
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
    public partial class MinigameSelectionForm : Form
    {
        public string SelectedGameId { get; private set; }

        public MinigameSelectionForm()
        {
            InitializeComponent();
            
            pictureBoxTicTacToe.Click += PictureBox_Click;
            pictureBoxMemory.Click += PictureBox_Click;
            pictureBoxQuickClick.Click += PictureBox_Click;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox pb && pb.Tag is string gameId)
            {
                SelectedGameId = gameId;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
