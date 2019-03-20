using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cceditior
{
 
        public class ItemList
        {
            [XmlArray("Items")]
            [XmlArrayItem("Item")]
            public List<Item> items { get; set; }

            public ItemList()
            {
                items = new List<Item>();
            }
        }
}
