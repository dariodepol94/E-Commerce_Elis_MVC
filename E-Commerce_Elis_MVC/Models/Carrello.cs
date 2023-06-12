using E_Commerce_Elis_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Elis_MVC.Models
{
    public partial class Carrello
    {
        public int IdCarrello { get; set; }
        public List<Prodotto> ProdottiNelCarrello { get; set; }
        public Carrello()
        {
            ProdottiNelCarrello = new List<Prodotto>();
        }
    }
}