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
    public partial class TicTacToeForm : Form
    {
        private char[,] board = new char[3, 3];
        private char current = 'X';

        public TicTacToeForm()
        {
            InitializeComponent();
            Text = "Tic-Tac-Toe";
            
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is Button btn)
                    btn.Click += OnCellClick;
            }
        }

        private void OnCellClick(object sender, EventArgs e)
        {
            var btn = (Button)sender;
         
            int row = int.Parse(btn.Name[3].ToString());
            int col = int.Parse(btn.Name[4].ToString());

            if (board[row, col] != '\0') return; 

            board[row, col] = current;
            btn.Text = current.ToString();

            if (CheckWin(current))
            {
                MessageBox.Show($"{current} venceu!");
                ResetGame();
                return;
            }
            if (board.Cast<char>().All(c => c != '\0'))
            {
                MessageBox.Show("Empate!");
                ResetGame();
                return;
            }

            current = current == 'X' ? 'O' : 'X';
        }

        private bool CheckWin(char p)
        {
            // linhas/colunas
            for (int i = 0; i < 3; i++)
                if ((board[i, 0] == p && board[i, 1] == p && board[i, 2] == p) ||
                    (board[0, i] == p && board[1, i] == p && board[2, i] == p))
                    return true;
            // diagonais
            if ((board[0, 0] == p && board[1, 1] == p && board[2, 2] == p) ||
                (board[0, 2] == p && board[1, 1] == p && board[2, 0] == p))
                return true;
            return false;
        }

        private void ResetGame()
        {
            board = new char[3, 3];
            current = 'X';
            foreach (Control c in tableLayoutPanel1.Controls)
                if (c is Button btn) btn.Text = "";
        }
    }
}
