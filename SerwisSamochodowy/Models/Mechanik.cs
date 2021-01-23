using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SerwisSamochodowy.Models
{
    [Table("Mechaniks")]
    public class Mechanik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public virtual ICollection<Zlecenie> Zlecenies { get; set; }
        public string ImieNazwiskoM
        {
            get
            {
                return Imie + " " + Nazwisko;
            }
        }
    }
}
