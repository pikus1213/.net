using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SerwisSamochodowy.Models
{
    [Table("Zlecenies")]
    public class Zlecenie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string OpisUsterki { get; set; }
        public bool Aktywne { get; set; }
        public int IdSamochodu { get; set; }
        public Samochod Samochod { get; set; }
        public int IdMechanika { get; set; }
        public Mechanik Mechanik { get; set; }


    }
}
