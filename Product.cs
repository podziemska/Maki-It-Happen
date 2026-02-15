using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maki_it_happen
{
    internal class Product
    {
       
        public string ?Nazwa { get; set; }
        public double Cena { get; set; }
        public int Id { get; set; }

        public Product(string Nazwa, double Cena, int Id) {
            this.Nazwa = Nazwa;
            this.Cena = Cena;
            this.Id = Id;
        }

        public virtual string AboutProduct() {
            return $"Produkt o id {Id} i nazwie {Nazwa} kosztuje {Cena}";
        }

        public void Cost() {
            if (Cena <= 0)
            {
                Console.WriteLine("Cena musi byc dodatnia.");
            }
            
        }

    }
}
