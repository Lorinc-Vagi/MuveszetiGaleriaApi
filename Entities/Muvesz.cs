﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MuveszetiGaleriaApi.Entities
{
    public class Muvesz
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Phone { get; set; }
    }
}
