using System.Xml.Serialization;

namespace MapeamentoObjetoRelacional.Models
{
    [XmlRoot("Data")] // Indica o elemento raiz esperado
    public class DataContainer
    {
        [XmlElement("ADM_Entidades")] public List<ADM_Entidade> Entidades { get; set; } = new();
    }
}
