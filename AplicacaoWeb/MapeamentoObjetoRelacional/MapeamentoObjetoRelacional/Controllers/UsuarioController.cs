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
                

                // Exibir os dados deserializados
                foreach (var entidade in dataContainer.Entidades)
                {
                    Console.WriteLine($"Entidade Id: {entidade.ENT_Id}");
                    Console.WriteLine($"Entidade Nome: {entidade.ENT_Nome}");
                    Console.WriteLine($"Entidade Responsavel: {entidade.ENT_Responsavel}");
                    Console.WriteLine($"Entidade Terminal Prefixo: {entidade.ENT_TerminalPrefixo}");

                    foreach (var usuario in entidade.Usuarios)
                    {
                        Console.WriteLine($"   - Usuario Id: {usuario.USU_Id}");
                        Console.WriteLine($"     Usuario Nome: {usuario.USU_Nome}");
                        Console.WriteLine($"     Usuario Login: {usuario.USU_Login}");
                        Console.WriteLine($"     Usuario Senha: {usuario.USU_Senha}");
                        Console.WriteLine($"     Usuario Bloqueado: {usuario.USU_Bloqueado}");
                        Console.WriteLine($"     Usuario Data Acesso: {usuario.USU_DataAcesso}");
                    }

                    Console.WriteLine();
                }

                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        // static List<ADM_Entidade> DeserializeFromXml(string filePath)
        // {
        //     XmlSerializer serializer = new XmlSerializer(typeof(DataContainer));
        //
        //     using FileStream fileStream = new FileStream(filePath, FileMode.Open);
        //     
        //     // Altere o tipo de retorno para DataContainer
        //     DataContainer container = (DataContainer)serializer.Deserialize(fileStream);
        //
        //     // Retorne a lista de entidades contida no container
        //     return container?.Entidades;
        // }
        
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
