using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cceditior
{
    [Serializable]
    public class Item
    {
        public string Name { get; set; }
        public int UnlockRequirement { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }
    }
}
