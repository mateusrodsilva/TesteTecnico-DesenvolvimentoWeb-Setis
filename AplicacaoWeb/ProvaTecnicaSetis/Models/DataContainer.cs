using System.Xml.Serialization;

namespace ProvaTecnicaSetis.Models
{
    [XmlRoot("Data")] // Indica o elemento raiz esperado
    public class DataContainer
    {
        [XmlArray("ADM_Entidades"), XmlArrayItem("ADM_Entidade", typeof(ADM_Entidade))] public List<ADM_Entidade> Entidades { get; set; } = new();
    }
}
