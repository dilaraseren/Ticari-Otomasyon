using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticari_Otomasyon.Models.Classes
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string KullaniciAdi { get; set; }

        [StringLength(10)]
        public string Sifre { get; set; }

        [StringLength(10)]
        public string Yetki { get; set; }
    }
}