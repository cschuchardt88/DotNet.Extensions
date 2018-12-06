using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace System.Xml.Serialization
{
    [XmlRoot(Namespace = "http://www.Microsoft.com/2014/XMLSchema-Dictionary", ElementName = "Dictionary")]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        public SerializableDictionary()
        {
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            try
            { 
                reader.Read();

                if (reader.IsEmptyElement) return;

                while(reader.NodeType != XmlNodeType.EndElement)
                {
                    reader.ReadStartElement("Elements"); // <Elements>

                    reader.ReadStartElement("Key"); // <key>
                    TKey key = keySerializer.Deserialize(reader).ToTypeCast<TKey>();
                    reader.ReadEndElement(); // </key>

                    reader.ReadStartElement("Element"); // <Element>
                    TValue value = valueSerializer.Deserialize(reader).ToTypeCast<TValue>();
                    reader.ReadEndElement(); // </value>

                    this.Add(key, value);

                    reader.ReadEndElement(); // </item>
                    reader.MoveToContent();
                }

                reader.ReadEndElement();
            }
            catch
            {
                throw;
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));

            try
            { 
                foreach(TKey key in this.Keys)
                {
                    writer.WriteStartElement("Elements"); // <item>

                    writer.WriteStartElement("Key"); //<key>
                    keySerializer.Serialize(writer, key);
                    writer.WriteEndElement(); //</key>

                    writer.WriteStartElement("Element"); //<value>
                    object value = this[key];
                    valueSerializer.Serialize(writer, value);
                    writer.WriteEndElement();// </value>

                    writer.WriteEndElement(); // </item>
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
