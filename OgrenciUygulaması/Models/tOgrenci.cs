using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OgrenciUygulaması.Models
{
    public class tOgrenci
    {
        [Key]
        public int ogrenciID { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }

        [ForeignKey("Bolum")]
        public int bolumID { get; set; }
        public virtual tBolum Bolum { get; set; }

        public virtual ICollection<tOgrenciDers> OgrenciDersler { get; set; }
    }
}