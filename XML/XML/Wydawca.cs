using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML
{
    public class Wydawca
    {
        private string id;
        private string name;
        private string city;
        private string street;
        private string streetnr;
        private string postal;
        private string phone;
        private string kier;

        public Wydawca()
        {

        }

        public Wydawca(string id, string name, string city, string street, string streetnr, string postal, string phone, string kier)
        {
            this.id = id;
            this.name = name;
            this.city = city;
            this.street = street;
            this.streetnr = streetnr;
            this.postal = postal;
            this.phone = phone;
            this.kier = kier;
        }

        public string Name { get => name; set => name = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public string Streetnr { get => streetnr; set => streetnr = value; }
        public string Postal { get => postal; set => postal = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Kier { get => kier; set => kier = value; }
        public string Id { get => id; set => id = value; }
    }
}
