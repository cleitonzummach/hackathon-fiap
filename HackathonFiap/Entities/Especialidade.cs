using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HackathonFiap.Entities
{
    [Table("Especialidade")]
    public class Especialidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EspecialidadeId { get; set; }
        
        public string Nome { get; set; }
        
        public string? Descricao { get; set; }
    }
}