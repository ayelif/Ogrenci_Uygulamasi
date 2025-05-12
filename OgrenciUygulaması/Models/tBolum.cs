using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OgrenciUygulaması.Models
{
    public class tBolum
    {

        [Key]
        public int bolumID { get; set; }
        public string bolumAd { get; set; }

        [ForeignKey("Fakulte")]
        public int fakulteID { get; set; }
        public virtual tFakulte Fakulte { get; set; }

        public virtual ICollection<tOgrenci> Ogrenciler { get; set; }
    }
}