using Arkitektur.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Abstractions;

namespace Arkitektur.WebUI.Controllers
{
 
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
