using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maki_it_happen
{
    internal class Drink : Product
    {
        public string ?Rozmiar { get; set; }
        public bool KostkiLodu { get; set; }

        public Drink(string Nazwa, double Cena, int Id, int Ilosc, string Rozmiar, bool KostkiLodu) : base(Nazwa, Cena, Id)
        {

            this.Rozmiar = Rozmiar;
            this.KostkiLodu = KostkiLodu;

        }

        public override string AboutProduct()
        {
            string Odpowiedz;
            if (KostkiLodu == true)
            {
                Odpowiedz = "z kostkami lodu";
            }
            else
            {
                Odpowiedz = "bez kostek lodu";
            }
            return $"Produkt o id {Id} i nazwie {Nazwa} kosztuje {Cena}. Jest on w rozmiarze {Rozmiar} {Odpowiedz}";

        }
    }

}

