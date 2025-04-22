using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            descricao1.Visible = false;   // descriçao de monsters seleçao inicial
            panelFirstRegister.Visible = false;  // registo player escondido
            nextRegister.Visible = false;   // botao de next em registo de player
            panelNextMonsterName.Visible = false; // botao next depois de colocar nome do monstro
            textBoxPassword.PasswordChar = '*'; // Codificar password
            passwordLogin.PasswordChar = '*'; // Codificar password



            UpdateAttributeLabels();
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
            Monsters.SelectedTab = NewGamePlayer;
        }

        private void loadgame_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = Login;
        }

        private void settings_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = SettingsPage;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void credit_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = Credits;

        }






        //voids botoes de menu new game player

        private void PlayerBoy_CheckedChanged(object sender, EventArgs e)
        {
            panelFirstRegister.Visible = PlayerBoy.Checked;

        }

        private void PlayerGirl_CheckedChanged(object sender, EventArgs e)
        {
            panelFirstRegister.Visible = PlayerGirl.Checked;

        }

        private void LoadPlayerType(string user)
        {
            string userDirectoryPath = Path.Combine(Application.StartupPath, "Resources", user);
            string playerTypeFilePath = Path.Combine(userDirectoryPath, "playerType.txt");

            if (File.Exists(playerTypeFilePath))
            {
                string playerType = File.ReadAllText(playerTypeFilePath).Trim();
                if (playerType.Equals("Boy", StringComparison.OrdinalIgnoreCase))
                {
                    PlayerBoy.Checked = true;
                }
                else if (playerType.Equals("Girl", StringComparison.OrdinalIgnoreCase))
                {
                    PlayerGirl.Checked = true;
                }
            }
        }

        private void registerplayer_Click(object sender, EventArgs e)
        {
            // Guardar a info de novos users e passwords em um .txt, além de criar arquivo onde vai guardar o nome de todos os monstros,
            // cria ainda uma pasta onde vai guardar todos os monsters e outras coisas de cada user.
            string user = textBoxusername.Text.Trim();
            string pass = textBoxPassword.Text.Trim();
            string usernameFilePath = Path.Combine(Application.StartupPath, "Resources", "username.txt");
            string passwordFilePath = Path.Combine(Application.StartupPath, "Resources", "password.txt");
            string userDirectoryPath = Path.Combine(Application.StartupPath, "Resources", user);

            Message.Text = string.Empty;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                Message.Text = "[ERROR] Please insert a username and password";
                Message.ForeColor = Color.Red;
                return;
            }

            var existingUsers = File.Exists(usernameFilePath) ? File.ReadAllLines(usernameFilePath) : new string[0];
            if (existingUsers.Contains(user))
            {
                Message.Text = "     [ERROR] This username already exists!";
                Message.ForeColor = Color.Red;
                return;
            }

            using (StreamWriter swUser = File.AppendText(usernameFilePath))
            {
                swUser.WriteLine(user);
            }

            using (StreamWriter swPass = File.AppendText(passwordFilePath))
            {
                swPass.WriteLine(pass);
            }

            Directory.CreateDirectory(userDirectoryPath);

            string playerType = PlayerBoy.Checked ? "Boy" : PlayerGirl.Checked ? "Girl" : "Unknown";
            string playerTypeFilePath = Path.Combine(userDirectoryPath, "playerType.txt");
            File.WriteAllText(playerTypeFilePath, playerType);


            LoadPlayerType(user);

            Message.Text = "                   Registered successfully!";
            Message.ForeColor = Color.Green;

            nextRegister.Visible = true;
            registerplayer.Enabled = false;
        }

        private void nextRegister_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = NewGameMonster;
        }

        private string selectedMonsterType;

        private void dracoselect_Click(object sender, EventArgs e)
        {
            selectedMonsterType = "draco";
            panelMonsterName.Visible = true;
        }

        private void grifoselect_Click(object sender, EventArgs e)
        {
            selectedMonsterType = "grifo";
            panelMonsterName.Visible = true;
        }

        private void tauroselect_Click(object sender, EventArgs e)
        {
            selectedMonsterType = "tauro";
            panelMonsterName.Visible = true;
        }

        private void sirenselect_Click(object sender, EventArgs e)
        {
            selectedMonsterType = "siren";
            panelMonsterName.Visible = true;
        }

        private void MonsterRegister_Click(object sender, EventArgs e)
        {
            string monsterName = textBoxMonsterName.Text.Trim();
            string usernameFilePath = Path.Combine(Application.StartupPath, "Resources", "username.txt");
            string user = File.ReadAllLines(usernameFilePath).FirstOrDefault()?.Trim();
            string userDirectoryPath = Path.Combine(Application.StartupPath, "Resources", user);


            if (string.IsNullOrEmpty(monsterName))
            {
                Message2.Text = "         Please enter monster's name";
                Message2.ForeColor = Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(selectedMonsterType))
            {
                Message2.Text = "         Please select a monster type";
                Message2.ForeColor = Color.Red;
                return;
            }



            string monsterNameFilePath = Path.Combine(userDirectoryPath, "monsterName.txt");
            string monsterStatusFilePath = Path.Combine(userDirectoryPath, $"{monsterName}_monsterStatus.txt");



            if (!File.Exists(monsterNameFilePath))
            {
                File.WriteAllText(monsterNameFilePath, monsterName);
            }

            if (!File.Exists(monsterStatusFilePath))
            {
                File.WriteAllText(monsterStatusFilePath, $"{selectedMonsterType}\nLvl: 0\nHP: 0\nStamina: 0\nAttack: 0\nExp: 0");
            }

            Message2.Text = $"   Monster '{monsterName}' saved successfully!";
            Message2.ForeColor = Color.Green;
            panelNextMonsterName.Visible = true;
            MonsterRegister.Enabled = false;
        }


        private void nextMonsterName_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = Begining;

        }

        //cria dentro da pasta do user ficheiros txt com a lista de nome dos monstros para nao haver repetiçoes, 
        //e um ficheiro onde vai guardar os status do monstro




        // void login com user existente

        private void loginButton_Click(object sender, EventArgs e)
        {
            string user = usernameLogin.Text.Trim();
            string pass = passwordLogin.Text.Trim();
            string usernameFilePath = Path.Combine(Application.StartupPath, "Resources", "username.txt");
            string passwordFilePath = Path.Combine(Application.StartupPath, "Resources", "password.txt");

            MessageLogin.Text = string.Empty;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                MessageLogin.Text = "[ERROR] Please insert a username and password";
                MessageLogin.ForeColor = Color.Red;
                return;
            }


            var usernames = File.ReadAllLines(usernameFilePath).Select(u => u.Trim()).ToArray();
            var passwords = File.ReadAllLines(passwordFilePath).Select(p => p.Trim()).ToArray();

            int userIndex = Array.IndexOf(usernames, user);
            int passIndex = Array.IndexOf(passwords, pass);


            if (userIndex == -1)
            {
                MessageLogin.Text = "[ERROR] Username not found";
                MessageLogin.ForeColor = Color.Red;
                return;
            }

            if (passIndex == -1)
            {
                MessageLogin.Text = "[ERROR] Incorrect password";
                MessageLogin.ForeColor = Color.Red;
                return;
            }


            Monsters.SelectedTab = LoadedGame;
        }





        // voids menu First Monster









        //voids botoes Load Game
        private void myMonsters1_Click(object sender, EventArgs e)
        {

            Monsters.SelectedTab = MyMonsters;
        }

        private void Player1_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = Player;
        }

        private void Exit1_Click(object sender, EventArgs e)
        {
            // Fazer confirmaçao se quer sair e se sim, se quer salvar o jogo
            Monsters.SelectedTab = Home;
        }




        //voids botoes menu Monster Page

        private void statusPrint_TextChanged(object sender, EventArgs e)
        {
            
            string userDirectoryPath = Path.Combine(Application.StartupPath, "Resources", user);
            string monsterName = Path.Combine(userDirectoryPath, "monsterName.txt");
            string usernameFilePath = Path.Combine(Application.StartupPath, "Resources", "username.txt");
            string user = File.ReadAllLines(usernameFilePath).FirstOrDefault()?.Trim();

            string statusFilePath = Path.Combine(userDirectoryPath, $"{monsterName}_monsterStatus.txt");

            try
            {
                if (File.Exists(statusFilePath))
                {
                    string[] lines = File.ReadAllLines(statusFilePath);
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);

                    }
                }
                else
                {
                    Console.WriteLine("[INFO] Ficheiro de status não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] " + ex.Message);
            }





        //voids botoes menu Player
        private void MyMonsters2_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = MyMonsters;

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
            Monsters.SelectedTab = Home;
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


        }

        private void myMonsterFirst_Click(object sender, EventArgs e)
        {
            Monsters.SelectedTab = FirstMonster;
        }

       
        }
    }
}
