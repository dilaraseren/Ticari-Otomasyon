﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticari_Otomasyon.Models.Classes
{
    public class Personel
    {

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Ad { get; set; }

        [StringLength(50)]
        public string Soyad { get; set; }

        [StringLength(50)]
        public string PersonelGorseli { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public Departman Departman { get; set; }
    }
}