using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerwisSamochodowy.Models
{
    [Table("Samochods")]
    public class Samochod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Rejestracja { get; set; }
        public string Vin { get; set; }
        public int KlientId { get; set; }
        public Klient Klient { get; set; }
        public virtual ICollection<Zlecenie> Zlecenies { get; set; }

        public string NazwaSamochodu
        {
            get
            {
                return Marka + " " + Model+" ("+Rejestracja+")";
            }
        }

    }
}
