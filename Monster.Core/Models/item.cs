using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.Core.Models
{
    public class Item
    {
        public int quantity { get; set; } = 0;

        public string name { get; set; } = "default";
        
    }

    public class HealthItem : Item
    {
        public int hpPoints { get; set; } = 15;
    }
    public class EnergyItem : Item
    {
        public int energyResto { get; set; } = 15;
    }
}
