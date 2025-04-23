using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holdingbackthefool
{
    internal class Siren : Monster
    {
        public int voice { get; set; }
        public string nature;


        public Siren() : base()
        {
            voice = 100;
            nature = "Siren";
        }
        public override string GetNature()
        {
            return "Siren";
        }

        public Siren(int hp, int stamina, int level, int exp, string name, int voice) : base(hp, stamina, level, exp, name)
        {
            this.voice = voice;
        }
    }
}
