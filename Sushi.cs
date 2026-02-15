using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maki_it_happen
{
    internal class  Sushi : Product
    {
        public int Ilosc { get; set; }
        public string ?Skladniki { get; set; }
        public int PoziomOstrosci { get; set; }
        public bool CzyWegetarianskie { get; set; }

        public Sushi(string Nazwa, double Cena, int Id, int Ilosc, string Skladniki, int PoziomOstrosci, bool CzyWegetarianskie) : base(Nazwa, Cena, Id) 
        {

            this.Ilosc = Ilosc;
            this.Skladniki = Skladniki;
            this.PoziomOstrosci = PoziomOstrosci;
            this.CzyWegetarianskie = CzyWegetarianskie;

        }

        public override string AboutProduct()
        {
            string Odpowiedz;
            if (CzyWegetarianskie == true)
            {
                Odpowiedz = "jest";
            }
            else {
                Odpowiedz = "nie jest";
            }
                return $"Produkt o id {Id} i nazwie {Nazwa} kosztuje {Cena}. Posiada {Ilosc} kawalkow o {Skladniki} skladnikach. Poziom ostrosci sushi wynosi {PoziomOstrosci}, a sushi {Odpowiedz} wegetarianskie";
            
        }
    }
}
