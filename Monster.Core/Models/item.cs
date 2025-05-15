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
    public class StaminaItem : Item
    {
        public int staminaPoints { get; set; } = 15;
    }
}
