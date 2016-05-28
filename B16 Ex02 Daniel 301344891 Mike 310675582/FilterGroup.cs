using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

using FacebookWrapper.ObjectModel;

namespace FacebookSmartView
{
    public class FilterGroup : IEnumerable, IXmlSerializable, IFilter
    {
        private IList<IFilter> m_FilterItems;
        private static readonly string sr_GroupNameAttribute = "Name";
        private const string sr_FilterItemElement = "FilterItem";
        private const string sr_FilterGroupElement = "FilterGroup";

        public string Name { get; set; }

        public FilterGroup()
        {
            m_FilterItems = new List<IFilter>();
        }

        public void AddItem(IFilter i_NewItemToFilter)
        {
            m_FilterItems.Add(i_NewItemToFilter);
        }

        public void RemoveItem(IFilter i_ItemToDelete)
        {
            m_FilterItems.Remove(i_ItemToDelete);
        }

        public bool IsMatch(Post i_Post)
        {
            return m_FilterItems.Any(item => item.IsMatch(i_Post));
        }

        public IEnumerator GetEnumerator()
        {
            foreach (IFilter item in m_FilterItems)
            {
                yield return item;
            }
        }

        public override string ToString()
        {
            return "*" + Name + "*";
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader i_Reader)
        {
            Name = i_Reader.GetAttribute(sr_GroupNameAttribute);
            i_Reader.ReadStartElement();
            i_Reader.ReadStartElement(sr_FilterItemElement);
            while (i_Reader.IsStartElement())
            {
                XmlSerializer serializer;

                switch (i_Reader.Name)
                {
                    case sr_FilterItemElement:
                        serializer = new XmlSerializer(typeof(FilterItem));
                        m_FilterItems.Add(serializer.Deserialize(i_Reader) as FilterItem);
                        i_Reader.ReadStartElement();
                        break;
                    case sr_FilterGroupElement:
                        serializer = new XmlSerializer(typeof(FilterGroup));
                        m_FilterItems.Add(serializer.Deserialize(i_Reader) as FilterGroup);
                        break;
                }
            }

            i_Reader.ReadEndElement();
            i_Reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter i_Writer)
        {
            i_Writer.WriteAttributeString(sr_GroupNameAttribute, Name);
            i_Writer.WriteStartElement(sr_FilterItemElement);

            foreach (IFilter item in m_FilterItems)
            {
                XmlSerializer seralizer = new XmlSerializer(item.GetType());
                {
                    seralizer.Serialize(i_Writer, item);
                }
            }

            i_Writer.WriteEndElement();
        }
    }
}
