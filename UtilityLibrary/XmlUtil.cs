using System;
using System.IO;
using System.Xml.Serialization;

namespace UtilityLibrary
{
    public class XmlUtil
    {
        public static string GetXMLString(Object obj)
        {
            XmlSerializer x = new XmlSerializer(obj.GetType());
            var stringWriter = new StringWriter();
            x.Serialize(stringWriter, obj);
            var xmlStringContent = stringWriter.ToString();
            return xmlStringContent;
        }
    }
}
