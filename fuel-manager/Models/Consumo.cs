using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fuel_manager.Models
{
    [Table("Consumos")]
    public class Consumo
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")] //indica para o banco de dados que vai ser decimal com no max 18 digitos e 2 casas decimais
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
//comentaria para poder gerar mais um commit 