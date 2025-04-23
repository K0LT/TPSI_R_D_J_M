using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Holdingbackthefool
{
    public partial class Form1 : Form
    {
        private Player player;
        private Monster monster;
        int num1, num2;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player = new Player();
            tabControlPages.SelectedTab = tabPageCreatePlayer;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControlPages.SelectedTab = tabPageInitial;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            player.name = textBox1.Text;
            MessageBox.Show("Nome do jogador: " + player.name);
            tabControlPages.SelectedTab = tabPageCreateMonster;
            label2.Text = ("Player name: " + player.name);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            monster = new Draco();
            player.AddMonster(monster);
            label4.Visible = true;
            textBox2.Visible = true;
            button8.Visible = true;
            DesativarBotoesMonstros();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            monster = new Siren();
            player.AddMonster(monster);
            label4.Visible = true;
            textBox2.Visible = true;
            button8.Visible = true;
            DesativarBotoesMonstros();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            monster = new Tauro();
            player.AddMonster(monster);
            label4.Visible = true;
            textBox2.Visible = true;
            button8.Visible = true;
            DesativarBotoesMonstros();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            monster = new Grifo();
            player.AddMonster(monster);
            label4.Visible = true;
            textBox2.Visible = true;
            button8.Visible = true;
            DesativarBotoesMonstros();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            monster.name = textBox2.Text;
            MessageBox.Show("You created a  " + monster.GetNature() + " named: " + monster.name);
            RefreshMonsterStats(monster);
            tabControlPages.SelectedTab = tabPageMonster;
        }

        private void DesativarBotoesMonstros()
        {
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }

        internal void RefreshMonsterStats(Monster m)
        {
            label5.Text = ("Name: " + m.name);
            label6.Text = ("Level: " + m.level.ToString());
            label7.Text = ("HP: " + m.hp.ToString());
            label8.Text = ("Stamina: " + m.stamina.ToString());
            label9.Text = ("EXP: " + m.exp.ToString());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            monster.Run();
            RefreshMonsterStats(monster);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            monster.PunchYourself();
            RefreshMonsterStats(monster);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            num1 = rand.Next(1, 11); // Número aleatório de 1 a 10
            num2 = rand.Next(1, 11); // Número aleatório de 1 a 10
            label10.Text = (num1 + " + " + num2 + "?");
            label10.Visible = true;
            button13.Visible = true;
            textBox3.Visible = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            monster.GainExperience();
            RefreshMonsterStats(monster);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int answer = int.Parse(textBox3.Text);
            bool correct = monster.Fight(num1, num2, answer);

            if (correct)
            {
                MessageBox.Show("You are correct!");
                RefreshMonsterStats(monster);
            }
            else
            {
                MessageBox.Show("You are incorrect!");
                RefreshMonsterStats(monster);
            }

            label10.Visible = false;
            button13.Visible = false;
            textBox3.Visible = false;
            textBox3.Text = "";
        }
    }
}
