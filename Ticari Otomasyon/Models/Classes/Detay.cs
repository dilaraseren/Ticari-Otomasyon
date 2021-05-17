using System.ComponentModel.DataAnnotations;

namespace Ticari_Otomasyon.Models.Classes
{
    public class Detay
    {
        [Key]
        public int DetayId{ get; set; }
       
        [StringLength(30)]
        public string UrunAd { get; set; }

        [StringLength(2000)]
        public string UrunBilgi { get; set; }
    }
}