using System.ComponentModel.DataAnnotations;

namespace Hafta_2.Models
{
    public class GameDTO
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }  //fiyat
        [Required]
        [MinLength(10)]
        public string Description { get; set; }  // açıklama
        [Required]
        public string Publisher { get; set; }  //yayımcı 
        [Required]
        public DateTime ReleaseDate { get; set; } //yayın tarihi


    }
}
