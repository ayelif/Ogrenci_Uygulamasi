using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OgrenciUygulaması.Models
{
    public class tOgrenciDers
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Ogrenci")]
        public int ogrenciID { get; set; }
        public virtual tOgrenci Ogrenci { get; set; }

        [ForeignKey("Ders")]
        public int dersID { get; set; }
        public virtual tDers Ders { get; set; }

        public string yil { get; set; }
        public string yariyil { get; set; }
        public int? vize { get; set; }
        public int? final { get; set; }

    }
}