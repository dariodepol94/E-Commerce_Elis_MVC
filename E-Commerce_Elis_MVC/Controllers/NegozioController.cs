using E_Commerce_Elis_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Elis_MVC.Controllers
{
    public class NegozioController : Controller
    {
        private readonly NegozioDbContext _context;
        private readonly Negozio negozio;

        public NegozioController(NegozioDbContext context)
        {
            _context = context;
        }

        public IActionResult VisualizzaProdotti()
        {
            var prodottiDisponibili = negozio.ListaProdotti;
            ViewBag.ListaProdotti = prodottiDisponibili;
            return View();
        }
        public IActionResult AggiungiProdotto(int prodottoId)
        {
            var prodotto = _context.Prodotti.FirstOrDefault(p => p.IdProdotto == prodottoId);
            if (prodotto != null && prodotto.Quantita > 0)
            {
                prodotto.Quantita++;
                _context.Add(prodotto);
                _context.SaveChanges();
                return RedirectToAction("VisualizzaProdotti");
            }
            return View();
        }
        public IActionResult RimuoviProdotto(int prodottoId)
        {
            var prodotto = _context.Prodotti.FirstOrDefault(p => p.IdProdotto == prodottoId);
            if (prodotto != null && prodotto.Quantita > 0)
            {
                prodotto.Quantita++;
                _context.Remove(prodotto);
                _context.SaveChanges();
                return RedirectToAction("VisualizzaProdotti");
            }
            return View();
        }
    }
}
