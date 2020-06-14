using System;
using System.Xml;

namespace Weather_Statistic.Models
{
    /// <summary>
    /// load key API from file XML require to load data
    /// line 20: place to modified path to file XML
    /// </summary>

    public class KeyApi
    {
       private XmlDocument document;

        public KeyApi()
        {
            document = new XmlDocument();
            try
            {
                document.Load(@"C:\Key.xml");
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private Exception Exception(string v)
        {
            throw new NotImplementedException();
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
