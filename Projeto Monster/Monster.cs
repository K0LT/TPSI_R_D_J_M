using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Monster
{
    //Classe mãe dos monstros
    internal class Monster
    {
        //Atributos do Monstro
        private int hp { get; set; }

        private int stamina { get; set; }

        //private int level { get; set; }

        private int exp { get; set; }

        private string name;
        public Monster() //Atributos base do monstro
        {
            hp = 100;
            stamina = 100;
            level = 1;
            exp = 0;
            name = "Undifined";
        }

        private Monster (int newHP, int newStamina, int newLevel, int newXP, string newName) //Em caso de testes para criar um novo monstro
        {
            hp = newHP;
            stamina = newStamina;
            level = newLevel;
            exp = newXP;
            name = newName;
        }

        public void SetName (string newName) //Definir nome do monstro
        {
            name = newName;
        }

        private string GetName() //Receber o nome de um monstro
        {
            return name;
        }

        public int GetExp()
        {
            return exp;
        }

        public int GetLevel()
        {
            return level;
        }

        public void ShowInfo()
        {
            Console.WriteLine("Name: " + name + "\n" + "HP: " + hp + "\n" + "Stamina: " + stamina + "\n" + "Level: " + level + "\n" + "Experience: " + exp);
        }

        public void PunchYourself()
        {
            hp -= 1;
            Console.WriteLine("You hurt yourself. Don't do that");
        }

        public void Run()
        {
            stamina -= 10;
            Console.WriteLine("Running as fast as fuck, boy");
        }

        public void GainExperience()
        {
            exp += 10;
            Console.WriteLine("You are now wiser.");
        }

        public void LevelUp()
        {
            level += 1;
            exp = 0;
        }

        public int Evolution()
        {
            int tipo = 0;

            Console.WriteLine("Para que tipo queres evoluir? 1: Draco, 2: Grifo, 3: Siren, 4: Tauro");
            tipo = int.Parse(Console.ReadLine());
            return (tipo);
        }

        public void Fight()
        {
            Random rand = new Random();
            int num1 = rand.Next(1, 11); // de 1 a 10
            int num2 = rand.Next(1, 11); // de 1 a 10
            int correctAnswer = num1 + num2;
            int userAnswer = 0;
            Console.WriteLine("Quanto é:" + num1 + " +" + num2);
            userAnswer = int.Parse(Console.ReadLine());

            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("You are correct. + 50 exp");
                exp += 50;
                Console.WriteLine("Press Something");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You were wrong. - 50 exp");
                exp += 50;
                if (exp < 0)
                {
                    exp = 0;
                }
                Console.WriteLine("Press Something");
                Console.ReadLine();
            }


        }





    }
}
