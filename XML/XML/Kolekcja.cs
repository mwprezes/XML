using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    public class Kolekcja
    {
        private ObservableCollection<Gra> games;
        private ObservableCollection<Wydawca> publishers;

        public Kolekcja()
        {
            games = new ObservableCollection<Gra>();
            publishers = new ObservableCollection<Wydawca>();
        }

        public ObservableCollection<Gra> Games { get => games; set => games = value; }
        public ObservableCollection<Wydawca> Publishers { get => publishers; set => publishers = value; }

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
        public void AddPublisher(string id, string name, string city, string street, string streetnr, string postal, string phone, string kier)
        {
            Wydawca wyd = new Wydawca(id, name, city, street, streetnr, postal, phone, kier);
            publishers.Add(wyd);
        }
    }
}