﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fuel_manager.Models
{
    [Table("Veiculos")]
    public class Veiculo : LinksHATEOS
    {
        [Key]
        public int Id  { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public string Modelo { get; set;}
        [Required]
        public string Placa { get; set;}
        [Required]
        public int AnoFabricacao { get; set; }
        [Required]
        public int AnoModelo { get; set;}
        public ICollection<Consumo> Consumos { get; set; }
    }
}
