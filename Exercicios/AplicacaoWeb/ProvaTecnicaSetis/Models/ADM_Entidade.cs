using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProvaTecnicaSetis.Models
{
    [XmlRoot("ADM_Entidade")]
    public class ADM_Entidade
    {
        [Key, XmlElement("ENT_Id")]
        public short ENT_Id { get; set; }

        [Required]
        [MaxLength(50), XmlElement("ENT_Nome")]
        public string ENT_Nome { get; set; }

        [Required]
        [MaxLength(50), XmlElement("ENT_Responsavel")]
        public string ENT_Responsavel { get; set; }
        
        [XmlElement("ENT_TerminalPrefixo")]
        public short? ENT_TerminalPrefixo { get; set; }

        [XmlArray("Usuarios"), XmlArrayItem("ADM_Usuario", typeof(ADM_Usuario))] public List<ADM_Usuario> Usuarios { get; set; } = new();
    }
}
