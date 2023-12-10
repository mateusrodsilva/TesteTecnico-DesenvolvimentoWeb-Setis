using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using ProvaTecnicaSetis.Models;

namespace ProvaTecnicaSetis.Controllers;

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
                            IdUsuario = usuario.USU_Id,
                            NomeUsuario = usuario.USU_Nome,
                            LoginUsuario = usuario.USU_Login,
                            UsuarioBloqueado = usuario.USU_Bloqueado ? "Sim" : "Não",
                            DataAcessoUsuario = usuario.USU_DataAcesso?.ToString("dd/MM/yyyy") ?? "",
                            NomeEntidade = entidade.ENT_Nome,
                            TerminalPrefixoEntidade = entidade.ENT_TerminalPrefixo.ToString() ?? ""
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
        
    private static DataContainer DeserializeFromXml(string filePath)
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