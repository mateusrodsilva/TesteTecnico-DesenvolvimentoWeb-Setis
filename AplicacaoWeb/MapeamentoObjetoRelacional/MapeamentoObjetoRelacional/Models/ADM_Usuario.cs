using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MapeamentoObjetoRelacional.Models
{
    public class ADM_Usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short USU_Id { get; set; }

        public short USU_ENT_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string USU_Nome { get; set; }

        [Required]
        [MaxLength(16)]
        public string USU_Login { get; set; }

        [Required]
        [MaxLength(100)]
        public string USU_Senha { get; set; }

        public bool USU_Bloqueado { get; set; }

        public DateTime USU_DataAcesso { get; set; }

        [ForeignKey("USU_ENT_Id")]
        public ADM_Entidade Entidade { get; set; }
        
        public List<ADM_UsuarioXPerfil> UsuariosXPerfis { get; set; }
    }
}
