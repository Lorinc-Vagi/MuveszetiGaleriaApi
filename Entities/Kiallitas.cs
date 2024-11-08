using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MuveszetiGaleriaApi.Entities
{
    public class Kiallitas

    {
        public int Id { get; set; }
        [Required]

        public string RoomName { get; set; }
        [Required]

        public string Felelos { get; set; }

    }
}
