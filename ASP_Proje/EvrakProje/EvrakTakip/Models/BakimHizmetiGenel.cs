using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakip.Models
{
    public class BakimHizmetiGenel
    {
        public int Id { get; set; }
        public double EvrakSayacSaat { get; set; }

        [Required]
        public double ToplamFiyat { get; set; }
        public string Detaylar { get; set; }

        [Required]

        [DisplayFormat(DataFormatString = "{0:MMM dd yyy}")]
        public DateTime EklendigiTarih { get; set; }

        public int EvrakId { get; set; }

        [ForeignKey("EvrakId")]
        public virtual Evrak Evrak { get; set; }
    }
}
