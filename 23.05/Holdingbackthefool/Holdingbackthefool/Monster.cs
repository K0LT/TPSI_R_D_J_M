using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Holdingbackthefool
{
    internal class Monster
    {
        //Atributos do Monstro
        public int hp { get; set; }

        public int stamina { get; set; }

        public int level { get; set; }

        public int exp { get; set; }

        public string name { get; set; }

        public Monster() //Atributos base do monstro
        {
            hp = 100;
            stamina = 100;
            level = 1;
            exp = 0;
            name = "Undefined";
        }

        public Monster(int newHP, int newStamina, int newLevel, int newXP, string newName) //Em caso de testes para criar um novo monstro
        {
            hp = newHP;
            stamina = newStamina;
            level = newLevel;
            exp = newXP;
            name = newName;
        }

            public virtual string GetNature()
    {
        return "Generic Monster";
    }


        public void PunchYourself()
        {
            if (hp > 0)
            {
                hp -= 1;
            }
        }

        public void Run()
        {
            if (stamina > 10)
            {
                stamina -= 10;
            }
            
        }

        public void GainExperience()
        {
             exp += 10;

            if (exp > 99)
            {
                exp = 0;
                level++;
            }
 
           
        }

        public bool Fight(int num1, int num2, int answer)
        {
            int correct = num1 + num2;

            if (correct == answer)
            {
                exp += 50;
                if (exp > 99)
                {
                    exp = 0;
                    level++;
                }
                return true;
            }

            exp -= 50;
            if (exp < 0)
            {
               exp = 0;
            }
            return false;

           

        }





    }
}
