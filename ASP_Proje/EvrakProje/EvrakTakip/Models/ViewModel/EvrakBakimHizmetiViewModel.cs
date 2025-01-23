using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakip.Models.ViewModel
{
    public class EvrakBakimHizmetiViewModel
    {
        public Evrak Evrak { get; set; }
        public BakimHizmetiGenel BakimHizmetGenel { get; set; }
        public BakimHizmetiDetay BakimHizmetDetay { get; set; }

        public List<EvrakTipi> EvrakTipleriListesi { get; set; }
        public List<BakimHizmetKart> BakimHizmetKart { get; set; }
    }
}
