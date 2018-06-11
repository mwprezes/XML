using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    public class Gra
    {
        string id;
        string title;
        string genere;
        string dev;
        string releseDate;
        string publisher;
        string price;
        string madedate;

        public Gra(string id, string title, string genere, string dev, string releseDate, string publisher, string price, string madedate)
        {
            this.id = id;
            this.title = title;
            this.genere = genere;
            this.dev = dev;
            this.releseDate = releseDate;
            this.publisher = publisher;
            this.price = price;
            this.madedate = madedate;
        }

        public string Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Genere { get => genere; set => genere = value; }
        public string Dev { get => dev; set => dev = value; }
        public string ReleseDate { get => releseDate; set => releseDate = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string Price { get => price; set => price = value; }
        public string Madedate { get => madedate; set => madedate = value; }
    }
}
