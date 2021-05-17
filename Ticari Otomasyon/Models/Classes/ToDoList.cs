using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticari_Otomasyon.Models.Classes
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Baslik { get; set; }

        public bool Durum { get; set; }
    }
}