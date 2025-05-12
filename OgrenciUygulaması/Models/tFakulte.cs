using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OgrenciUygulaması.Models
{
    public class tFakulte
    {
        [Key]
        public int fakulteID { get; set; }
        public string fakulteAd { get; set; }

        public virtual ICollection<tBolum> Bolumler { get; set; }
    }
}