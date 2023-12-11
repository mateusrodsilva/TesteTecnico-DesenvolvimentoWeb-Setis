namespace ProvaTecnicaSetis.Models;

public class UsuarioGridView
{
    public short IdUsuario { get; set; }
    public string NomeUsuario { get; set; }
    public string LoginUsuario { get; set; }
    public string UsuarioBloqueado { get; set; }
    public string DataAcessoUsuario { get; set; }
    public string NomeEntidade { get; set; }
    public string TerminalPrefixoEntidade { get; set; }
}