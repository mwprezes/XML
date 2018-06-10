using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    class Kolekcja
    {
        private List<Gra> games;
        private List<Wydawca> publishers;

        public Kolekcja()
        {
            games = new List<Gra>();
            publishers = new List<Wydawca>();
        }

        public List<Gra> Games { get => games; set => games = value; }
        public List<Wydawca> Publishers { get => publishers; set => publishers = value; }

        public void AddGame(Gra game)
        {
            games.Add(game);
        }
        public void AddGame(string id, string title, string genere, string dev, string releseDate, string publisher, string price, string madedate)
        {
            Gra game = new Gra(id, title, genere, dev, releseDate, publisher, price, madedate);
            games.Add(game);
        }

        public void AddPublisher(Wydawca publisher)
        {
            publishers.Add(publisher);
        }
    }
}
