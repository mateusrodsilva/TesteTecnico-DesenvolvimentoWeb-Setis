using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace ProvaTecnicaSetis.Models
{
    [XmlRoot("ADM_Sistema")]
    public class ADM_Sistema
    {
        [XmlElement("SIS_Id")]
        [Key]
        public byte SIS_Id { get; set; }

        [XmlElement("SIS_Nome")]
        [Required]
        [MaxLength(50)]
        public string SIS_Nome { get; set; }

        [XmlElement("SIS_Link")]
        [MaxLength(50)]
        public string? SIS_Link { get; set; }

        [XmlIgnore]
        public List<ADM_Perfil> Perfis { get; set; }
    }
}
