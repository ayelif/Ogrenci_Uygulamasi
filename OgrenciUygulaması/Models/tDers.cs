using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OgrenciUygulaması.Models
{
    public class tDers
    {
        [Key]
        public int dersID { get; set; }
        public string dersAd { get; set; }

        public virtual ICollection<tOgrenciDers> OgrenciDersler { get; set; }
    }
}