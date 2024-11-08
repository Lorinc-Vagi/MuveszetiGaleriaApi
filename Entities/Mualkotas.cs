using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MuveszetiGaleriaApi.Entities
{
    public class Mualkotas
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]

        public int MuveszId { get; set; }
        [Required]

        public int KiallitasId { get; set; }

        [JsonIgnore]
        public Muvesz? Muvesz { get; set; }
        [JsonIgnore]
        public Kiallitas? Kiallitas { get; set; }
    }
}
