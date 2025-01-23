using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakip.Models
{
    public class BakimHizmetKart
    {
        public int Id { get; set; }
        public int EvrakId { get; set; }
        public int EvrakTipiId { get; set; }


        [ForeignKey("EvrakId")]
        public virtual Evrak Evrak { get; set; }


        [ForeignKey("EvrakTipiId")]
        public virtual EvrakTipi EvrakTipi { get; set; }
    }
}
