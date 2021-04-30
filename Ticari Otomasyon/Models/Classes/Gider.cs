using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticari_Otomasyon.Models.Classes
{
    public class Gider
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}