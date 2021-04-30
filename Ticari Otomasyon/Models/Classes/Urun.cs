using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticari_Otomasyon.Models.Classes
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Marka { get; set; }
        public short StokAdedi { get; set; }
        public decimal AlısFiyati { get; set; }
        public decimal SatisFiyati { get; set; }
        public bool Durum { get; set; }

        [StringLength(250)]
        public string UrunGorseli { get; set; }
        public virtual Kategori Kategori { get; set; }
        public int KategoriId { get; set; }
       
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}