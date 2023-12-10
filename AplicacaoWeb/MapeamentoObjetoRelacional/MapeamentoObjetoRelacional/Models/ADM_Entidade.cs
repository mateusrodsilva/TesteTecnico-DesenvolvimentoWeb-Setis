using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MapeamentoObjetoRelacional.Models
{
    [XmlRoot("ADM_Entidade")]
    public class ADM_Entidade
    {
        [XmlAttribute]
        [Key]
        public short ENT_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ENT_Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string ENT_Responsavel { get; set; }

        public short ENT_TerminalPrefixo { get; set; }

        [XmlElement("Usuarios")] public List<ADM_Usuario> Usuarios { get; set; } = new();
    }
}
