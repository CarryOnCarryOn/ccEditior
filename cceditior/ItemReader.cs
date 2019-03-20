using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace cceditior
{
    class ItemReader
    {
        XmlSerializer itemserializer;
        public ItemReader()
        {
            itemserializer = new XmlSerializer(typeof(Item));
        }
        public ItemList Load(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new Exception(string.Format("{0} does not exist", filepath));
            }

            ItemList list = null;
            using (var file = new StreamReader(filepath))
            {
                try
                {
                    list = itemserializer.Deserialize(file) as ItemList;
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Unable to deserialize the {0} due to following: {1}",
                        filepath, ex.Message));
                }
            }

            return list;
        }

    }


}
