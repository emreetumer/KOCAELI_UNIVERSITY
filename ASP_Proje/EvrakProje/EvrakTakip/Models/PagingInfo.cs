using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvrakTakip.Models
{
    public class PagingInfo
    {
        //Kullanıcıların Toplam Sayısı
        public int TotalItems { get; set; }

        //Her Sayfada Gösterilecek Kullanıcı Sayım
        public int ItemsPerPage { get; set; }

        //Güncel Sayfam Tutulacak
        public int CurrentPage { get; set; }

        //Toplam Sayfayı Gösterecek
        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

        //URL Adresim İçin
        public string UrlParam { get; set; }
    }
}
