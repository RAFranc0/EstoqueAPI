using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstoqueAPI.Models
{
    public class ProdutoModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        public double ValorUnitario { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public DateTime DataInsercao { get; set; } = DateTime.UtcNow;

        public DateTime? DataModificacao { get; set; }

        [Required]
        public Guid UsuarioId { get; set; }
    }
}