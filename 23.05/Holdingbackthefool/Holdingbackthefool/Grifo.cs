using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdingbackthefool
{
    internal class Grifo : Monster
    {
        public int fly { get; set; }
        public string nature;

        public Grifo() : base()
        {
            fly = 100;
            nature = "Grifo";
        }

        public override string GetNature()
        {
            return "Grifo";
        }

        public Grifo(int hp, int stamina, int level, int exp, string name, int fly) : base(hp, stamina, level, exp, name)
        {
            this.fly = fly;
        }
    }
}
