using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Maki_it_happen
{
    internal class ZamowienieNaMiejscu : Zamowienie
    {
        public int NumerStolika { get; set; }

        public ZamowienieNaMiejscu(Product produkt, int ilosc, decimal cena, int stolik) : base(produkt, ilosc, cena)
        {
            NumerStolika = stolik;
        }
    }
}