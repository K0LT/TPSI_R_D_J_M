using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster
{
    public partial class InicialPage : Form
    {

        LevelGoals levelGoals;

        public InicialPage()
        {
            InitializeComponent();
            levelGoals = new LevelGoals();
            progressBarDraco.Minimum = 0;
            progressBarDraco.Maximum = 100; // Defina o máximo conforme necessário
            progressBarDraco.Value = 0; // Inicializa a barra de progresso
            UpdateAttributeLabels();
            descricao1.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //configurar menu principal e tabs para preencher tela
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            Monsters.Dock = DockStyle.Fill;
            Monsters.Appearance = TabAppearance.FlatButtons;
            Monsters.ItemSize = new Size(0, 1);
            Monsters.SizeMode = TabSizeMode.Fixed;

            //Colocar titulo principal sem cor
            label1.BackColor = Color.Transparent;


            //botoes menu inicial
            MainMenuButton(newgame);
            MainMenuButton(loadgame);
            MainMenuButton(settings);
            MainMenuButton(exit);
            MainMenuButton(credit);


            //botoes menu monster
            MonsterButtonMenu(changeName2);
            MonsterButtonMenu(feed2);
            MonsterButtonMenu(play2);
            MonsterButtonMenu(sleep1);
            MonsterButtonMenu(inventory2);
            MonsterButtonMenu(save2);
            MonsterButtonMenu(exitbutton2);
            MonsterButtonMenu(evolve);
            MonsterButtonMenu(status);


            //botoes menu player

            MonsterButtonMenu(MyMonsters2);
            MonsterButtonMenu(MyBackpack1);
            MonsterButtonMenu(Games1);
            MonsterButtonMenu(Shop1);
            MonsterButtonMenu(Achievements);
            MonsterButtonMenu(Save1);
            MonsterButtonMenu(Exit2);
      



            //passar o cursor na imagem e exibir texto em selecionar monstro
            MapearImagemComDescricao(draco, descricao1);
            MapearImagemComDescricao(grifo, descricao2);
            MapearImagemComDescricao(tauro, descricao3);
            MapearImagemComDescricao(siren, descricao4);



            //Barra progresso draco (teste)
            progressBarDraco.Minimum = 0;
            progressBarDraco.Maximum = 5;
            progressBarDraco.Value = 1;


         




        }


        //void design de botoes iniciais
        private void MainMenuButton(Button button)
        {

            button.BackColor = Color.FromArgb(204, 255, 255, 255);

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button.ForeColor = Color.FromArgb(54, 39, 22); 

   
            button.MouseHover += (s, e) =>
            {
                button.BackColor = Color.FromArgb(102, 255, 255, 255);
                button.ForeColor = Color.White; 
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = Color.FromArgb(204, 255, 255, 255); 
                button.ForeColor = Color.FromArgb(54, 39, 22);
            };
        }

        //Design de botoes de menu monstro / player
        private void MonsterButtonMenu(Button button)
        {
            button.BackColor = Color.FromArgb(74, 59, 42);

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(114, 99, 82);
            button.ForeColor = Color.Peru;

            button.MouseHover += (s, e) =>
            {
                button.BackColor = Color.FromArgb(114, 99, 82);
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = Color.FromArgb(74, 59, 42);
                button.ForeColor = Color.Peru;
            };
        }






        //voids botoes de menu principal
        private void newgame_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageNewGame;
        }

        private void loadgame_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageLoadGame;
        }

        private void settings_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageSettings;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void credit_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageCredits;

        }




       


        //voids botoes de clique para selecionar monstro inicial
        private void dracoselect_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageFirstMonster;

        }
        private void grifoselect_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageFirstMonster;

        }
        private void tauroselect_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageFirstMonster;

        }
        private void sirenselect_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageFirstMonster;


        }




        //voids botoes First Monster

        private void Next_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageBegining;
        }

        //voids botoes Begining
        private void myMonsters3_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageMyMonster;

        }

        private void player3_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPagePlayer;

        }

        private void exitbutton3_Click(object sender, EventArgs e)
        {
            // Fazer confirmaçao se quer sair e se sim, se quer salvar o jogo
            Monsters.SelectedTab = tabPageHome;
        }


        //voids botoes Load Game
        private void myMonsters1_Click(object sender, EventArgs e)
        {

            Monsters.SelectedTab = tabPageMyMonster;
        }

        private void Player1_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPagePlayer;
        }

        private void Exit1_Click(object sender, EventArgs e)
        {
            // Fazer confirmaçao se quer sair e se sim, se quer salvar o jogo
            Monsters.SelectedTab = tabPageHome;
        }


        //voids botoes menu Player
        private void MyMonsters2_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageMyMonster;

        }

        private void Inventory1_Click(object sender, EventArgs e)
        {

        }

        private void Games1_Click(object sender, EventArgs e)
        {

        }

        private void Shop1_Click(object sender, EventArgs e)
        {

        }

        private void Save1_Click(object sender, EventArgs e)
        {

        }

        private void Exit2_Click(object sender, EventArgs e)
        {
            // Fazer confirmaçao se quer sair e se sim, se quer salvar o jogo
            Monsters.SelectedTab = tabPageHome;
        }


        //voids botoes menu My Monster








        //voids para a imagem / descricao funcionarem
        private void MapearImagemComDescricao(PictureBox imagem, TextBox descricao)
        {
            descricao.Visible = false;

            imagem.MouseEnter += (s, e) =>
            {
                descricao.Visible = true;
                descricao.BringToFront();
            };

            imagem.MouseLeave += (s, e) =>
            {
                descricao.Visible = false;
            };
        }

        private void UpdateTextBoxVisibility(bool isVisible)
        {
            descricao1.Visible = isVisible;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateTextBoxVisibility(false);
        }
        private void draco_MouseEnter(object sender, EventArgs e)
        {
            UpdateTextBoxVisibility(true);
        }
        private void draco_MouseLeave(object sender, EventArgs e)
        {
            UpdateTextBoxVisibility(false);
        }
        private void tabPage1_Click_1(object sender, EventArgs e)
        {


        }

        // calcular o progresso
        private int CalculateProgress()
        {
            int progress = 0;

            // calcula o progresso com base naquiolo que foi feito, em percentagem
            if (levelGoals.FeedCount > 0)
            {
                progress += (levelGoals.FeedCount * 100 / 5);
            }
            if (levelGoals.CorrectGamesCount > 0)
            {
                progress += (levelGoals.CorrectGamesCount * 100 / 2);
            }
            if (levelGoals.Attack > 5)
            {
                progress += 100;
            }

            // limita o progresso a 100%
            if (progress > 100) progress = 100;

            return progress;
        }


        //Atualiza os stats 
        private void UpdateAttributeLabels()
        {

            lblLevel.Text = "Lvl: " + levelGoals.Level;
            lblStamina.Text = "Stamina: " + levelGoals.Stamina;
            lblAttack.Text = "Attack: " + levelGoals.Attack;
            lblExp.Text = "Exp: " + levelGoals.Exp;
        }
























        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPageBeginingDraco_Click(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = tabPageDraco;
        }
    }
}
