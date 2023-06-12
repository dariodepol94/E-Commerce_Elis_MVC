namespace E_Commerce_Elis_MVC.Models
{
    public partial class Utente
    {
        public int IdUtente { get; set; }
        public string? Nome { get; set; }
        public Carrello Carrello { get; set; }

        public Utente()
        {
            Carrello = new Carrello();
        }
    }
}
