using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace cceditior
{
    class CheckBoxList
    {
        public List<CheckBox> MyCheckBoxlist { get; set; }
        
        public CheckBoxList()
        {
            MyCheckBoxlist = new List<CheckBox>();
        }
    }
}
