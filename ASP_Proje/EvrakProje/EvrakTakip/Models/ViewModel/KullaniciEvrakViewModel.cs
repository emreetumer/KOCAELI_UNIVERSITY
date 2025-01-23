using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakip.Models.ViewModel
{
    public class KullaniciEvrakViewModel
    {
        public ApplicationUser KullaniciObj { get; set; }
        public IEnumerable<Evrak> Evraklar { get; set; }
    }
}
