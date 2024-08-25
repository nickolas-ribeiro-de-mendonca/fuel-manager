﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fuel_manager.Models
{
    [Table("consumos")]
    public class Consumo
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public TipoCombustivel Tipo {  get; set; }

        [Required]
        public int VeiculoId {  get; set; }

        public Veiculo Veiculo { get; set; }

    }

    public enum TipoCombustivel
    {
        Disel,
        Etanol,
        Gasolina
    }
}
