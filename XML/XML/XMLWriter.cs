using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace XML
{
    class XMLWriter
    {
        public string originalFile;

        public void Write(string file, Kolekcja collection)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(originalFile);

            int numOfGames = 0;

            foreach (XmlNode mainNode in doc.DocumentElement)
            {
                foreach (XmlNode ulubione in mainNode.ChildNodes)
                {
                    foreach (XmlNode node in ulubione.ChildNodes)
                    {
                        if (node.Name == "gra")
                        {
                            if (numOfGames < collection.Games.Count) {
                                Gra game = collection.Games[numOfGames];
                                /*string id = node.Attributes[0].InnerText;
                                string genere = node.Attributes[1].InnerText;
                                string title = node.ChildNodes[0].InnerText;
                                string dev = node.ChildNodes[1].InnerText;
                                string releseDate = node.ChildNodes[2].InnerText;
                                string publisher = node.ChildNodes[3].Attributes[0].InnerText;
                                string price = node.ChildNodes[4].InnerText;
                                string madedate = node.ChildNodes[5].InnerText;*/
                                node.Attributes[0].InnerText = game.Id;
                                node.Attributes[1].InnerText = game.Genere;
                                node.ChildNodes[0].InnerText = game.Title;
                                node.ChildNodes[1].InnerText = game.Dev;
                                node.ChildNodes[2].InnerText = game.ReleseDate;
                                node.ChildNodes[3].Attributes[0].InnerText = game.Publisher;
                                node.ChildNodes[4].InnerText = game.Price;
                                node.ChildNodes[5].InnerText = game.Madedate;
                            }
                            else
                            {
                                node.RemoveAll();
                                node.ParentNode.RemoveChild(node);
                            }
                            numOfGames++;
                        }
                    }
                }
            }

            if(collection.Games.Count < numOfGames)
            {


            } else if(collection.Games.Count > numOfGames)
            {
                while (collection.Games.Count != numOfGames)
                {
                    Gra game = collection.Games[numOfGames];
                    XmlElement ulubione = doc.CreateElement("ulubione");
                    XmlElement newGame = doc.CreateElement("gra");
                        XmlAttribute newID = doc.CreateAttribute("id");
                            newID.InnerText = game.Id;
                        XmlAttribute newGen = doc.CreateAttribute("gatunek");
                            newGen.InnerText = game.Genere;
                        newGame.Attributes.Append(newID);
                        newGame.Attributes.Append(newGen);
                    XmlElement title = doc.CreateElement("tytuł");
                        title.InnerText = game.Title;
                        newGame.AppendChild(title);
                    XmlElement dev = doc.CreateElement("twórcy");
                        dev.InnerText = game.Dev;
                        newGame.AppendChild(dev);
                    XmlElement relese = doc.CreateElement("data_premiery");
                        relese.InnerText = game.ReleseDate;
                        newGame.AppendChild(relese);
                    XmlElement publisher = doc.CreateElement("dystrybutor");
                        XmlAttribute idref = doc.CreateAttribute("idref");
                            idref.InnerText = game.Publisher;
                            publisher.Attributes.Append(idref);
                        newGame.AppendChild(publisher);
                    XmlElement price = doc.CreateElement("cena");
                        XmlAttribute waluta = doc.CreateAttribute("waluta");
                            waluta.InnerText = "PLN";
                            price.Attributes.Append(waluta);
                        price.InnerText = game.Price;
                        newGame.AppendChild(price);
                    XmlElement prod = doc.CreateElement("rok_produkcji");
                        prod.InnerText = game.Madedate;
                        newGame.AppendChild(prod);
                    ulubione.AppendChild(newGame);
                    doc.DocumentElement.ChildNodes[1].AppendChild(ulubione);

                    numOfGames++;
                }
            }

            doc.Save(file);
        }
    }
}
