using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML
{
    class XMLReader
    {
        //https://www.youtube.com/watch?v=M4aXKPN0nK0

        public void Read(string file, Kolekcja collection)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            foreach (XmlNode mainNode in xmlDoc.DocumentElement)
            {
                foreach (XmlNode ulubione in mainNode.ChildNodes)
                {
                    foreach (XmlNode node in ulubione.ChildNodes)
                    {
                        if (node.Name == "gra")
                        {
                            string id = node.Attributes[0].InnerText;
                            string genere = node.Attributes[1].InnerText;
                            string title = node.ChildNodes[0].InnerText;
                            string dev = node.ChildNodes[1].InnerText;
                            string releseDate = node.ChildNodes[2].InnerText;
                            string publisher = node.ChildNodes[3].Attributes[0].InnerText;
                            string price = node.ChildNodes[4].InnerText;
                            string madedate = node.ChildNodes[5].InnerText;

                            collection.AddGame(id, title, genere, dev, releseDate, publisher, price, madedate);
                            /*foreach (XmlNode child in node.ChildNodes)
                            {
                            }*/
                        }
                    }
                }
            }
        }
    }
}
