using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OgrenciUygulaması.Models
{
    public class OgrenciNotViewModel
    {
        public int OgrenciDersID { get; set; }
        public string OgrenciAdSoyad { get; set; }
        public int? Vize { get; set; }
        public int? Final { get; set; }

    }
}