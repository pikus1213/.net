using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerwisSamochodowy.Models
{
    [Table("Klients")]
    public class Klient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public virtual ICollection<Samochod> Samochods { get; set; }

        public string ImieNazwiskoK
        {
            get
            {
                return Imie + " " + Nazwisko;
            }
        }
    }
}
