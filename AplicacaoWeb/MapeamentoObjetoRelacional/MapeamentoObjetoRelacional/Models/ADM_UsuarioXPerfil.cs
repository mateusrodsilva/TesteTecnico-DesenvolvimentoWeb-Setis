using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace MapeamentoObjetoRelacional.Models
{
    public class ADM_UsuarioXPerfil
    {
        public short USP_USU_Id { get; set; }

        public short USP_PER_Id { get; set; }

        [ForeignKey("USP_USU_Id")]
        public virtual ADM_Usuario Usuario { get; set; }

        [ForeignKey("USP_PER_Id")]
        public virtual ADM_Perfil Perfil { get; set; }
    }
}
