using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProvaTecnicaSetis.Models
{
    [XmlRoot("ADM_Perfil")]
    public class ADM_Perfil
    {
        [XmlElement("PER_Id")]
        [Key]
        public short PER_Id { get; set; }

        [XmlElement("PER_SIS_Id")]
        public byte PER_SIS_Id { get; set; }

        [XmlElement("PER_Nome")]
        [Required]
        [MaxLength(50)]
        public string PER_Nome { get; set; }
        
        [XmlElement("ADM_Sistema")]
        [ForeignKey("PER_SIS_Id")]
        public ADM_Sistema Sistema { get; set; }
        
        [XmlIgnore]
        public List<ADM_UsuarioXPerfil> UsuariosXPerfis { get; set; }
    }
}
