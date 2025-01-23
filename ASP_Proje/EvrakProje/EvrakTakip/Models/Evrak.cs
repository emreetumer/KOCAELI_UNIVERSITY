using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakip.Models
{
    public class Evrak
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Gonderen { get; set; }

        [Required]
        public string Alici { get; set; }

        [Required]
        public string Model { get; set; }

        public string EvrakTipi { get; set; }

        [Required]
        public int Yil { get; set; }

        [Required]
        public double EvrakSaatSayac { get; set; }

        public string EkAciklama { get; set; }

        public string KullaniciId { get; set; }

        [ForeignKey("KullaniciId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
