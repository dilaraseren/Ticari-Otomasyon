using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ticari_Otomasyon.Models.Classes
{
    public class Fatura
    {
        [Key]
        public int Id { get; set; }

        [StringLength(1)]
        public string SeriNo { get; set; }

        [StringLength(6)]
        public string SiraNo { get; set; }

        public DateTime Tarih { get; set; }

        [StringLength(50)]
        public string VergiDairesi { get; set; }

        [StringLength(50)]
        public string TeslimEden { get; set; }

        [StringLength(50)]
        public string TeslimAlan { get; set; }


        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Saat { get; set; }

        public decimal Toplam { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}