using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cceditior
{
    [XmlRoot("ItemList")]
    public class ItemList
        {
            [XmlArray("Items")]
            [XmlArrayItem("Item")]
            public List<Item> Items { get; set; }

            public ItemList()
            {
                Items = new List<Item>();
            }
        }
}
