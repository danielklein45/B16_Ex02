using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;


using FacebookWrapper.ObjectModel;

namespace FacebookSmartView
{
    public interface IFilter: IXmlSerializable
    {
        bool IsMatch(Post i_Post);
    }
}
