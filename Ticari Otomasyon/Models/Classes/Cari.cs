﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticari_Otomasyon.Models.Classes
{
    public class Cari
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        [StringLength(20)]
        public string Sehir { get; set; }

        [StringLength(100)]
        public string Mail { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}