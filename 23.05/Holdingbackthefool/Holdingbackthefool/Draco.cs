using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdingbackthefool
{
    internal class Draco : Monster
    {
        public int fire { get; set; }
        public string nature;


        public Draco() : base()
        {
            fire = 100;
            nature = "Draco";
        }

        public override string GetNature()
        {
            return "Draco";
        }

        public Draco(int hp, int stamina, int level, int exp, string name, int fire) : base(hp, stamina, level, exp, name)
        {
            this.fire = fire;
        }

    }
}
