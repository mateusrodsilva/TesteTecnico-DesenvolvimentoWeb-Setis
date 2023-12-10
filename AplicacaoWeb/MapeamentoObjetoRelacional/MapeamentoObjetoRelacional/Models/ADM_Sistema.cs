using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MapeamentoObjetoRelacional.Models
{
    public class ADM_Sistema
    {
        [Key]
        public byte SIS_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SIS_Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string SIS_Link { get; set; }

        public List<ADM_Perfil> Perfis { get; set; }
    }
}
