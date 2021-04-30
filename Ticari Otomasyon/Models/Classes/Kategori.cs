using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticari_Otomasyon.Models.Classes
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string KategoriAdi { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}