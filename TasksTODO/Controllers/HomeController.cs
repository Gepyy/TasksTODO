using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TasksTODO.Models;

namespace TasksTODO.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("ReadTasks", "Task");
        }
    }
}
