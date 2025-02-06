using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HackathonFiap.Entities
{
    [Table("Medico")]
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MedicoId { get; set; }
        
        public int EspecialidadeId { get; set; }
        
        public string Nome { get; set; }
        
        public string Email { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string CRM { get; set; }

        public string Senha { get; set; }
    }
}