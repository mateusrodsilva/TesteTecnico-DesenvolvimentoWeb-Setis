using MapeamentoObjetoRelacional.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace MapeamentoObjetoRelacional.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                // Caminho do arquivo XML
                string filePath = "wwwroot/Data/usuarios.xml";
                
                DataContainer dataContainer = DeserializeFromXml(filePath);

                var model = new List<UsuarioGridView>();
                // Exibir os dados deserializados
                foreach (var entidade in dataContainer.Entidades)
                {               
                    foreach (var usuario in entidade.Usuarios)
                    {
                        foreach (var perfil in usuario.UsuariosXPerfis)
                        {
                            model.Add(new UsuarioGridView
                            {
                                Nome = usuario.USU_Nome,
                                Entidade = entidade.ENT_Nome,
                                Perfil = perfil.Perfil.PER_Nome,
                                Sistema = perfil.Perfil.Sistema.SIS_Nome
                            });
                        }
                    }
                    
                }

                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        
        public static DataContainer DeserializeFromXml(string filePath)
        {
            DataContainer dataContainer;
            try
            {
                // Usando um bloco 'using' para garantir a liberação dos recursos
                using (var reader = new StreamReader(filePath))
                {
                    // Criando instâncias de XmlSerializerNamespaces e XmlSerializer para a classe DataContainer
                    
                    var serializer = new XmlSerializer(typeof(DataContainer));
                
                    // Desserializando o arquivo XML e convertendo para DataContainer
                    dataContainer = (DataContainer)serializer.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return dataContainer;
        }
    }
}
