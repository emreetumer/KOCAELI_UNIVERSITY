using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakip.Models
{
    public class BakimHizmetiDetay
    {
        public int Id { get; set; }
        public int BakimHizmetiGenelId { get; set; }

        [ForeignKey("BakimHizmetiGenelId")]
        public virtual BakimHizmetiGenel BakimHizmetiGenel { get; set; }


        [Display(Name = "Evrak")]
        public int EvrakTipiId { get; set; }

        [ForeignKey("EvrakTipiId")]
        public virtual EvrakTipi EvrakTipi { get; set; }

        public double EvrakFiyati { get; set; }
        public string EvrakAdi { get; set; }
    }
}
