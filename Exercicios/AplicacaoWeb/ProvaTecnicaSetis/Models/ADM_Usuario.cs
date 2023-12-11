using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProvaTecnicaSetis.Models
{
    [XmlRoot("ADM_Usuario")]
    public class ADM_Usuario
    {
        [Key, XmlElement("USU_Id")]
        public short USU_Id { get; set; }
        
        [XmlElement("USU_ENT_Id")]
        public short USU_ENT_Id { get; set; }

        [Required]
        [MaxLength(50), XmlElement("USU_Nome")]
        public string USU_Nome { get; set; }

        [Required]
        [MaxLength(16), XmlElement("USU_Login")]
        public string USU_Login { get; set; }

        [Required]
        [MaxLength(100), XmlElement("USU_Senha")]
        public string USU_Senha { get; set; }
        [XmlElement("USU_Bloqueado")]
        public bool USU_Bloqueado { get; set; }
        
        [XmlElement("USU_DataAcesso")]
        public DateTime? USU_DataAcesso { get; set; }

        [XmlIgnore]
        [ForeignKey("USU_ENT_Id")]
        public virtual ADM_Entidade Entidade { get; set; }
        
        [XmlArray("UsuariosXPerfis"), XmlArrayItem("ADM_UsuarioXPerfil", typeof(ADM_UsuarioXPerfil))]
        public List<ADM_UsuarioXPerfil> UsuariosXPerfis { get; set; }
    }
}
