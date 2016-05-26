using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FacebookSmartView
{
    /// <summary>
    /// This is an abstract class (cannot have an instance - not needed)
    /// It implements the DeepCopyClone for a generic T
    /// No needed Prototype factory because there are not much classes to create
    /// </summary>
    /// <typeparam name="T">Generic Class T to Clone</typeparam>
    public abstract class CloneClass<T> 
    {
        public T DeepObjectClone(T i_ObjectToClone)
        {
            T m_NewClone = (T)i_ObjectToClone.DeepClone();
            return m_NewClone;
        }

    }

    /// <summary>
    /// This Class helps implementing DeepClone.
    /// Cloned classes must have [Serializeable] on cloned objects
    /// Properties that cannot be cloned, must have [NotSerializeable]
    /// </summary>
    public static class ObjectSpecialFunctions
    {
        public static object DeepClone(this object i_ObjectToClone)
        {
            using (MemoryStream m_MemorySteam = new MemoryStream())
            {
                BinaryFormatter m_BinFormatter = new BinaryFormatter();
                m_BinFormatter.Serialize(m_MemorySteam, i_ObjectToClone);
                m_MemorySteam.Seek(0, SeekOrigin.Begin);
                object newclonedclass = (object)m_BinFormatter.Deserialize(m_MemorySteam);
                m_MemorySteam.Close();
                return newclonedclass;
            }
        }
    }
}
