using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hafta_2.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }  //fiyat

        public string Description { get; set; }  // açıklama

        public string Publisher { get; set; }  //yayımcı 

        public DateTime ReleaseDate { get; set; } //yayın tarihi
    }
}
