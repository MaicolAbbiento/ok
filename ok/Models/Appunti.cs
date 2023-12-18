using System.ComponentModel.DataAnnotations;

namespace ok.Models
{
    public class Appunti
    {
        [Key]
        public int id { get; set; }

        public string? titolo { get; set; }
        public string? descrizione { get; set; }
        public DateTime data { get; set; }
        public int idUtente { get; set; }
        public Login Utente { get; set; }
    }
}