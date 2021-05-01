using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticari_Otomasyon.Models.Classes
{
    public class Departman
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }

        public ICollection<Personel> Personels { get; set; }
    }
}