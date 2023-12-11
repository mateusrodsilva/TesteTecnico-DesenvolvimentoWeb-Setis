using Microsoft.AspNetCore.Mvc;

namespace ProvaTecnicaSetis.Controllers;
[Route("Exercicios")]
public class ExercicioController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}