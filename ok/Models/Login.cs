using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ok.Models
{
    public class Login
    {
        [Key]
        public int idUtente { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        [NotMapped]
        public string? ConfermaPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appunti> Appunti { get; set; }
    }
}