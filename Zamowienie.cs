using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maki_it_happen
{
    internal class Zamowienie
    {
        public Product Produkt { get; set; }
        public int Ilosc { get; set; }
        public decimal CenaZamowienia { get; set; }

        public Zamowienie(Product produkt, int ilosc, decimal cena)
        {
            Produkt = produkt;
            Ilosc = ilosc;
            CenaZamowienia = cena;

        }

        public void ObliczCeneZamowienia()
        {
            CenaZamowienia = (decimal)(Produkt.Cena * Ilosc);
        }
    }
}
