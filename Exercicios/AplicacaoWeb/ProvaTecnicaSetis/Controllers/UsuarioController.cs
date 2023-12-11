using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using ProvaTecnicaSetis.Models;

namespace ProvaTecnicaSetis.Controllers;
[Route("Usuarios")]
public class UsuarioController : Controller
{
    public IActionResult Index()
    {
        List<UsuarioGridView> lstUsuarios;
        try
        {
            const string filePath = "wwwroot/Data/usuarios.xml";
                
            var dataContainer = DeserializeFromXml(filePath);

            if (dataContainer is null)
                throw new Exception("O arquivo XML não retornou dados. Verifique o arquivo.");
            
            lstUsuarios = 
                (from entidade in dataContainer.Entidades
                    from usuario in entidade.Usuarios
                    select new UsuarioGridView
                    {
                        IdUsuario = usuario.USU_Id,
                        NomeUsuario = usuario.USU_Nome,
                        LoginUsuario = usuario.USU_Login,
                        UsuarioBloqueado = usuario.USU_Bloqueado ? "Sim" : "Não",
                        DataAcessoUsuario = usuario.USU_DataAcesso?.ToString("dd/MM/yyyy") ?? "",
                        NomeEntidade = entidade.ENT_Nome,
                        TerminalPrefixoEntidade = entidade.ENT_TerminalPrefixo.ToString() ?? ""
                    }).ToList();

            return View(lstUsuarios);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return View(new List<UsuarioGridView>());
        }

    }
        
    private static DataContainer? DeserializeFromXml(string filePath)
    {
        DataContainer? dataContainer;
        try
        {
            using var reader = new StreamReader(filePath);
            var serializer = new XmlSerializer(typeof(DataContainer));
            dataContainer = (DataContainer)serializer.Deserialize(reader)!;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            dataContainer = null;
        }

        return dataContainer;
    }
}