using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MapeamentoObjetoRelacional.Models
{
    public class ADM_Perfil
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short PER_Id { get; set; }

        public byte PER_SIS_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PER_Nome { get; set; }

        [ForeignKey("PER_SIS_Id")]
        public virtual ADM_Sistema Sistema { get; set; }
        
        public virtual List<ADM_UsuarioXPerfil> UsuariosXPerfis { get; set; }
    }
}
