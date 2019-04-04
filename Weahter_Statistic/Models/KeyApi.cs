using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Weather_Statistic.Models
{
    public class KeyApi
    {
       private XmlDocument document;

        public KeyApi()
        {
            document = new XmlDocument();
            document.Load(@"C:\Key.xml");
        }

        public string LoadWeatherApi()
        {
            string result;
            XmlElement root = document.DocumentElement;
            result = root.FirstChild.InnerText;
       
            return result;
        }

        public string LoadLocationApi()
        {
            string result;
            XmlElement root = document.DocumentElement;
            result = root.LastChild.InnerText;

            return result;
        }
    }
}
