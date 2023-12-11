using Microsoft.AspNetCore.Mvc;

namespace ProvaTecnicaSetis.Controllers;

public class ExercicioController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}