using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Holdingbackthefool
{
    internal class Tauro : Monster
    {
        public int rage { get; set; }
        public string nature;

        public Tauro() : base()
        {
            rage = 100;
            nature = "Tauro";
        }
        public override string GetNature()
        {
            return "Tauro";
        }

        public Tauro(int hp, int stamina, int level, int exp, string name, int rage) : base(hp, stamina, level, exp, name)
        {
            this.rage = rage;
        }
    }
}
