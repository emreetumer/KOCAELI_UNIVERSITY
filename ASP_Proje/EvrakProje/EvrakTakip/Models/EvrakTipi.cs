using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakip.Models
{
    public class EvrakTipi
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Evrak adının girilmesi gerekmektedir!")]
        public string EvrakAdi { get; set; }


        [Required(ErrorMessage = "Evrak fiyatının girilmesi gerekmektedir!")]
        public double EvrakFiyati { get; set; }
    }
}
